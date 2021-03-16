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
        //**************question et reponse et rep candidat
        /// <summary>
        /// Retourne la liste des questions générées pour ce quizz.
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        public List<Question> GetListReponseCandidatByIDQuizz(int idQuizz)
        {
            return repoQuestion.GetQuestionByIDQuizz(idQuizz);
        }
        /// <summary>
        /// Retourne la liste des questions générées pour ce quizz.
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        public List<Question> GetListSolutionQuestionByIDQuizz(int idQuizz)
        {
            return repoQuestion.GetQuestionByIDQuizz(idQuizz);
        }
       
        //*****************


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
            List<QuestionReponseDTO> listQuestRepDTO = new List<QuestionReponseDTO>();   // Liste des DTO contenant ls questions et leur reponses
            List<PropositionReponse> listReponse = new List<PropositionReponse>();       // Liste des reponses pour la question
            List<PropositionReponseDTO> listeRepDTO = new List<PropositionReponseDTO>(); // Liste des DTO de reponses pour la question 
            int i = 0;

            // Pour chaque questions de la liste passée
            foreach (Question q in prmListQuestion)
            {
                // Initialisationd du DTO pour cette question
                listQuestRepDTO.Add(new QuestionReponseDTO()
                {
                    Enonce = q.Enonce,
                    RepLibre = Convert.ToBoolean(q.RepLibre),
                    PKQuestion = q.PkQuestion
                });

                // Si ce n'est pas une question a réponse libre
                if (q.RepLibre == Convert.ToByte(false))
                {
                    // Ajouter les reponses pour cette question
                    listReponse = repoPropoReponse.SelectReponseByIDQuestion(q.PkQuestion);

                    // Convertion en DTO pour eviter l'auto-referencement
                    foreach (PropositionReponse pr in listReponse)
                    {
                        listQuestRepDTO[i].ListeReponses.Add(new PropositionReponseDTO()
                        {
                            PkReponse = pr.PkReponse,
                            Text = pr.Texte,
                            estBonne = Convert.ToBoolean(pr.EstBonne),
                            FkQuestion = pr.FkQuestion
                        });
                    }
                }
                i++;
            }
            return listQuestRepDTO;
        }

        //public List<QuestionReponseReponseCandidatDTO> AddReponseCandidatToQuestion(List<Question> prmListQuestion)
        //{
        //    // Liste des DTO contenant ls questions et leur reponses et la rep candidat
        //    List<QuestionReponseReponseCandidatDTO> listQuestRepRepCandidatDTO = new List<QuestionReponseReponseCandidatDTO>();
        //    // Liste des reponses pour la question
        //    List<PropositionReponse> listReponse = new List<PropositionReponse>();       
        //    int i = 0;


        //    // Pour chaque questions de la liste passée
        //    foreach (Question q in prmListQuestion)
        //    {
        //        // Initialisationd du DTO pour cette question
        //        listQuestRepRepCandidatDTO.Add(new QuestionReponseReponseCandidatDTO()
        //        {
        //            //Solution= q.,
        //            //Commentaire = q.,
        //            //FkCompte = q.,
        //            //FkQuestion = q.,

        //            // Enonce = q.Enonce,
        //            //RepLibre = Convert.ToBoolean(q.RepLibre),
        //            //PKQuestion = q.PkQuestion

        //        });

        //        // Si ce n'est pas une question a réponse libre
        //        if (q.RepLibre == Convert.ToByte(false))
        //        {
        //            // Ajouter les reponses pour cette question
        //            listReponse = repoPropoReponse.SelectReponseByIDQuestion(q.PkQuestion);

        //            // Convertion en DTO pour eviter l'auto-referencement
        //            foreach (PropositionReponse pr in listReponse)
        //            {
        //                listQuestRepRepCandidatDTO[i].ListeReponses.Add(new PropositionReponseDTO()
        //                {
        //                    PkReponse = pr.PkReponse,
        //                    Text = pr.Texte,
        //                    estBonne = Convert.ToBoolean(pr.EstBonne),
        //                    FkQuestion = pr.FkQuestion
        //                });
        //            }
        //        }
        //        i++;
        //    }

        //    return listQuestRepRepCandidatDTO;
        //}

        public List<Question> GetListQuestionByCodeQuizz(string codeQuizz)
        {
            return repoQuestion.GetQuestionByCodeQuizz(codeQuizz);
        }
    }
}
