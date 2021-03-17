/* --------------------------------------------------
  DTO Question et ses reponses possibles associées
 ------------------------------------------------- */
using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;



namespace Quizz_Models.DTO
{
    public class AffichageQuizzDto
    {
        public AffichageQuizzDto()
        {
            ListeReponses = new List<PropositionReponseDTO>();
            ListeReponsesCandidat = new List<ReponseCandidatDTO>();
            ListQuestionrepRepCDTO = new List<QuestionReponseReponseCandidatDTO>();
            
        }



        //***quizz**
        public int PkQuizz { get; set; }
        public int FKCompteRecruteur { get; set; }
        public int NbQuestions { get; set; }
      //  public String Chrono { get; set; }
        public String Theme { get; set; }
        public String Complexite { get; set; }
        public String Urlcode { get; set; }
        //************
        public int PKQuestion { get; set; }
        public String Enonce { get; set; }
        public bool RepLibre { get; set; }
        public String NomComplexite { get; set; }
        public String NomTheme { get; set; }
        
        public List<PropositionReponseDTO> ListeReponses { get; set; } = new List<PropositionReponseDTO>();
        public List<ReponseCandidatDTO> ListeReponsesCandidat { get; set; }
        public List<QuestionReponseReponseCandidatDTO> ListQuestionrepRepCDTO { get; set; } = new List<QuestionReponseReponseCandidatDTO>();
        public List<QuestionReponseDTO> ListQuestionrep { get; set; }
        public int nbRepOK { get; set; }
        

    }
}
