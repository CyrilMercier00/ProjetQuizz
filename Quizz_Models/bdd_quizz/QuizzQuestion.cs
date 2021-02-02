using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class QuizzQuestion
    {
        public int FkQuizz { get; set; }
        public int FkQuestion { get; set; }

        public virtual Question FkQuestionNavigation { get; set; }
        public virtual Quizz FkQuizzNavigation { get; set; }
    }
}
