﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infra;

namespace WebApi.Models
{
    public class Query
    {
        private readonly IDiagnosisRepository diagnosisRepository;
        private readonly ITreatmentRepository treatmentRepository;

        public Query(IDiagnosisRepository diagnosisRepository, ITreatmentRepository treatmentRepository)
        {
            this.diagnosisRepository = diagnosisRepository;
            this.treatmentRepository = treatmentRepository;
        }

        public IQueryable<Diagnosis> Diagnoses()
        {
            return diagnosisRepository.GetAll();   
        }

        public Diagnosis GetDiagnosisById(int id)
        {
            return diagnosisRepository.GetDiagnosisById(id);
        }

        public IEnumerable<Diagnosis> GetDiagnosesByCategory(string category)
        {
            return diagnosisRepository.GetDiagnosesByCategory(category);
        }
    }
}