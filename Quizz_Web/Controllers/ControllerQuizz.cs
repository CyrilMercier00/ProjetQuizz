using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizz_Models.DTO;
using Quizz_Models.Services;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerQuizz : Controller
    {

        [HttpPost]
        public void Post([FromBody] QuizzDTO prmQuizzDTO)
        {
           
        }
    }
}
