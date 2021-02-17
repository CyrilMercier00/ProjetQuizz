using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class ServiceQuizz
    {
        readonly ComplexiteRepository repoComplex = new ComplexiteRepository();
        readonly QuestionRepository repoQuest = new QuestionRepository();
        readonly QuizzRepository repoQuizz = new QuizzRepository();
        readonly ThemeRepository repoTheme = new ThemeRepository();

        public ServiceQuizz() { }

        public Quizz FindByID(int prmIDQuizz)
        {
            return repoQuizz.GetQuizzByID(prmIDQuizz);
        }

        /// <summary>
        /// La methode va generer un quizz avec un nombre de question donné et associé au theme.
        /// </summary>
        /// <param name="prmNBQuestion">Nombre de questions total a generer</param>
        /// <param name="prmComplex">Nom du niveau de complexité du quizz. Utilisé pour savoir combiens de questions doivent etre generer pour chaques diffucltés</param>
        /// <param name="prmTheme">Nom du theme du quizz et des questions</param>
        /// <param name="prmChrono">Le temps que le candidat aura pour passer le quizz</param>
        /// /// <param name="prmUrlCode">Le code unique associer au quizz dans l'url</param>
        /// <returns>Retourne l'entitée du quizz généré ou null si il y a eu une erreur</returns>
        public void GenererQuizz ( QuizzDTO prmDTO )
        {
            try
            {
                Theme leTheme = repoTheme.GetThemeByNom (prmDTO.Theme);                             // Objet theme pour ce param
                TauxComplexite leTaux = repoComplex.GetComplexiteByNom (prmDTO.Complexite);         // Objet taux de complexite pour ce param
                List<Question> listQuestionCreation = new List<Question> ();                        // La liste des questions choisies
                String leCodeUrl = Utils.GenerateUrl.GenerateCodeUrl();                             // genere un code unique pour l'url

                // Le nouveau quizz
                Quizz quizzCreation = new Quizz()
                {
                    FkTheme = leTheme.PkTheme,
                    FkComplexite = leTaux.PkComplexite,
                    Chrono = TimeSpan.Parse(prmDTO.Chrono),
                    Urlcode = prmDTO.Urlcode
                };

                //Ajouter code Unique pour l'url du Quizz
                prmDTO.Urlcode = leCodeUrl;
                // Ajouter des questions dans la liste des questions
                GenererQuestions (listQuestionCreation, prmDTO.NbQuestions, leTheme);
               
                // Ajouter quizz dans la base
                repoQuizz.InsertQuizz(quizzCreation);

                // Liaisons compte -> quizz
                new CompteQuizz
                {
                    FkCompte = prmDTO.PKCompte,
                    FkQuizz = quizzCreation.PkQuizz
                };

                // Liaisons question -> quizz
            foreach (Question q in listQuestionCreation)      // Pour chaques questions
                {
                    QuizzQuestion qq = new QuizzQuestion            // Nouvel objet liaison
                    {
                        FkQuestionNavigation = q,                   // PK de cette question
                        FkQuizzNavigation = quizzCreation           // PK du quizz généré
                    };

                    q.QuizzQuestion.Add(qq);                       // Ajouter a la liste d'objet de liaisons
                }
                repoQuest.UpdateListQuestion(listQuestionCreation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void GenererQuestions(List<Question> prmListQuestions, int prmNBQuestTotal, Theme prmThemeQuestions)
        {
            // Gen questions junior
            repoQuest.GenererQuestions(
                prmListQuestions,
                CalculerNombreQuestion(prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.junior),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.junior
            );

            // Gen questions confirmé
            repoQuest.GenererQuestions(
                prmListQuestions,
                CalculerNombreQuestion(prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.confirme),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.confirme
            );

            // Gen questions experimenté
            repoQuest.GenererQuestions(
                prmListQuestions,
                CalculerNombreQuestion(prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.experimente),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.experimente
            );
        }

        public void SupprimerQuizz(int prmIDQuizz)
        {
            try
            {
                repoQuizz.SupprimerQuizz(repoQuizz.GetQuizzByID(prmIDQuizz));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Calcul le nombre de question de chaque niveau pour un taux de complexité du quizz defini
        /// </summary>
        /// <param name="prmNBQuestion"> nombre de question total du quizz</param>
        /// <param name="prmTauxComplexiteQuizz"> taux de complexité du quizz</param>
        /// <returns></returns>

        private int CalculerNombreQuestion ( int prmNBQuestionTotal, Enum prmNomComplex )
        {

            String complex = prmNomComplex.ToString().ToLower();


            var valRet = complex switch
            {
                "junior" => repoComplex.GetComplexiteByNom (prmNomComplex.ToString ()).QuestionJunior.GetValueOrDefault (),
                "confirme" => repoComplex.GetComplexiteByNom(prmNomComplex.ToString ()).QuestionConfirme.GetValueOrDefault (),
                "experimente" => repoComplex.GetComplexiteByNom(prmNomComplex.ToString ()).QuestionExperimente.GetValueOrDefault (),
                _ => throw new Exception ("Le taux de complexitée n'existe pas"),
            };

            String s1 = prmNBQuestionTotal.ToString();
            String s2 = "0." + valRet.ToString();
            float n1 = float.Parse(s1);
            float n2 = float.Parse(s2.Replace(".", ","));
            return (int)Math.Round(n1 * n2);
        }

        /// <summary>
        /// Retourne toutes les permissions de la bdd.
        /// </summary>
        /// <returns>Liste de toute les permissions sous format PermissionDTO.</returns>
        public QuizzDTO GetQuizz(int prmIDQuizz)
        {
            Quizz quizz  = this.repoQuizz.GetQuizzByID(prmIDQuizz);

            return TransformQuizzToQuizzDTO(quizz);
        }

        private QuizzDTO TransformQuizzToQuizzDTO(Quizz quizz)
        {
            return new QuizzDTO
            {
               
                NbQuestions = quizz.PkQuizz,
                Chrono = Convert.ToString(quizz.Chrono),
                Theme = Convert.ToString(quizz.FkTheme),
                Complexite = Convert.ToString(quizz.FkComplexite),
                Urlcode = quizz.Urlcode

            };
         }
    }
}
