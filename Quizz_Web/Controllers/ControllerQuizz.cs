using Microsoft.AspNetCore.Mvc;
using Quizz_Models.bdd_quizz;
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
                servQuizz.GenererQuizz (prmQuizzDTO);
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
                valRetour = NotFound ();
            }
            return valRetour;
        }


        [HttpGet]
        [Route("{id}/{Urlcode}")]
        public QuizzDTO GetQuizzById(int id)
        {
          

                QuizzDTO quizz = new QuizzDTO();
            
            quizz = this.servQuizz.GetQuizz(id);
                
                if (quizz == null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    return null;
                }

                return quizz;
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