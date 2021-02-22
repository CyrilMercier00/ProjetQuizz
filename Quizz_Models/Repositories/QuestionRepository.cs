using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Repositories
{
    public class QuestionRepository
    {
        private readonly bdd_quizzContext bdd_entities;
        private readonly ThemeRepository repoTheme;
        public QuestionRepository(bdd_quizzContext context, ThemeRepository repoTheme)
        {
            bdd_entities = context;
            this.repoTheme = repoTheme;
        }

        /// <summary>
        /// Retourne une question avec la PK passée
        /// </summary>
        /// <param name="prmID"></param>
        /// <returns></returns>
        public Question GetQuestionByID(int prmID)
        {
            return bdd_entities.Question.Find(prmID);

        }

        /// <summary>
        ///  Update d'une ou plusieurs questions
        /// </summary>
        /// <param name="prmListQuestion"></param>
        public void UpdateListQuestion(List<Question> prmListQuestion)
        {
            foreach (Question q in prmListQuestion)
            {
                bdd_entities.Update(q);
            }
            bdd_entities.SaveChanges();
        }

        /// <summary>
        /// Insertion dans la base.
        /// </summary>
        /// <param name="prmQuestion"></param>
        public void Insert(Question prmQuestion)
        {
            bdd_entities.Question.Add(prmQuestion);
        }

        /// <summary>
        /// Retourne les questions asociées au quizz avec l'id passé.
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <returns></returns>
        internal List<Question> GetQuestionByIDQuizz(int prmIDQuizz)
        {
            List<Question> listeRetour = new List<Question>();

            List<QuizzQuestion> listQuizzQuestion = bdd_entities.QuizzQuestion
                .Where(x => x.FkQuizz == prmIDQuizz)
                .ToList();

            bdd_entities.Question
                       .Intersect()
 
        }

        /// <summary>
        /// Sauvegarder les changements effectués.
        /// </summary>
        /// <returns></returns>
        public int Sauvegarder()
        {
            return bdd_entities.SaveChanges();
        }

        /// <summary>
        /// Selectionne des questions au hasard dans la base et les ajoute a liste passée.
        /// </summary>
        /// <param name="prmListQuestion">Lite dans laquelle les questions doivent être ajoutées</param>
        /// <param name="prmNBQuestions">Nombre de question a generer pour ces parametres</param>
        /// <param name="prmTheme">Nom du theme des questions (Sensible a la casse)</param>
        /// <param name="prmComplex">Nom du niveau de complexité. (Sensible a la casse)</param>
        public void GenererQuestions(List<Question> prmListQuestion, int prmNBQuestions, Theme prmTheme, Enum prmEnumComplex)
        {
            int idTheme = repoTheme.GetIDThemeByNom(prmTheme.NomTheme.ToString());

            // Recuperer le nombre de questions total pour ce theme & niv de complexite
            int nbQuestTotal = bdd_entities.Question
                .Where(x => x.FkTheme == idTheme && x.NvComplexite == prmEnumComplex.ToString())
                .Count();

            // Recuper un certain nombre de question pour ce theme & niv de complexite
            var data = bdd_entities.Question
                .Where(x => x.FkTheme == idTheme && x.NvComplexite == prmEnumComplex.ToString())
                .OrderBy(x => Guid.NewGuid())
                .Take(prmNBQuestions);

            foreach (Question q in data)
            {
                prmListQuestion.Add(q);
            }
        }

    }

}
