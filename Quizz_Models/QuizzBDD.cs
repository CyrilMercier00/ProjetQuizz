using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models
{
    /*  
     *  Ajouter les methodes qui interagissent avec la bdd et qui on besoin de logique ici.
     */

    public sealed class QuizzBDD
    {
        /* --- Attributs --- */
        bdd_quizzEntities bdd_entities;        // Reference aux entites de la bdd quizz generees par entity 
        public static QuizzBDD bdd_instance { get { return LazyInstance.Value; } }       // Instance de cette classe 
        static readonly Lazy<QuizzBDD> LazyInstance = new Lazy<QuizzBDD> (() => new QuizzBDD ());    // Singleton
        Random rnd = new Random ();


        /* --- Constructeur --- */
        private QuizzBDD ()
        {
            bdd_entities = new bdd_quizzEntities ();
        }



        /* --- Methodes --- */
        

        /* Reponse Candidat */
        public void InsertReponseCandidat ( reponse_candidat prmRepCand )
        {
            bdd_entities.reponse_candidat.Add (prmRepCand);
        }


        /* Compte */
        public compte GetCompteByID ( int prmID )
        {
            return bdd_entities.compte.Find (prmID);
        }

        public void InsertCompte ( compte prmCompte )
        {
            bdd_entities.compte.Add (prmCompte);
        }

        public void DeleteCompte ( int compteID )
        {
            compte compteEntity = bdd_entities.compte.Find (compteID);
            bdd_entities.compte.Remove (compteEntity);
        }

        /* Complexite */
        /// <summary>
        /// La methode retourne une liste avec les taux recuperes dans la base
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        private List<int?> GetComplexiteByNom ( String prmNomComplexite )
        {
            List<int?> ListeRetour = new List<int?> ();

            var data = bdd_entities.taux_complexite
                    .Where (x => x.niveau == prmNomComplexite)
                    .Select (x => new
                    {
                        x.question_junior,
                        x.quest_confirme,
                        x.question_experimente
                    })
                    .ToList ();

            foreach ( var v in data )
            {
                ListeRetour.Add (v.question_junior);
                ListeRetour.Add (v.quest_confirme);
                ListeRetour.Add (v.question_experimente);
                Console.WriteLine ("GetComplexiteByNom fin foreach atteint");
            }

            return ListeRetour;
        }


        /// <summary>
        /// Retourne une liste avec tout les niveau de complexité trouvés
        /// </summary>
        /// <returns></returns>
        private List<String> GetAllNomComplexite ()
        {
            return bdd_entities.taux_complexite
                .Select (x => x.niveau)
                .ToList ();
        }


        /* Theme */
        /// <summary>
        /// Retourne l'id de la complexite ou le nom correspond (sensible a la casse)
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        private int GetIDThemeByNom ( String prmNomComplexite )
        {
            return bdd_entities.theme
            .Where (x => x.nom_theme == prmNomComplexite)
            .Single ().pk_theme;
        }        
    }
}
