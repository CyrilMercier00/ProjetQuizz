namespace Quizz_Models.Services
{
    public class QuestionRepository
    {

        public QuestionRepository ()
        {

        }


        /*  Questions  */
        public question GetQuestionByID(int prmID)
        {
            return bdd_entities.question.Find(prmID);
        }

        public void InsertNouvelleQuestion(question prmQuestion)
        {
            bdd_entities.question.Add(prmQuestion);
        }
        /// <summary>
        /// Selectionne des questions au hasard dans la base et les ajoute a liste passée.
        /// </summary>
        /// <param name="prmListQuestion">Lite dans laquelle les questions doivent être ajoutées</param>
        /// <param name="prmNBQuestions">Nombre de question a generer pour ces parametres</param>
        /// <param name="prmTheme">Nom du theme des questions (Sensible a la casse)</param>
        /// <param name="prmComplex">Nom du niveau de complexité. (Sensible a la casse)</param>
        private void GenererQuestions(List<question> prmListQuestion, int prmNBQuestions, String prmTheme, String prmComplex)
        {
            int idTheme = GetIDThemeByNom(prmTheme);

            int i = 0;
            // Recuperer le nombre de questions total pour ce theme & niv de complexite
            int nbQuestTotal = bdd_entities.question
                .Where(x => x.fk_theme == idTheme && x.nv_complexite == prmComplex)
                .Count();

            // Recuper un certain nombre de question pour ce theme & niv de complexite
            var data = bdd_entities.question
                .Where(x => x.fk_theme == idTheme && x.nv_complexite == prmComplex)
                .OrderBy(x => Guid.NewGuid())
                .Take(prmNBQuestions);

            i++;

            foreach (question q in data)
            {
                prmListQuestion.Add(q);
            }
        }


        /// <summary>
        /// Prend fait la liaison entre la table quizz et les questions rentrées
        /// </summary>
        /// <param name="prmListQuestion"></param>
        /// <param name="prmQuizz"></param>
        private void MAJManyToManyQuest(List<question> prmListQuestion, quizz prmQuizz)
        {
            foreach (question q in prmListQuestion)
            {
                bdd_entities.Entry(q)
                .Collection(x => x.quizz).Load();
                q.quizz.Add(prmQuizz);
                bdd_entities.SaveChanges();
            }

        }

    }