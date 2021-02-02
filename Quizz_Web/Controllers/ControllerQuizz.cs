using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route ("api/quizz")]
    public class ControllerQuizz : Controller
    {
        readonly QuizzService servQuizz = new QuizzService ();

        [HttpPost]
        public void Post ( [FromBody] QuizzDTO prmQuizzDTO )
        {
            servQuizz.GenererQuizz (
                prmQuizzDTO.NbQuestions,
                prmQuizzDTO.Complexite,
                prmQuizzDTO.Theme,
                TimeSpan.Parse (prmQuizzDTO.Chrono)
                );
        }
    }
}
