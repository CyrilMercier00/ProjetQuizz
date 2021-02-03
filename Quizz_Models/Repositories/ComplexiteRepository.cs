using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class ComplexiteRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext ();

        public ComplexiteRepository ()
        {

        }


        /// <summary>
        /// La methode un objet de type TauxComplexite la ou le nom correspond au champ niveau dans la base
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public TauxComplexite GetTauxComplexiteByNom ( String prmNomComplexite )
        {

            return bdd_entities.TauxComplexite
                    .Where (x => x.Niveau == prmNomComplexite)
                    .Single ();
        }

        /// <summary>
        /// La methode un objet de type TauxComplexite la ou le nom correspond au champ niveau dans la base
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public TauxComplexite GetValTauxComplexiteByNom ( String prmNomComplexite )
        {

            return bdd_entities.TauxComplexite
                    .Where (x => x.Niveau == prmNomComplexite)
                    .Single ();
        }

        /// <summary>
        /// Retourne une liste avec tout les niveau de complexité trouvés
        /// </summary>
        /// <returns></returns>
        public List<TauxComplexite> GetAllComplexite ()
        {
            return bdd_entities.TauxComplexite
                .ToList ();
        }

    }
}