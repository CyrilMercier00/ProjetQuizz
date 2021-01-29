using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    public class QuizzDTO
    {
        public int pk_quizz { get; set; }
        public Nullable<System.TimeSpan> chrono { get; set; }
        public int fk_theme { get; set; }
        public int fk_complexite { get; set; }
    }
}
