using System;

namespace Quizz_Models.DTO
{
    public class QuestionDTO
    {
        public String Enonce { get; set; }
        public bool RepLibre { get; set; }
        public String FKComplexite { get; set; }
        public String FKTheme { get; set; }

    }
}
