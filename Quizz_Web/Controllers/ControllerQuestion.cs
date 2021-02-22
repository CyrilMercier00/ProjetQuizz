﻿using Microsoft.AspNetCore.Mvc;
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
        readonly CompteService compteService;

        public ControllerQuestion(CompteService compteService)
        {
            this.compteService = compteService;
        }



        [HttpGet("{id}")]
        public CompteDTOAdmin Get(int id)
        {
            CompteDTOAdmin compte = this.compteService.GetCompte(id);

            if (compte == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

            return compte;
        }

        

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.compteService.DeleteCompte(id);
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

    }
}
