using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    class Taux_complexiteDTO
    {
        public int pk_complexite { get; set; }
        public string niveau { get; set; }
        public Nullable<int> question_junior { get; set; }
        public Nullable<int> quest_confirme { get; set; }
        public Nullable<int> question_experimente { get; set; }
    }
}
