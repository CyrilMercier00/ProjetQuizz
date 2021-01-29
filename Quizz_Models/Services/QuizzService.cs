using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    public class QuizzService
    {
        ComplexiteRepository repoComplex;
        QuestionRepository repoQuest;
        QuizzRepository repoQuizz;

        public QuizzService () { }

        /// <summary>
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

                listTauxComplex = repoComplex.GetComplexiteByNom (prmComplex);                  // Recuperer une liste avec les 3 taux de complexité


                // Ajouter quizz dans la base
                repoQuizz.InsertQuizz (quizzCreation);
                Console.WriteLine ($"L'objet a été inséré avec les parametres: complexite = {quizzCreation.taux_complexite.niveau} et theme= {quizzCreation.theme.nom_theme}");

                listComplexite = repoComplex.GetAllNomComplexite ();                             // Recuperer tout les niveau de complexité possibles 

                // Generer 
                for ( int i = 0; i < listComplexite.Count (); i++ )
                {   // Calcul du nombre de question necessaire pour ce niveau de complexité
                    int nbQuest = (int) Math.Round (
                        prmNBQuestion /                                              // Nb question / % question
                        float.Parse ("0." + listTauxComplex[i].ToString ())          // Transformation du int en % (70 => 0.70)
                        );

                    repoQuest.GenererQuestions (listQuestionCreation, nbQuest, prmTheme, listComplexite[i]);
                    Console.WriteLine ($"{nbQuest} ont été générées pour la difficultée {listComplexite[i]}");
                }

                repoQuest.MAJManyToManyQuest (listQuestionCreation, quizzCreation);           // Relier les questions a la table quizz
                valRet = quizzCreation;
                //
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
            }
            return valRet;
        }

    }
}
