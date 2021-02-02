using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Theme
    {
        public Theme()
        {
            Question = new HashSet<Question>();
            Quizz = new HashSet<Quizz>();
        }

        public int PkTheme { get; set; }
        public string NomTheme { get; set; }

        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Quizz> Quizz { get; set; }
    }
}
