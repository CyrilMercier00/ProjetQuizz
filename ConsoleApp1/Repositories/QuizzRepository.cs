using Quizz_Models.bdd_quizz;

namespace Quizz_Models.Services
{
    public class QuizzRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext();


        public QuizzRepository() { }

        public void InsertQuizz(Quizz prmQuizz)
        {
            bdd_entities.Quizz.Add(prmQuizz);
            bdd_entities.SaveChanges ();
        }

    }
}