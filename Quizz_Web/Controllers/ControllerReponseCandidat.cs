using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Quizz_Models;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class ControllerReponseCandidat : ControllerBase
    {
        [HttpPost]
        public void Post ( [FromBody] reponse_candidat prmRepCand )
        {
            Console.WriteLine (prmRepCand);
            throw new Exception ("Pas implémenté");
        }
    }
}
