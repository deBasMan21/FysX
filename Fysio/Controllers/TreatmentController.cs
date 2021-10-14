﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fysio.Models;
using Domain;
using DomainServices.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Fysio.Controllers
{
    [Authorize(Policy = "RequireTreator")]
    public class TreatmentController : Controller
    {
        private readonly ITreatmentRepository treatmentRepository;
        private readonly ITreatorRepository treatorRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IPatientFileRepository patientFileRepository;
        private readonly UserManager<IdentityUser> userManager;

        public TreatmentController(ITreatmentRepository treatmentRepository, ITreatorRepository treatorRepository, IPatientRepository patientRepository, IPatientFileRepository patientFileRepository, UserManager<IdentityUser> userManager)
        {
            this.treatmentRepository = treatmentRepository;
            this.treatorRepository = treatorRepository;
            this.patientRepository = patientRepository;
            this.patientFileRepository = patientFileRepository;
            this.userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            Treatment t = treatmentRepository.GetTreatmentById(id);
            return View(t);
        }
        
        [HttpGet]
        public IActionResult AddTreatment(string p, int id)
        {
            Treatment t = treatmentRepository.GetTreatmentById(id);
            if(t != null)
            {
                ViewBag.IsNew = false;
                TreatmentModel treatmentModel = new TreatmentModel(t.Type, t.Description, t.Location, t.Particularities) { PatientEmail = t.Patient.Email, TreatmentId = t.Id };
                return View(treatmentModel);
            } else
            {
                ViewBag.IsNew = true;
                return View(new TreatmentModel() { PatientEmail = p});
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTreatment(TreatmentModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.TreatmentId != 0)
                {
                    IdentityUser usr = userManager.GetUserAsync(HttpContext.User).Result;
                    string email = usr.Email;
                    Treator treator = treatorRepository.GetTreatorByEmail(email);

                    Patient p = patientRepository.GetPatientByEmail(model.PatientEmail);

                    Treatment t = new Treatment(model.Type, model.Description, model.Location, model.Particularities, treator, p, DateTime.Now);
                    treatmentRepository.UpdateTreatment(model.TreatmentId, t);
                    return (ActionResult)RedirectToAction("Index", "PatientFile", p.Id);
                } else
                {
                    IdentityUser usr = userManager.GetUserAsync(HttpContext.User).Result;
                    string email = usr.Email;
                    Treator treator = treatorRepository.GetTreatorByEmail(email);

                    Patient p = patientRepository.GetPatientByEmail(model.PatientEmail);

                    Treatment t = new Treatment(model.Type, model.Description, model.Location, model.Particularities, treator, p, DateTime.Now);
                    treatmentRepository.AddTreatment(t);

                    PatientFile pf = patientFileRepository.GetCurrentPatientFileForPatient(p);
                    pf.Treatments.Add(t);
                    patientFileRepository.UpdatePatientFile(pf);
                    return (ActionResult)RedirectToAction("Index", "PatientFile", pf);
                }
            } else
            {
                return View();
            }
        }

        public ActionResult DeleteTreatment(int treatmentId)
        {
            if(treatmentId != 0)
            {
                Treatment t = treatmentRepository.GetTreatmentById(treatmentId);

                Patient p = patientRepository.GetPatientByEmail(t.Patient.Email);
                PatientFile pf = patientFileRepository.GetCurrentPatientFileForPatient(p);
                
                treatmentRepository.DeleteTreatment(t);

                return RedirectToAction("Index", "PatientFile", pf);
            } else
            {
                ViewBag.IsNew = false;
                return View("Error");
            }
        }

        public IActionResult ToPatientList()
        {
            return RedirectToAction("Index", "Patient");
        }
    }
}
