using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Skill
    {
        public int PkSkill { get; set; }
        public float? Frequence { get; set; }
        public int? Degat { get; set; }
        public string Nom { get; set; }
        public int? Type { get; set; }
        public int PersonnageIdpersonnage { get; set; }

        public virtual Personnage PersonnageIdpersonnageNavigation { get; set; }
    }
}
