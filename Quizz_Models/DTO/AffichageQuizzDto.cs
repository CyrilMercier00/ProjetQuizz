using System;
using System.Collections.Generic;
using System.Text;
using Quizz_Models.bdd_quizz;
namespace Quizz_Models.DTO
{
    class AffichageQuizzDto
    {
        public AffichageQuizzDto()
        {
        }

       

        Compte candidat { get; set; }
        Compte recruteur { get; set; }
        Quizz quizz { get; set; }
        int nbRepOK{ get; set; }
        int nbQuest { get; set; }
        List<ReponseCandidatDTO> listeQuestions { get; set; }
        List<ReponseCandidatDTO> listeRepQuestion { get; set; }
        List<ReponseCandidatDTO> listeRepCandidat { get; set; }
        List<ReponseCandidatDTO> listeCommentaireCandidat { get; set; }
        



    }
}
