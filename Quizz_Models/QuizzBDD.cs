using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models
{
    /*  
     *  Ajouter les methodes pour interagir avec la base ici et ne pas passer directement par le model.
     *  Il y a deja des methodes pour servir d'exemple
     */

    public sealed class QuizzBDD
    {
        /* --- Attributs --- */
        bdd_quizz_Entities bdd_entities;        // Reference aux entites de la bdd quizz
        static QuizzBDD bdd_instance { get { return LazyInstance.Value; } }       // Instance de cette classe 
        static readonly Lazy<QuizzBDD> LazyInstance = new Lazy<QuizzBDD> (() => new QuizzBDD ());    // Singleton



        /* --- Constructeur --- */
        private QuizzBDD ()
        {
            bdd_entities = new bdd_quizz_Entities ();
        }



        /* --- Methodes --- */



        /*  Questions  */
        public question GetQuestionByID ( int prmID )
        {
            return bdd_entities.question.Find (prmID);
        }

        public void InsertQuestion ( question prmQuestion )
        {
            bdd_entities.question.Add (prmQuestion);
        }



        /* Compte */
        public compte GetCompteByID ( int prmID )
        {
            return bdd_entities.compte.Find (prmID);
        }

        public void CreerCompte ( compte prmCompte )
        {
            bdd_entities.compte.Add (prmCompte);
        }
    }
}
