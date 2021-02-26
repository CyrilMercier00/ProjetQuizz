using Microsoft.AspNetCore.Mvc;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/quizz")]
    public class ControllerQuizz : Controller
    {
        readonly ServiceQuizz servQuizz;
        ActionResult<QuizzDTO> valRetour;

        public ControllerQuizz(ServiceQuizz serviceQuizz)
        {
            this.servQuizz = serviceQuizz;
        }



        [HttpPost]
        public ActionResult<QuizzDTO> Post([FromBody] QuizzDTO prmQuizzDTO)
        {
            ActionResult valRetour;

            try
            {
                servQuizz.GenererQuizz(prmQuizzDTO);
                valRetour = Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                valRetour = BadRequest(e.InnerException);
            }

            return valRetour;
        }


        /// <summary>
        /// Assignation d'un candidat a un quizz
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <param name="prmIDCandidat"></param>
        [HttpPut]
        [Route("{idQuizz}/{idCandidat}")]
        public ActionResult<QuizzDTO> AssignCandidatToQuizz([FromRoute] int prmIDQuizz, [FromRoute] int prmIDCandidat)
        {
            switch (servQuizz.assignCandidatToQuizz(prmIDQuizz, prmIDCandidat))
            {
                case 0:
                    valRetour = Problem();
                    break;

                case 1:
                    valRetour = Ok();
                    break;

                default:
                    valRetour = Problem("Erreur Put ControllerQuizz");
                    break;
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
        public ActionResult<QuizzDTO> Delete([FromBody] int prmIDQuizz)
        {
            valRetour = Ok();
            try
            {
                servQuizz.SupprimerQuizz(prmIDQuizz);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                valRetour = NotFound();
            }
            return valRetour;
        }

    }
}