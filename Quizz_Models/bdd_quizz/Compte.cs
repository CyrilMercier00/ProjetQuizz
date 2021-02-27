using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Compte
    {
        public Compte()
        {
            CompteQuizz = new HashSet<CompteQuizz>();
            ReponseCandidat = new HashSet<ReponseCandidat>();
        }

        public int PkCompte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; set; }
        public int FkPermission { get; set; }
        public int? FkCompteReferent { get; set; }

        public virtual Permission FkCompteReferentNavigation { get; set; }
        public virtual Permission FkPermissionNavigation { get; set; }
        public virtual ICollection<CompteQuizz> CompteQuizz { get; set; }
        public virtual ICollection<ReponseCandidat> ReponseCandidat { get; set; }
    }
}
