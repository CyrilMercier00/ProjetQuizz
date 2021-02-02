using Quizz_Models.bdd_quizz;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class CompteRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext();
        public CompteRepository() { }

        public List<Compte> GetAllComptes()
        {
            return bdd_entities.Compte.ToList();
        }

        public Compte GetCompteByID(int prmID)
        {
            return bdd_entities.Compte.Find(prmID);
        }

        public void InsertCompte(Compte prmCompte)
        {
            bdd_entities.Compte.Add(prmCompte);
        }

        public void DeleteCompte(int CompteID)
        {
            Compte CompteEntity = bdd_entities.Compte.Find(CompteID);
            bdd_entities.Compte.Remove(CompteEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Sauvegarder()
        {
            int lignes;
            try
            {
                lignes = bdd_entities.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                lignes = -1;
            }
            return lignes;
        }
    }
}
