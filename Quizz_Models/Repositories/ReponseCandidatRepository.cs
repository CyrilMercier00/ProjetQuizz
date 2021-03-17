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

        //reponse vrai ou faux
        private bool getReponseCandidatIstrueByIDQuestion(int fkQuestion)
        {
            bool b = false;
            try {
                  b=  Convert.ToBoolean(
                   bdd_entities.PropositionReponse.Join(bdd_entities.ReponseCandidat,
                              p => p.PkReponse,
                              pC => pC.PkReponse,
                              (p, pC) => new { props = p, question_C = pC })
                     .Where(pqC => pqC.question_C.FkQuestion == fkQuestion )
                     .Select(pqC => pqC.props.EstBonne)
                     .Single());

            } catch {
                b = false;
            }
            return b;
        }
        public ReponseCandidatDTO TransformRepCandidatEnRepCandidatDto(ReponseCandidat reponseCandidat)
        {
            ReponseCandidatDTO retour;
            //traitement vrai ou faux 
            bool TrueOrFalse = this.getReponseCandidatIstrueByIDQuestion(reponseCandidat.FkQuestion);



            try
            {
                retour = new ReponseCandidatDTO
                {
                    Reponse = reponseCandidat.Reponse,
                    Commentaire = reponseCandidat.Commentaire,
                    FkCompte = reponseCandidat.FkCompte,
                    FkQuestion = reponseCandidat.FkQuestion,
                    isTrue = TrueOrFalse
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

