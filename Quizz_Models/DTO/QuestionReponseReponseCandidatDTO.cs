/* --------------------------------------------------
  DTO Question et ses reponses possibles associées et rep candidat
 ------------------------------------------------- */
using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;

namespace Quizz_Models.DTO
{
    public class QuestionReponseReponseCandidatDTO
    {
        public QuestionReponseReponseCandidatDTO()
        {
            ListeReponses = new List<PropositionReponseDTO>();
        }
        public String Solution { get; set; }
       
        public int PKQuestion { get; set; }

        public int nbRepTRue { get; set; }
        public String Enonce { get; set; }
        public bool RepLibre { get; set; }
        public String NomComplexite { get; set; }
        public String NomTheme { get; set; }

        public ReponseCandidatDTO RepCandidat { get; set; }//fk question et fkcompte



        public List<PropositionReponseDTO> ListeReponses { get; set; } = new List<PropositionReponseDTO>();
        //public List<ReponseCandidatDTO> ListReponsecandidat { get; set; } = new List<ReponseCandidatDTO>();
    }
}
