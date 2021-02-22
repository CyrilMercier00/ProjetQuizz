using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System.Collections.Generic;
using Quizz_Models.bdd_quizz;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class ControllerQuestion : Controller
    {
        readonly QuestionService questionService;

        public ControllerQuestion(QuestionService prmQuestionService)
        {
            this.questionService = prmQuestionService;
        }



        [HttpPost]
        public void Post([FromBody] QuestionDTO prmDTO)
        { 
            int lignes = this.questionService.Insert(prmDTO);

            if (lignes == -1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            else if (lignes == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            // Si aucune permission n'a été ajouté
            else if (lignes == 1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
            // Si permission ajoutée
            else if (lignes == 2)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
        }



        [HttpGet("{idQuizz}")]
        public List<CompteDTO> Get(int idQuizz)
        {
            List<Question> listQuestion = this.questionService.GetListQuestionByIDQuizz(idQuizz);
            List<QuestionDTO> listQuestionDTO = new List<QuestionDTO>();

            if (listQuestion == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

            foreach (Question q in listQuestion)
            {
                listQuestionDTO.Add(new CompteDTO()
                {

                });

            }

            return listDTO;
        }
    }
}
