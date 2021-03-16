using Microsoft.AspNetCore.Mvc;
using Quizz_Models.Authentification;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/quizz/")]
    public class ControllerQuizz : Controller
    {
        readonly ServiceQuizz _servQuizz;
        readonly CompteService _servCompte;
        ActionResult<QuizzDTO> valRetour;

        public ControllerQuizz(ServiceQuizz serviceQuizz, CompteService servCompte)
        {
            this._servQuizz = serviceQuizz;
            this._servCompte = servCompte;
        }


        [Authorize(AuthorizationEnum.GenererQuizz)]
        [HttpPost]
        public ActionResult<QuizzDTO> Post([FromBody] CreationQuizzDTO prmQuizzDTO)
        {
            ActionResult valRetour;

            try
            {
                _servQuizz.GenererQuizz(prmQuizzDTO);
                valRetour = Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                valRetour = BadRequest(e.Message);
            }

            return valRetour;
        }

        [HttpGet]
        [Route("{idCreateur}")]
        public QuizzDTO GetAllQuizzFromCreateur(int idCreateur)
        {
            return this._servQuizz.GetQuizz(idCreateur);
        }

        [HttpGet]
        [Route("{vide}/{codeQuizz}")]
        public QuizzDTO GetQuizzByCode(string vide , string codeQuizz)
        {
            QuizzDTO quizz = new QuizzDTO();

            quizz = this._servQuizz.GetQuizz(codeQuizz);

            if (quizz == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return quizz;
            }

        }

        /// <summary>
        /// Assignation d'un candidat a un quizz
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <param name="prmIDCandidat"></param>
        [HttpPut]
        [Route("{idQuizz}/{idCandidat}")]
        public ActionResult<QuizzDTO> AssignCandidatToQuizz(int idQuizz, int idCandidat)
        {
            switch (_servQuizz.assignCandidatToQuizz(idQuizz, idCandidat))
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
        [Route("{codeQuizz}")]
        public QuizzDTO GetQuizzByCode(string codeQuizz)
        {
            QuizzDTO quizz = new QuizzDTO();

            quizz = this._servQuizz.GetQuizz(codeQuizz);

            if (quizz == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            } else
            {
                return quizz;
            }

        }
        
        
        //Envoi mail automatique à l'arriver de la page renvoi vers la page resultat 
        [HttpGet]
        [Route("quizzsuccess/{codeQuizz}/{idCandidat}/{vide}")]
        public ActionResult<QuizzDTO> FinQuizz(string codeQuizz,int idCandidat)
        {
           
            valRetour = Ok();
            try
            {//recup le quizz 
                QuizzDTO quizz = new QuizzDTO();
                quizz = this._servQuizz.GetQuizz(codeQuizz);
                int idQuizz = quizz.PkQuizz;
               
                Compte compteRecruteur= this._servCompte.GetCompteRecruteurByIdQuizz(quizz.PkQuizz);
                int idRecruteur = compteRecruteur.PkCompte;

                
                this._servQuizz.ValiderQuizz(idQuizz, idCandidat, idRecruteur);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                valRetour = NotFound();
            }
            return valRetour;
        }
        

        [HttpDelete]
        public ActionResult<QuizzDTO> Delete([FromBody] int prmIDQuizz)
        {
            valRetour = Ok();
            try
            {
                _servQuizz.SupprimerQuizz(prmIDQuizz);
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