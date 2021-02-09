using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
   public class Taux_complexiteDTO
    {
        public Taux_complexiteDTO(string niveau, int? question_junior, int? quest_confirme, int? question_experimente)
        {
         
            this.niveau = niveau;
            this.question_junior = question_junior;
            this.quest_confirme = quest_confirme;
            this.question_experimente = question_experimente;
        }

     
        public string niveau { get; set; }
        public Nullable<int> question_junior { get; set; }
        public Nullable<int> quest_confirme { get; set; }
        public Nullable<int> question_experimente { get; set; }
    }
}
