using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;
using System;
using System.Collections.Generic;

namespace Quizz_Models.Services
{
    public class QuestionService
    {
        readonly ThemeRepository repoTheme;
        readonly ComplexiteRepository repoComplex;
        readonly QuestionRepository repoQuestion;
        readonly PropositionReponseRepository repoPropoReponse;

        public QuestionService(ThemeRepository prmRepoTheme, ComplexiteRepository prmRepoComplex, QuestionRepository prmRepoQuestion, PropositionReponseRepository prmRepoPropoReponse)
        {
            this.repoTheme = prmRepoTheme;
            this.repoComplex = prmRepoComplex;
            this.repoQuestion = prmRepoQuestion;
            this.repoPropoReponse = prmRepoPropoReponse;
        }


        /// <summary>
        /// Insertion d'un DTO dans la bdd & creation des naviagations
        /// </summary>
        /// <param name="prmDTO">DTO a inserer </param>
        /// <returns></returns>
        public int Insert(QuestionDTO prmDTO)
        {
            int nbLigneInsert;
            Question q = DTOConvert(prmDTO);

            repoQuestion.Insert(q);

            try
            {
                nbLigneInsert = repoQuestion.Sauvegarder();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                nbLigneInsert = -1;
            }

            return nbLigneInsert;
        }

        /// <summary>
        /// Retourne la liste des questions générées pour ce quizz.
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        public List<Question> GetListQuestionByIDQuizz(int idQuizz)
        {
            return repoQuestion.GetQuestionByIDQuizz(idQuizz);
        }

        /// <summary>
        /// Convertion de d'un DTO en objet
        /// </summary>
        /// <param name="prmDTO"></param>
        /// <returns></returns>
        public Question DTOConvert(QuestionDTO prmDTO)
        {
            TauxComplexite c = repoComplex.GetComplexiteByNom(prmDTO.NomComplexite);
            Theme t = repoTheme.GetThemeByNom(prmDTO.NomTheme);

            return new Question()
            {
                Enonce = prmDTO.Enonce,
                FkComplexite = c.PkComplexite,
                FkComplexiteNavigation = c,
                FkTheme = t.PkTheme,
                FkThemeNavigation = t,
                RepLibre = Convert.ToByte(prmDTO.RepLibre)
            };
        }

        /// <summary>
        /// La methode recupere les propositions de reponse possible pour la liste de question passée
        /// </summary>
        /// <param name="listQuestion"></param>
        public List<QuestionReponseDTO> AddReponseToQuestion(List<Question> prmListQuestion)
        {
            List<QuestionReponseDTO> listQRepDTO = new List<QuestionReponseDTO>();      // Liste des DTO contenant ls questions et leur reponses
            List<PropositionReponse> listeRep = new List<PropositionReponse>();         // Liste des reponses pour la question
            int i = 0;

            // Pour chaque questions de la liste passée
            foreach (Question q in prmListQuestion)
            {
                // Initialisationd du DTO pour cette question
                listQRepDTO.Add(new QuestionReponseDTO()
                {
                    Enonce = q.Enonce,
                    RepLibre = Convert.ToBoolean(q.RepLibre),
                    PKQuestion = q.PkQuestion
                });

                // Si ce n'est pas une question a réponse libre
                if (q.RepLibre == Convert.ToByte(false))
                {
                    // Ajouter a la liste des reponse dans le DTO les reponses recuperees pour cet ID
                    listeRep = repoPropoReponse.SelectReponseByIDQuestion(q.PkQuestion);
                    listQRepDTO[i].ListeReponses = listeRep;
                    i++;
                }
            }
            return listQRepDTO;
        }

        internal List<Question> GetListQuestionByCodeQuizz(string codeQuizz)
        {
            return repoQuestion.GetQuestionByCodeQuizz(codeQuizz);
        }
    }
}
