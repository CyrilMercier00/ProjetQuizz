using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System.Collections.Generic;
using Quizz_Models.bdd_quizz;
using Newtonsoft.Json;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class ControllerQuestion : Controller
    {
        readonly QuestionService questionService;
        readonly ServiceTheme _servTheme;

        public ControllerQuestion(QuestionService prmQuestionService,ServiceTheme serviceTheme)
        {
            this.questionService = prmQuestionService;
            this._servTheme = serviceTheme;
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
        /// Get des questions et des réponses associé au quizz avec le code unique
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        [HttpGet("{vide}/{codeQuizz}")]
        public string GetQuestionReponses(string codeQuizz)
        {
            List<Question> listQuestion;             // Contiens la liste des questions

            listQuestion = this.questionService.GetListQuestionByCodeQuizz(codeQuizz); // Get de la liste des questions 
            if (listQuestion != null)
            {
                List<QuestionReponseDTO> a = this.questionService.AddReponseToQuestion(listQuestion); // Ajout des reponses pour chaque questions sous 
                return JsonConvert.SerializeObject(a);
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

        }

    }
}

