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
        readonly ReponseCandidatRepository _repoReponseCandidat;
        readonly QuestionRepository _questionRepository;

        public QuestionService(QuestionRepository questionRepository, ReponseCandidatRepository repoReponseCandidat, ThemeRepository prmRepoTheme, ComplexiteRepository prmRepoComplex, QuestionRepository prmRepoQuestion, PropositionReponseRepository prmRepoPropoReponse)
        {
            this.repoTheme = prmRepoTheme;
            this.repoComplex = prmRepoComplex;
            this.repoQuestion = prmRepoQuestion;
            this.repoPropoReponse = prmRepoPropoReponse;

            this._repoReponseCandidat = repoReponseCandidat;
            this._questionRepository = questionRepository;
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
        /// Retourne la liste des rep candidat générées pour ce quizz.
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        public List<PropositionReponse> GetListPropositionReponseByIDQuizz(int idQuizz)
        {
            return repoQuestion.GetListPropositionReponseByIDQuizz(idQuizz);
        }
        //**************question et reponse et rep candidat
        /// <summary>
        /// Retourne la liste des rep candidat générées pour ce quizz.
        /// </summary>
        /// <param name="idQuizz"></param>
        /// <returns></returns>
        public List<ReponseCandidat> GetListReponseCandidatByIDQuizz(int idQuizz)
        {
            return repoQuestion.GetListReponseCandidatByIDQuizz(idQuizz);
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
        /// <summary>
        /// La methode recupere les propositions de reponse possible pour la liste de question passée+ rep candidat
        /// </summary>
        /// <param name="listQuestion"></param>
        public List<QuestionReponseReponseCandidatDTO> AddReponseCandidatToQuestion(List<Question> prmListQuestion, int idQuizz)
        {
            List<QuestionReponseReponseCandidatDTO> listQuestRepDTO = new List<QuestionReponseReponseCandidatDTO>();   // Liste des DTO contenant ls questions et leur reponses
            List<PropositionReponse> listReponse = new List<PropositionReponse>();       // Liste des reponses pour la question
            List<PropositionReponseDTO> listeRepDTO = new List<PropositionReponseDTO>(); // Liste des DTO de reponses pour la question 

            //candidat
            List<ReponseCandidat> listReponsecandidat = new List<ReponseCandidat>();       // Liste des reponses pour la question
            List<ReponseCandidatDTO> listeRepcandidatDTO = new List<ReponseCandidatDTO>(); // Liste des DTO de reponses pour la question 


            int i = 0;
            int nbtrue=0;
            // Pour chaque questions de la liste passée
            foreach (Question q in prmListQuestion)
            {
                ReponseCandidat repC = this._questionRepository.GetReponseCandidatByIDQuestion(q.PkQuestion);
                ReponseCandidatDTO repCDto;
                if (repC is null)
                {
                    repCDto = null;
                }
                else
                {
                    repCDto = this._repoReponseCandidat.TransformRepCandidatEnRepCandidatDto(repC);
                   // if (repCDto.isTrue is true) { nbtrue++; }
                }

                // Initialisationd du DTO pour cette question
                listQuestRepDTO.Add(new QuestionReponseReponseCandidatDTO()
                {
                    Enonce = q.Enonce,
                    RepLibre = Convert.ToBoolean(q.RepLibre),
                    PKQuestion = q.PkQuestion,
                    RepCandidat = repCDto
                    

                }) ;


                // Si ce n'est pas une question a réponse libre
                if (q.RepLibre == Convert.ToByte(false))
                {
                    // Ajouter les reponses pour cette question
                    listReponse = repoPropoReponse.SelectReponseByIDQuestion(q.PkQuestion);
                    listReponsecandidat = this._repoReponseCandidat.SelectReponseCandidatByIDQuestion(q.PkQuestion);
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
        //TransformRepCandidatEnRepCandidatDto(ReponseCandidat reponseCandidat)
        //public int GetNbbnReptrue(List<ReponseCandidatDTO> LrepDto)
        //{

        //    int nbBQuestok = 0;
        //    try
        //    { foreach(ReponseCandidatDTO rCDTO in LrepDto )
        //                if (rCDTO is null)
        //                {
        //                }
        //                else if (rCDTO.isTrue)
        //                {
        //                    nbBQuestok++;
        //                }
        //                else
        //                {

        //                }


                    
                
        //    }
        //    catch
        //    {
        //        nbBQuestok = 0;
        //    }


        //    return nbBQuestok;
        //}


        public int GetNbbnRep(List<ReponseCandidat> LreponseCandidat)
        {

           
           
            int nbBQuestok = 0;
            try
            {
                foreach (ReponseCandidat rC in LreponseCandidat)
                {
                    
              
                    if (LreponseCandidat.Count > 0)
                    {
                         ReponseCandidatDTO repDto=_repoReponseCandidat.TransformRepCandidatEnRepCandidatDto(rC);
                       
                            if (rC is null)
                            {
                            }
                            else if (repDto.isTrue)
                            {
                                nbBQuestok++;
                            }
                            else
                            {
                               
                            }

                        
                    }
                }
            }
            catch
            {
                nbBQuestok = 0;
            }


            return nbBQuestok;
        }
        public int GetNbpropRep(List<PropositionReponse> listRepCand)
        {

            int nbBQuestok = 0;
            try
            {
                if (listRepCand.Count > 0) {
                    foreach (PropositionReponse l in listRepCand)
                    {
                        if (l is null)
                        {
                        }
                        else if (l.EstBonne is 0)
                        {
                            nbBQuestok++;
                        }
                        else 
                        {
                            nbBQuestok = 0;
                        }

                    }
                }
            }
            catch
            {
                nbBQuestok=0;
            }


            return nbBQuestok;
        }

        public List<Question> GetListQuestionByCodeQuizz(string codeQuizz)
        {
            return repoQuestion.GetQuestionByCodeQuizz(codeQuizz);
        }
    }
}
