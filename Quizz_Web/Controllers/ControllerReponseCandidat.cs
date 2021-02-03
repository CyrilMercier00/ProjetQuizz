using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/reponse-candidat")]
    public class ControllerReponseCandidat : Controller
    {
        readonly CompteService compteService;

        public ControllerReponseCandidat ()
        {
            this.compteService = new CompteService();
        }

        [HttpGet("{id}")]
        public void Get(int id)
        {
            this.compteService.GetCompte(id);
        }

    }
}
