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
        /*  Questions  */
        public question GetQuestionByID ( int prmID )
        {
            return bdd_entities.question.Find (prmID);
        }

        public void InsertNouvelleQuestion ( question prmQuestion )
        {
            bdd_entities.question.Add (prmQuestion);
        }
        /// <summary>
        /// Selectionne des questions au hasard dans la base et les ajoute a liste passée.
        /// </summary>
        /// <param name="prmListQuestion">Lite dans laquelle les questions doivent être ajoutées</param>
        /// <param name="prmNBQuestions">Nombre de question a generer pour ces parametres</param>
        /// <param name="prmTheme">Nom du theme des questions (Sensible a la casse)</param>
        /// <param name="prmComplex">Nom du niveau de complexité. (Sensible a la casse)</param>
        private void GenererQuestions ( List<question> prmListQuestion, int prmNBQuestions, String prmTheme, String prmComplex )
        {
            int idTheme = GetIDThemeByNom (prmTheme);

            int i = 0;
            // Recuperer le nombre de questions total pour ce theme & niv de complexite
            int nbQuestTotal = bdd_entities.question
                .Where (x => x.fk_theme == idTheme && x.nv_complexite == prmComplex)
                .Count ();

            // Recuper un certain nombre de question pour ce theme & niv de complexite
            var data = bdd_entities.question
                .Where (x => x.fk_theme == idTheme && x.nv_complexite == prmComplex)
                .OrderBy (x => Guid.NewGuid ())
                .Take (prmNBQuestions);

            i++;

            foreach ( question q in data )
            {
                prmListQuestion.Add (q);
            }
        }


        /// <summary>
        /// Prend fait la liaison entre la table quizz et les questions rentrées
        /// </summary>
        /// <param name="prmListQuestion"></param>
        /// <param name="prmQuizz"></param>
        private void MAJManyToManyQuest ( List<question> prmListQuestion, quizz prmQuizz )
        {
            foreach ( question q in prmListQuestion )
            {
                bdd_entities.Entry (q)
                .Collection (x => x.quizz).Load ();
                q.quizz.Add (prmQuizz);
                bdd_entities.SaveChanges ();
            }

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


        /* Quizz */
        ///        /// <summary>
        /// La methode va generer un quizz avec un nombre de question donné et associé au theme.
        /// </summary>
        /// <param name="prmNBQuestion">Nombre de questions total a generer</param>
        /// <param name="prmComplex">Nom du niveau de complexité du quizz. Utilisé pour savoir combiens de questions doivent etre generer pour chaques diffucltés</param>
        /// <param name="prmTheme">Nom du theme du quizz et des questions</param>
        /// <param name="prmChrono">Le temps que le candidat aura pour passer le quizz</param>
        /// <returns>Retourne l'entitée du quizz généré ou null si il y a eu une erreur</returns>
        public quizz GenererQuizz ( int prmNBQuestion, String prmComplex, String prmTheme, TimeSpan prmChrono )
        {
            quizz valRet = null;
            try
            {
                quizz quizzCreation = new quizz ();         // Le nouveau quizz
                List<question> listQuestionCreation = new List<question> ();    // La liste des questions choisies
                List<String> listComplexite;                // Contient tout les nom des taux de compléxité
                List<int?> listTauxComplex;                 // Contient les taux de complexité pour le niveau demandé

                listTauxComplex = GetComplexiteByNom (prmComplex);                  // Recuperer une liste avec les 3 taux de complexité


                // Ajouter quizz dans la base
                bdd_entities.quizz.Add (quizzCreation);
                Console.WriteLine ($"L'objet a été inséré avec les parametres: complexite = {quizzCreation.taux_complexite.niveau} et theme= {quizzCreation.theme.nom_theme}");

                listComplexite = GetAllNomComplexite ();                             // Recuperer tout les niveau de complexité possibles 

                // Generer 
                for ( int i = 0; i < listComplexite.Count (); i++ )
                {   // Calcul du nombre de question necessaire pour ce niveau de complexité
                    int nbQuest = (int) Math.Round (
                        prmNBQuestion /                                              // Nb question / % question
                        float.Parse ("0." + listTauxComplex[i].ToString ())          // Transformation du int en % (70 => 0.70)
                        );

                    GenererQuestions (listQuestionCreation, nbQuest, prmTheme, listComplexite[i]);
                    Console.WriteLine ($"{nbQuest} ont été générées pour la difficultée {listComplexite[i]}");
                }

                MAJManyToManyQuest (listQuestionCreation, quizzCreation);           // Relier les questions a la table quizz
                valRet = quizzCreation;
                // 
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
            }
            return valRet;
        }

        /// <summary>
        /// Méthode qui insère une permission.
        /// </summary>
        /// <param name="permissionEntity">Entité de la permission</param>
        public void InsertPermission ( permission permissionEntity )
        {
            bdd_entities.permission.Add (permissionEntity);
        }

        /// <summary>
        /// Méthode qui cherche une permission par ses différentes valeurs.
        /// </summary>
        /// <param name="permissionEntity">Entité de la permission</param>
        /// <returns>Retourne la permission trouvée ou lance une exception si aucune n'a été trouvée.</returns>
        public permission FindPermissionByValues ( permission permissionEntity )
        {
            return bdd_entities.permission
                    .Where (x => x.ajouter_quest == permissionEntity.ajouter_quest
                         && x.generer_quizz == permissionEntity.generer_quizz
                         && x.modifier_quest == permissionEntity.modifier_quest
                         && x.suppr_question == permissionEntity.suppr_question)
                    .Single ();
        }
    }
}
