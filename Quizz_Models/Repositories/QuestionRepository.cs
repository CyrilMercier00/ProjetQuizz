using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class QuestionRepository
    {
        private readonly bdd_quizzContext bdd_entities;
        private readonly ThemeRepository repoTheme = new ThemeRepository ();
        public QuestionRepository () { }

        /*  Questions  */
        public Question GetQuestionByID ( int prmID )
        {
            return bdd_entities.Question.Find (prmID);

        }

        public void UpdateListQuestion (List<Question> prmListQuestion)
        {
            foreach (Question q in prmListQuestion)
            {
                bdd_entities.Update(q);
            }
            bdd_entities.SaveChanges();
        }

        public void InsertNouvelleQuestion ( Question prmQuestion )
        {
            bdd_entities.Question.Add (prmQuestion);
            bdd_entities.SaveChanges ();
        }
        /// <summary>
        /// Selectionne des questions au hasard dans la base et les ajoute a liste passée.
        /// </summary>
        /// <param name="prmListQuestion">Lite dans laquelle les questions doivent être ajoutées</param>
        /// <param name="prmNBQuestions">Nombre de question a generer pour ces parametres</param>
        /// <param name="prmTheme">Nom du theme des questions (Sensible a la casse)</param>
        /// <param name="prmComplex">Nom du niveau de complexité. (Sensible a la casse)</param>
        public void GenererQuestions ( List<Question> prmListQuestion, int prmNBQuestions, Theme prmTheme, Enum prmEnumComplex )
        {
            int idTheme = repoTheme.GetIDThemeByNom (prmTheme.NomTheme.ToString());

            // Recuperer le nombre de questions total pour ce theme & niv de complexite
            int nbQuestTotal = bdd_entities.Question
                .Where (x => x.FkTheme == idTheme && x.NvComplexite == prmEnumComplex.ToString ())
                .Count ();

            // Recuper un certain nombre de question pour ce theme & niv de complexite
            var data = bdd_entities.Question
                .Where (x => x.FkTheme == idTheme && x.NvComplexite == prmEnumComplex.ToString ())
                .OrderBy (x => Guid.NewGuid ())
                .Take (prmNBQuestions);

            foreach ( Question q in data )
            {
                prmListQuestion.Add (q);
            }
        }

    }

}
