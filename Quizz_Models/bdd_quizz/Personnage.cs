using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Personnage
    {
        public Personnage()
        {
            Skill = new HashSet<Skill>();
        }

        public int PkPersonnage { get; set; }
        public string Nom { get; set; }
        public float? Vie { get; set; }
        public float? Degat { get; set; }
        public float? Defense { get; set; }
        public int? NbRound { get; set; }
        public int? IdGroupe { get; set; }

        public virtual ICollection<Skill> Skill { get; set; }
    }
}
