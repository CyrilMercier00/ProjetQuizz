using System;

namespace Quizz_Models.DTO
{
    public class QuestionDTO
    {
        public String Enonce { get; set; }
        public bool RepLibre { get; set; }
        public int FKComplexite { get; set; }
        public int FKTheme { get; set; }

    }
}
