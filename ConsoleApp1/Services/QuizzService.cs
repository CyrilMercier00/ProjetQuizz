using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class QuizzService
    {
        readonly ComplexiteRepository repoComplex = new ComplexiteRepository ();
        readonly QuestionRepository repoQuest = new QuestionRepository ();
        readonly QuizzRepository repoQuizz = new QuizzRepository ();

        public QuizzService () { }

        /// <summary>
        /// La methode va generer un quizz avec un nombre de question donné et associé au theme.
        /// </summary>
        /// <param name="prmNBQuestion">Nombre de questions total a generer</param>
        /// <param name="prmComplex">Nom du niveau de complexité du quizz. Utilisé pour savoir combiens de questions doivent etre generer pour chaques diffucltés</param>
        /// <param name="prmTheme">Nom du theme du quizz et des questions</param>
        /// <param name="prmChrono">Le temps que le candidat aura pour passer le quizz</param>
        /// <returns>Retourne l'entitée du quizz généré ou null si il y a eu une erreur</returns>
        public Quizz GenererQuizz ( int prmNBQuestion, String prmComplex, String prmTheme, TimeSpan prmChrono )
        {
            Quizz valRet = null;
            try
            {
                Quizz quizzCreation = new Quizz ();         // Le nouveau quizz
                List<Question> listQuestionCreation = new List<Question> ();    // La liste des questions choisies
                List<String> listComplexite;                // Contient tout les nom des taux de compléxité
                List<int?> listTauxComplex;                 // Contient les taux de complexité pour le niveau demandé

                listTauxComplex = repoComplex.GetComplexiteByNom (prmComplex);                  // Recuperer une liste avec les 3 taux de complexité


                // Ajouter quizz dans la base
                repoQuizz.InsertQuizz (quizzCreation);
                Console.WriteLine ($"L'objet a été inséré avec les parametres: complexite = {quizzCreation.FkComplexiteNavigation.Niveau} et theme= {quizzCreation.FkThemeNavigation.NomTheme}");

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

                    foreach (Question q in listQuestionCreation)        // Pour chaques questions
                    {
                        QuizzQuestion qq =  new QuizzQuestion ();       // Nouvel liaison

                        qq.FkQuestion = q.PkQuestion;                   // PK de cette question
                        qq.FkQuizz = quizzCreation.PkQuizz;             // PK du quizz généré

                        q.QuizzQuestion.Add(qq);                        // Ajouter a la liste des liaisons
                    }
                    
                }   
                valRet = quizzCreation;                                 // Retourner le quizz créer
            }   
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
            }
            return valRet;
        }

    }
}
