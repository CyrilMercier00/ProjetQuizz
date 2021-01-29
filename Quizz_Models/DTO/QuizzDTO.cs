using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    public class QuizzDTO
    {
        public int nbQuestions { get; set; }
        public TimeSpan chrono { get; set; }
        public String theme { get; set; }
        public String complexite { get; set; }

    }
}
