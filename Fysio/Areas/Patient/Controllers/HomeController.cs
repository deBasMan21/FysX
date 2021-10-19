﻿using Domain;
using DomainServices.Interfaces;
using DomainServices.Services;
using Fysio.Areas.Treator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize(Policy = "RequirePatient")]
    public class HomeController : Controller
    {
        private readonly IPatientRepository patientRepository;
        private readonly IPatientFileRepository patientFileRepository;
        private readonly ITreatorRepository treatorRepository;
        private readonly AddAppointmentService addAppointmentService;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(IPatientRepository patientRepository, IPatientFileRepository patientFileRepository, ITreatorRepository treatorRepository, AddAppointmentService addAppointmentService, UserManager<IdentityUser> userManager)
        {
            this.patientRepository = patientRepository;
            this.patientFileRepository = patientFileRepository;
            this.treatorRepository = treatorRepository;
            this.addAppointmentService = addAppointmentService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            IdentityUser usr = userManager.GetUserAsync(HttpContext.User).Result;
            string email = usr.Email;
            Domain.Patient p = patientRepository.GetPatientByEmail(email);

            ViewBag.IsTreator = false;
            return View("Index", ConvertPatientToPatientModel(p));
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {
            ViewBag.IsNew = true;

            List<Domain.Treator> allTreators = treatorRepository.GetAllTreators();
            ViewBag.Treators = from Domain.Treator t in allTreators select new SelectListItem { Value = t.Email, Text = t.Name };

            List<Domain.Patient> allPatients = patientRepository.GetAllPatients();
            ViewBag.Patients = from Domain.Patient p in allPatients select new SelectListItem { Value = p.Id.ToString(), Text = p.Name };


            IdentityUser usr = userManager.GetUserAsync(HttpContext.User).Result;
            string email = usr.Email;
            Domain.Patient patient = patientRepository.GetPatientByEmail(email);

            PatientFile pf = patientFileRepository.GetCurrentPatientFileForPatient(patient);

            AppointmentModel model = new AppointmentModel() { PatientId = patient.Id, TreatorEmail = pf.MainTreator.Email};
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAppointment(AppointmentModel model)
        {
            ViewBag.IsNew = true;

            List<Domain.Treator> allTreators = treatorRepository.GetAllTreators();
            ViewBag.Treators = from Domain.Treator t in allTreators select new SelectListItem { Value = t.Email, Text = t.Name };

            List<Domain.Patient> allPatients = patientRepository.GetAllPatients();
            ViewBag.Patients = from Domain.Patient p in allPatients select new SelectListItem { Value = p.Id.ToString(), Text = p.Name };

            if (ModelState.IsValid)
            {
                Domain.Treator t = treatorRepository.GetTreatorByEmail(model.TreatorEmail);
                Domain.Patient p = patientRepository.GetPatientById(model.PatientId);
                DateTime dateTime = DateTime.Parse(model.AppointmentDate + " " + model.AppointmentTime);
                PatientFile pf = patientFileRepository.GetCurrentPatientFileForPatient(p);
                int duration = pf.TreatmentPlan.MinutesPerSession;
                Appointment appointment = new Appointment(t, p, dateTime, dateTime.AddMinutes(duration));

                if(addAppointmentService.AddAppointment(appointment, pf))
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View();
                }
            } else
            {
                return View();
            }
        }

        private PatientModel ConvertPatientToPatientModel(Domain.Patient patient)
        {
            bool gender = patient.Gender == Gender.Male ? true : false;
            PatientModel model = new PatientModel() { Birthdate = patient.BirthDate, Email = patient.Email, Name = patient.Name, PhoneNumber = patient.PhoneNumber, RegistrationNumber = patient.RegistrationNumber, Teacher = !patient.Student, Gender = gender, Id = patient.Id };
            if (patient.Image != null)
            {
                model.ImageSrc = "data:image/gif;base64," + Convert.ToBase64String(patient.Image);
            }
            return model;
        }
    }
}
