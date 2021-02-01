using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public List<CompteDTO> Get()
        {
            return this.compteService.GetCompte();
        }

        [HttpPost]
        public void Post([FromBody] CompteDTO compteDTO)
        {
            this.compteService.AjoutCompte(compteDTO);
        }
    }
}
