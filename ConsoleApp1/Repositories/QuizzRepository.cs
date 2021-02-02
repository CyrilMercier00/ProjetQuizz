using Quizz_Models.bdd_quizz;
using System;

namespace Quizz_Models.Services
{
    public class QuizzRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext ();


        public QuizzRepository () { }

        public void InsertQuizz ( Quizz prmQuizz )
        {
            bdd_entities.Quizz.Add (prmQuizz);
            bdd_entities.SaveChanges ();
        }

        public Quizz GetQuizzByID ( int prmIDQuizz )
        {
            return bdd_entities.Quizz
                .Find (prmIDQuizz);
        }

        public void SupprimerQuizz ( Quizz prmQuizz )
        {
            bdd_entities.Quizz.Remove (prmQuizz);
        }
    }
}