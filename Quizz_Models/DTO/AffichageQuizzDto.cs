using System;
using System.Collections.Generic;
using System.Text;
using Quizz_Models.bdd_quizz;
namespace Quizz_Models.DTO
{
    class AffichageQuizzDto
    {


        CompteDTO Candidat { get; set; }
        CompteDTO recruteur { get; set; }
        QuizzDTO QuestionCandidat { get; set; }
        List<ReponseCandidatDTO> repCandidat { get; set; }
        List<ReponseCandidatDTO> repQuestion { get; set; }
        List<ReponseCandidatDTO> CommentaireCandidat{ get; set; }
        



    }
}
