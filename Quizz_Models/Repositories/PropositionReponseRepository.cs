using Microsoft.EntityFrameworkCore;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Repositories
{
    public class PropositionReponseRepository
    {
        private readonly bdd_quizzContext bdd_entities;

        public PropositionReponseRepository(bdd_quizzContext context)
        {
            bdd_entities = context;
        }

        /// <summary>
        /// Renvoie la liste des reponses possible pour cette question
        /// </summary>
        /// <param name="prmIDQuestion"></param>
        /// <returns></returns>
        public List<PropositionReponse> SelectReponseByIDQuestion (int prmIDQuestion)
        {
            return bdd_entities.PropositionReponse
                .Where(x => x.FkQuestion == prmIDQuestion)
                .ToList();
        }
    }
}