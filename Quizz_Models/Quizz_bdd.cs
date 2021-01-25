//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Quizz_Models
//{
//    public sealed class Quizz_bdd
//    {
//        /* --- Attributs --- */
//        bdd_quizz_Entities bdd_entities;        // Reference aux entites de la bdd quizz
//        static Quizz_bdd bdd_instance { get { return LazyInstance.Value;  } }       // Instance de cette classe 
//        static readonly Lazy<Quizz_bdd> LazyInstance = new Lazy<Quizz_bdd> (() => new Quizz_bdd ());    // Singleton



//        /* --- Constructeur --- */
//        private Quizz_bdd ()
//        {
//             bdd_entities = new bdd_quizz_Entities();
//        }



//        /* --- Methodes --- */
//        public compte GetCompteByID ( int prmID )
//        {
//            return bdd_entities.compte.Find (prmID);
//        }

//        public void CreerCompte(compte prmCompte)
//        {
//            bdd_entities.compte.Add (prmCompte);
//        }
//    }
//}
