using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;
using System.Collections.Generic;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/compte")]
    public class ControllerCompte : Controller
    {
        readonly CompteService compteService;

        public ControllerCompte()
        {
            this.compteService = new CompteService();
        }

        [HttpGet("{id}")]
        public CompteDTO Get(int id)
        {
            return this.compteService.GetCompte(id);
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
