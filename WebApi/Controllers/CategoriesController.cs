﻿using DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDiagnosisRepository diagnosisRepository;

        public CategoriesController(IDiagnosisRepository diagnosisRepository)
        {
            this.diagnosisRepository = diagnosisRepository;
        }

        [HttpGet]
        public IEnumerable<string> GetCategories()
        {
            return diagnosisRepository.GetCategories();
        }
    }
}
