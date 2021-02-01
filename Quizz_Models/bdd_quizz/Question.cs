using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Question
    {
        public Question()
        {
            PropositionReponse = new HashSet<PropositionReponse>();
            QuizzQuestion = new HashSet<QuizzQuestion>();
            ReponseCandidat = new HashSet<ReponseCandidat>();
        }

        public int PkQuestion { get; set; }
        public string NvComplexite { get; set; }
        public string Enonce { get; set; }
        public byte? ARepondu { get; set; }
        public int FkTheme { get; set; }
        public int FkComplexite { get; set; }

        public virtual TauxComplexite FkComplexiteNavigation { get; set; }
        public virtual Theme FkThemeNavigation { get; set; }
        public virtual ICollection<PropositionReponse> PropositionReponse { get; set; }
        public virtual ICollection<QuizzQuestion> QuizzQuestion { get; set; }
        public virtual ICollection<ReponseCandidat> ReponseCandidat { get; set; }
    }
}
