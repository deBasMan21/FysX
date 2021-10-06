﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio.Models
{
    public class TreatmentModel
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Particularities { get; set; }

        public string PatientEmail { get; set; }

        public TreatmentModel(string type, string description, string location, string particularities)
        {
            Type = type;
            Description = description;
            Location = location;
            Particularities = particularities;
        }

        public TreatmentModel()
        {

        }
    }
}