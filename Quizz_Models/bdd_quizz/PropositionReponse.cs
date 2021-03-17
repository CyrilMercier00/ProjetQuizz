using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class PropositionReponse
    {
        public int PkReponse { get; set; }
        public string Texte { get; set; }
        public byte? EstBonne { get; set; }
        public TimeSpan? Chrono { get; set; }
        public int FkQuestion { get; set; }

        public virtual Question FkQuestionNavigation { get; set; }
    }
}
