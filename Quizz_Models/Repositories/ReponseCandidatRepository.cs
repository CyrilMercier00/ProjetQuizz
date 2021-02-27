using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Repositories
{
    public class ReponseCandidatRepository
    {
        private readonly bdd_quizzContext bdd_entities ;
        public ReponseCandidatRepository (bdd_quizzContext context) 
        {
            bdd_entities = context;
        }

        public void InsertReponseCandidat ( ReponseCandidat prmReponseCandidat )
        {
            bdd_entities.ReponseCandidat.Add (prmReponseCandidat);
            bdd_entities.SaveChanges ();
        }
    }
}
