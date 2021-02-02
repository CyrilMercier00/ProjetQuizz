using Quizz_Models.bdd_quizz;


namespace Quizz_Models.Services
{
    public class CompteRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext();
        public CompteRepository() { }

        public Compte GetCompteByID(int prmID)
        {
            return bdd_entities.Compte.Find(prmID);
        }

        public void InsertCompte(Compte prmCompte)
        {
            bdd_entities.Compte.Add(prmCompte);
            bdd_entities.SaveChanges();
        }

        public void DeleteCompte(int CompteID)
        {
            Compte CompteEntity = bdd_entities.Compte.Find(CompteID);
            bdd_entities.Compte.Remove(CompteEntity);
        }
    }
}
