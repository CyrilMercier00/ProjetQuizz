using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class Permission
    {
        public Permission()
        {
            Compte = new HashSet<Compte>();
        }

        public int PkPermission { get; set; }
        public string Nom { get; set; }
        public byte? GenererQuizz { get; set; }
        public byte? AjouterQuest { get; set; }
        public byte? ModifierQuest { get; set; }
        public byte? ModifierCompte { get; set; }
        public byte? SupprQuestion { get; set; }
        public byte? SupprimerCompte { get; set; }

        public virtual ICollection<Compte> Compte { get; set; }
    }
}
