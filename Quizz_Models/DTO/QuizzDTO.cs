using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    public class QuizzDTO
    {
        int nbQuestions { get; set; } 
        TimeSpan chrono { get; set; }
        String theme { get; set; }
        String complexite { get; set; }

    }
}
