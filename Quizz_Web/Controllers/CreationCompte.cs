﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizz_Models.DTO;
using Quizz_Models.Services;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/compte")]
    public class CreationCompte : Controller
    {
        readonly CompteService compteService;

        public CreationCompte()
        {
            this.compteService = new CompteService();
        }

        [HttpGet("{id}")]
        public void Get(int id)
        {
            this.compteService.GetCompte(id);
        }

        [HttpPost]
        public void Post([FromBody] CompteDTO compteDTO)
        {
            Console.WriteLine(compteDTO.Nom);
            this.compteService.AjoutCompte(compteDTO);
        }
    }
}
