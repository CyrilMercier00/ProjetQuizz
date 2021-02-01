using System;

namespace Quizz_Models.DTO
{
    public class QuizzDTO
    {
        public int NbQuestions { get; set; }
        public TimeSpan Chrono { get; set; }
        public String Theme { get; set; }
        public String Complexite { get; set; }

    }
}
