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
        readonly ThemeRepository repoTheme = new ThemeRepository ();

        public QuizzService () { }

        /// <summary>
        /// La methode va generer un quizz avec un nombre de question donné et associé au theme.
        /// </summary>
        /// <param name="prmNBQuestion">Nombre de questions total a generer</param>
        /// <param name="prmComplex">Nom du niveau de complexité du quizz. Utilisé pour savoir combiens de questions doivent etre generer pour chaques diffucltés</param>
        /// <param name="prmTheme">Nom du theme du quizz et des questions</param>
        /// <param name="prmChrono">Le temps que le candidat aura pour passer le quizz</param>
        /// <returns>Retourne l'entitée du quizz généré ou null si il y a eu une erreur</returns>
        public void GenererQuizz ( int prmNBQuestion, String prmComplex, String prmTheme, TimeSpan prmChrono )
        {
            try
            {
                Quizz quizzCreation = new Quizz ();                             // Le nouveau quizz
                List<Question> listQuestionCreation = new List<Question> ();    // La liste des questions choisies

                // Ajouter des questions dans la liste des questions
                GenererQuestions (listQuestionCreation, prmNBQuestion, repoTheme.GetThemeByNom (prmTheme));

                // Ajouter quizz dans la base
                repoQuizz.InsertQuizz (quizzCreation);

                // Liaisons quiestion -> quizz
                foreach ( Question q in listQuestionCreation )      // Pour chaques questions
                {
                    QuizzQuestion qq = new QuizzQuestion            // Nouvel objet liaison
                    {
                        FkQuestion = q.PkQuestion,                  // PK de cette question
                        FkQuizz = quizzCreation.PkQuizz             // PK du quizz généré
                    };

                    q.QuizzQuestion.Add (qq);                       // Ajouter a la liste d'objet de liaisons
                }
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
            }
        }

        private void GenererQuestions ( List<Question> prmListQuestions, int prmNBQuestTotal, Theme prmThemeQuestions )
        {
            // Gen questions junior
            repoQuest.GenererQuestions (
                prmListQuestions,
                CalculerNombreQuestion (prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.junior),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.junior
            );

            // Gen questions confirmé
            repoQuest.GenererQuestions (
                prmListQuestions,
                CalculerNombreQuestion (prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.confirme),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.confirme
            );

            // Gen questions experimenté
            repoQuest.GenererQuestions (
                prmListQuestions,
                CalculerNombreQuestion (prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.experimenté),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.experimenté
            );
        }

        public void SupprimerQuizz ( int prmIDQuizz )
        {
            try
            {
                repoQuizz.SupprimerQuizz (repoQuizz.GetQuizzByID (prmIDQuizz));
            }
            catch ( Exception e )
            {
                Console.WriteLine (e.Message);
            }
        }

        /// <summary>
        /// Calcul le nombre de question de chaque niveau pour un taux de complexité du quizz defini
        /// </summary>
        /// <param name="prmNBQuestion"> nombre de question total du quizz</param>
        /// <param name="prmTauxComplexiteQuizz"> taux de complexité du quizz</param>
        /// <returns></returns>

        public int CalculerNombreQuestion ( int prmNBQuestionTotal, Enum prmNomComplex )
        {

            String complex = prmNomComplex.ToString ().ToLower ();


            var valRet = complex switch
            {
                "junior" => repoComplex.GetTauxComplexiteByNom (prmNomComplex.ToString ()).QuestionJunior.GetValueOrDefault (),
                "confirmé" => repoComplex.GetTauxComplexiteByNom (prmNomComplex.ToString ()).QuestionConfirme.GetValueOrDefault (),
                "experimenté" => repoComplex.GetTauxComplexiteByNom (prmNomComplex.ToString ()).QuestionExperimente.GetValueOrDefault (),
                _ => throw new Exception ("Le taux de complexitée n'existe pas"),
            };

            return (int) Math.Round (prmNBQuestionTotal * float.Parse ("0." + valRet.ToString ()));     // Total * 0. valeur dans la bdd
        }

    }
}
