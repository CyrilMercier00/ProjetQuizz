using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class ComplexiteRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext();

        public ComplexiteRepository()
        {

        }


        /// <summary>
        /// La methode retourne une liste avec les taux recuperes dans la base
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public TauxComplexite GetComplexiteByNom(String prmNomComplexite)
        {


            return bdd_entities.TauxComplexite
                .Where(x => x.Niveau.Equals( prmNomComplexite)).Single();
         
        }


        /// <summary>
        /// Retourne une liste avec tout les niveau de complexité trouvés
        /// </summary>
        /// <returns></returns>
        public List<String> GetAllNomComplexite()
        {
            return bdd_entities.TauxComplexite
                .Select(x => x.Niveau)
                .ToList();
        }

        public List<TauxComplexite> GetAllComplexite()
        {
            return bdd_entities.TauxComplexite.ToList();
               
        }
    }
}