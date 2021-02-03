using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class CompteQuizz
    {
        public int FkCompte { get; set; }
        public int FkQuizz { get; set; }

        public virtual Compte FkCompteNavigation { get; set; }
        public virtual Quizz FkQuizzNavigation { get; set; }
    }
}
