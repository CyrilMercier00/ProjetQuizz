/* --------------------------------------------------
  DTO Question et ses reponses possibles associées
 ------------------------------------------------- */
using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;

namespace Quizz_Models.DTO
{
    public class QuestionReponseDTO
    {
        public int PKQuestion { get; set; }
        public String Enonce { get; set; }
        public bool RepLibre { get; set; }
        public String NomComplexite { get; set; }
        public String NomTheme { get; set; }
        public List<PropositionReponseDTO> ListeReponses { get; set; } = new List<PropositionReponseDTO>();
    }
}
