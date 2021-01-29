using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Quizz_Models;
using Quizz_Web.Models;
using Newtonsoft.Json;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class ControllerQuizz : ControllerBase
    {
        [HttpPost]
        public void Post ( [FromBody] ModelCreaQuizz prmOptionsQuizz )
        {
            QuizzBDD.bdd_instance.InsertQuizz (prmOptionsQuizz);
        }
    }
}
