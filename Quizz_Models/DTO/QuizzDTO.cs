using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    public class QuizzDTO
    {
        int NbQuestions { get; set; } 
        TimeSpan Chrono { get; set; }
        String Theme { get; set; }
        String Complexite { get; set; }

    }
}
