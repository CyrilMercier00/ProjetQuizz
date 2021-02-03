using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route ("api/reponse-candidat")]
    public class ControllerReponseCandidat : Controller
    {
        readonly ServiceReponseCandidat repService = new ServiceReponseCandidat ();

        [HttpPost]
        public void Post ( [FromBody] ReponseCandidatDTO prmDTO )
        {
            repService.InsertReponseCandidat (prmDTO);
        }
    }
}
