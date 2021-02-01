using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Quizz
    {
        public Quizz()
        {
            CompteQuizz = new HashSet<CompteQuizz>();
            QuizzQuestion = new HashSet<QuizzQuestion>();
        }

        public int PkQuizz { get; set; }
        public TimeSpan? Chrono { get; set; }
        public int FkTheme { get; set; }
        public int FkComplexite { get; set; }

        public virtual TauxComplexite FkComplexiteNavigation { get; set; }
        public virtual Theme FkThemeNavigation { get; set; }
        public virtual ICollection<CompteQuizz> CompteQuizz { get; set; }
        public virtual ICollection<QuizzQuestion> QuizzQuestion { get; set; }
    }
}
