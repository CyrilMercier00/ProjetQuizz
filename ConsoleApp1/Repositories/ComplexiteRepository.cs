using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
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

        internal TauxComplexite Create(TauxComplexite taux_Complexite)
        {
            bdd_entities.TauxComplexite.Add(taux_Complexite);
            bdd_entities.SaveChanges();
            return taux_Complexite;
        }

        internal void Update(int id, TauxComplexite nouveautxcomplexite)
        {
            //return bdd_entities.TauxComplexite.Where(x => x.PkComplexite.Equals(id)).Single();

            TauxComplexite ancientxcomplexite= bdd_entities.TauxComplexite.Find(id);
            ancientxcomplexite = nouveautxcomplexite;
            bdd_entities.SaveChanges();
            //if (nouveautxcomplexite == null)
            //{
            //    throw new ArgumentNullException("nouveautxcomplexite");
            //}
            //int index = nouveautxcomplexite.PkComplexite;
            //if (index == -1)
            //{
            //    return false;
            //}
            //bdd_entities.TauxComplexite.Remove(index);
            //bdd_entities.TauxComplexite.Add(nouveautxcomplexite);
            //return true;
        }


        /// <summary>
        /// La methode un objet de type TauxComplexite la ou le nom correspond au champ niveau dans la base
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
        public List<TauxComplexite> GetAllNomComplexite ()
        {
            return bdd_entities.TauxComplexite
                .ToList ();
        }

        public List<TauxComplexite> GetAllComplexite()
        {
            return bdd_entities.TauxComplexite.ToList();

        }
    }
}