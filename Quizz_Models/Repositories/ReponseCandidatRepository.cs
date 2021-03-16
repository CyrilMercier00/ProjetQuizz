using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Repositories
{
    public class ReponseCandidatRepository
    {
        private readonly bdd_quizzContext bdd_entities;
        public ReponseCandidatRepository(bdd_quizzContext context)
        {
            bdd_entities = context;
        }

        public int InsertReponseCandidat(ReponseCandidat prmReponseCandidat)
        {
            bdd_entities.ReponseCandidat.Add(prmReponseCandidat);
            return bdd_entities.SaveChanges();
        }

        public List<ReponseCandidat> SelectReponseCandidatByIDQuestion(int prmIDQuestion)
        {
            return bdd_entities.ReponseCandidat
                .Where(x => x.FkQuestion == prmIDQuestion)
                .ToList();
        }

        public ReponseCandidatDTO TransformRepCandidatEnRepCandidatDto(ReponseCandidat reponseCandidat)
        {
            ReponseCandidatDTO retour;
            try
            {
                retour = new ReponseCandidatDTO
                {
                    Reponse = reponseCandidat.Reponse,
                    Commentaire = reponseCandidat.Commentaire,
                    FkCompte = reponseCandidat.FkCompte,
                    FkQuestion = reponseCandidat.FkQuestion
                };
            }
            catch
            {
                retour = new ReponseCandidatDTO
                {
                    Reponse = "",
                    Commentaire = ""
                };
            }
          
                return retour;
            

        }
    }
}

