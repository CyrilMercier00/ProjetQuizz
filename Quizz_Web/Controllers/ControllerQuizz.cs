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
        readonly ServiceQuizz servQuizz = new ServiceQuizz ();
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
                    TimeSpan.Parse (prmQuizzDTO.Chrono),
                    prmQuizzDTO.Urlcode
                    );
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
                valRetour = NotFound ();
            }
            return valRetour;
        }

        //[HttpGet]
        //[Route("{Urlcode}")]
        //public QuizzDTO GetQuizzDTO([FromBody] int prmIDQuizz)
        //{

        //    // return servQuizz.GetQuizzbyId(prmIDQuizz);
        //}

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