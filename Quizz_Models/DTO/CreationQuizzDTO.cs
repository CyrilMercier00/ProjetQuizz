using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    public class CreationQuizzDTO
    {
        public int FKCompteRecruteur { get; set; }
        public int NbQuestions { get; set; }
        public String Theme { get; set; }
        public String Complexite { get; set; }
    }
}
