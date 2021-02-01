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
        public List<int?> GetComplexiteByNom(String prmNomComplexite)
        {
            List<int?> ListeRetour = new List<int?>();

            var data = bdd_entities.TauxComplexite
                    .Where(x => x.Niveau == prmNomComplexite)
                    .Select(x => new
                    {
                        x.QuestionJunior,
                        x.QuestConfirme,
                        x.QuestionExperimente
                    })
                    .ToList();

            foreach (var v in data)
            {
                ListeRetour.Add(v.QuestionJunior);
                ListeRetour.Add(v.QuestConfirme);
                ListeRetour.Add(v.QuestionExperimente);
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
            return bdd_entities.TauxComplexite
                .Select(x => x.Niveau)
                .ToList();
        }

    }
}