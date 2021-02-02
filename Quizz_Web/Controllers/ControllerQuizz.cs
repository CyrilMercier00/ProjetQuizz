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
        ActionResult<QuizzDTO> valRetour;

        [HttpPost]
        public ActionResult<QuizzDTO> Post ( [FromBody] QuizzDTO prmQuizzDTO )
        {
            valRetour = Ok ();
            try
            {
                servQuizz.GenererQuizz (
                    prmQuizzDTO.NbQuestions,
                    prmQuizzDTO.Complexite,
                    prmQuizzDTO.Theme,
                    TimeSpan.Parse (prmQuizzDTO.Chrono)
                    );
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
                valRetour = NotFound ();
            }
            return valRetour;
        }



        [HttpDelete]
        public ActionResult<QuizzDTO> Delete ( [FromBody] int prmIDQuizz )
        {
            valRetour = Ok ();
            try
            {
                servQuizz.SupprimerQuizz (prmIDQuizz);
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
                valRetour = NotFound ();
            }
            return valRetour;
        }

    }
}