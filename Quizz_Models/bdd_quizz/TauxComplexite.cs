using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class TauxComplexite
    {
        public TauxComplexite()
        {
            Question = new HashSet<Question>();
            Quizz = new HashSet<Quizz>();
        }

        public int PkComplexite { get; set; }
        public string Niveau { get; set; }
        public int? QuestionJunior { get; set; }
        public int? QuestConfirme { get; set; }
        public int? QuestionExperimente { get; set; }

        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Quizz> Quizz { get; set; }
    }
}
