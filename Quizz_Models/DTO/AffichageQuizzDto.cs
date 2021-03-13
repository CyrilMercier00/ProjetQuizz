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
            nbRepOK = 0;
        }

       

        //Compte candidat { get; set; }
        //Compte recruteur { get; set; }
        //Quizz quizz { get; set; }
        public int nbRepOK{ get; set; }
        //int nbQuest { get; set; }
        //List<ReponseCandidatDTO> listeQuestions { get; set; }
        //List<ReponseCandidatDTO> listeRepQuestion { get; set; }
        //List<ReponseCandidatDTO> listeRepCandidat { get; set; }
        //List<ReponseCandidatDTO> listeCommentaireCandidat { get; set; }


        public int PKQuestion { get; set; }
        public String Enonce { get; set; }
        public bool RepLibre { get; set; }
        public String NomComplexite { get; set; }
        public String NomTheme { get; set; }
        int nbQuest { get; set; }
        public List<PropositionReponseDTO> ListeReponses { get; set; } = new List<PropositionReponseDTO>();


    }
}
