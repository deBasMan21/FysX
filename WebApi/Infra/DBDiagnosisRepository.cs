﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Infra
{
    public class DBDiagnosisRepository : IDiagnosisRepository
    {
        private readonly ApiDbContext context;

        public DBDiagnosisRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Diagnosis> GetAllDiagnoses()
        {
            return context.Diagnoses.ToList();
        }

        public IEnumerable<Diagnosis> GetDiagnosesByCategory(string category)
        {
            return context.Diagnoses.Where(p => p.BodyPart == category).ToList();
        }

        public Diagnosis GetDiagnosisById(int id)
        {
            return context.Diagnoses.Where(p => p.Id == id).FirstOrDefault();
        }

        public void AddDiagnosis(Diagnosis diagnosis)
        {
            context.Diagnoses.Add(diagnosis);
            context.SaveChanges();

        }
    }
}
