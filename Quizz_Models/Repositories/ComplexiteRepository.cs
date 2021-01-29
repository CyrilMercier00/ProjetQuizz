using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class ComplexiteRepository
    {
        private readonly bdd_quizzEntities bdd_entities = new bdd_quizzEntities();

        public ComplexiteRepository()
        {

        }


        /// <summary>
        /// La methode retourne une liste avec les taux recuperes dans la base
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public List<int?> GetComplexiteByNom(String prmNomComplexite)
        {
            List<int?> ListeRetour = new List<int?>();

            var data = bdd_entities.taux_complexite
                    .Where(x => x.niveau == prmNomComplexite)
                    .Select(x => new
                    {
                        x.question_junior,
                        x.quest_confirme,
                        x.question_experimente
                    })
                    .ToList();

            foreach (var v in data)
            {
                ListeRetour.Add(v.question_junior);
                ListeRetour.Add(v.quest_confirme);
                ListeRetour.Add(v.question_experimente);
                Console.WriteLine("GetComplexiteByNom fin foreach atteint");
            }

            return ListeRetour;
        }


        /// <summary>
        /// Retourne une liste avec tout les niveau de complexité trouvés
        /// </summary>
        /// <returns></returns>
        public List<String> GetAllNomComplexite()
        {
            return bdd_entities.taux_complexite
                .Select(x => x.niveau)
                .ToList();
        }

    }
}