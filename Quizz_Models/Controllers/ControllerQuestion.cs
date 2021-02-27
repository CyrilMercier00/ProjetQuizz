using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System.Collections.Generic;
using Quizz_Models.bdd_quizz;
using System;

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





        /// <summary>
        /// Insertion d'une nouvelle question
        /// </summary>
        /// <param name="prmDTO"></param>
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



        /// <summary>
        /// Get des questions et des réponses associé au quizz avec l'id passé
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        [HttpGet("{idQuizz}")]
        public List<QuestionReponseDTO> GetQuestionReponses(int idQuizz)
        {
            List<Question> listQuestion;                        // Contiens la liste des questions
            List<QuestionReponseDTO> listQuestionReponseDTO;    // Contiens la liste des questions avec les réponses associées

            listQuestion = this.questionService.GetListQuestionByIDQuizz(idQuizz);  // Get des questions 
            listQuestionReponseDTO = this.questionService.AddReponseToQuestion(listQuestion);   // Get des reponses

            if (listQuestion == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return listQuestionReponseDTO;
            }

        }
    }
}

