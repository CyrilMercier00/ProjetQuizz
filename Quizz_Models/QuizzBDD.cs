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
        bdd_quizzEntities bdd_entities;        // Reference aux entites de la bdd quizz generees par entity framework
        public static QuizzBDD bdd_instance { get { return LazyInstance.Value; } }       // Instance de cette classe 
        static readonly Lazy<QuizzBDD> LazyInstance = new Lazy<QuizzBDD> (() => new QuizzBDD ());    // Singleton



        /* --- Constructeur --- */
        private QuizzBDD ()
        {
            bdd_entities = new bdd_quizzEntities ();
        }



        /* --- Methodes --- */
        /*  Questions  */
        public question GetQuestionByID ( int prmID )
        {
            return bdd_entities.question.Find (prmID);
        }

        public void InsertNouvelleQuestion ( question prmQuestion )
        {
            bdd_entities.question.Add (prmQuestion);
        }

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

        /* Complexite */
        private int GetComplexiteByNom ( String prmNomComplexite )
        {
            return bdd_entities.taux_complexite
                     .Where (x => x.niveau == prmNomComplexite)
                     .Single ().pk_complexite;
        }
        /* Theme */
        private int GetThemeByNom ( String prmNomComplexite )
        {
            // Recuperer la cle primaire ou le nom correspond a celui rentré en parametre
            return bdd_entities.theme
            .Where (x => x.nom_theme == prmNomComplexite)
            .Single ().pk_theme;
        }

        /* Quizz */
        public void InsertQuizz ( int prmNBQuestion, String prmComplex, String prmTheme, TimeSpan prmChrono )
        {
            quizz quizzCreation = new quizz ();
            List<question> listQuestionCreation = new List<question> ();
            int? idComplex = null;
            int? idTheme = null;

            // todo
            // Get id complex avec le nom
            // Get id theme evec le nom
            // Inserer le quizz avec les fk recuperees
            // lier 30 questions au quizz

            try
            {
                // Recuperer la cle primaire ou le nom correspond a celui rentré en parametre
                idComplex = GetComplexiteByNom (prmComplex);

                if ( idComplex != null )
                {

                    if ( idTheme != null )
                    {   // Ajouter quizz dans la base puis recuperer 30 questions au hasard
                        bdd_entities.quizz.Add (quizzCreation);
                        Console.WriteLine ($"L'objet a été inséré avec les parametres: complexite = {quizzCreation.taux_complexite.niveau} et theme= {quizzCreation.theme.nom_theme}");

                        for ( int i = 0; i < prmNBQuestion; i++ )
                        {

                        }
                    }
                    else
                    {
                        throw new Exception ("Erreur lors de la recuperation de l'id du theme.");
                    }
                }
                else
                {
                    throw new Exception ("Erreur lors de la recuperation de l'id du niveau de complexité.");
                }





            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
            }

        }
    }
}
