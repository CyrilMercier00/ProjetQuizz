using System;

namespace Quizz_Models.DTO
{
    public class PermissionDTO
    {
        public int PkPermission { get; set; }
        public string Nom { get; set; }
        public Nullable<bool> GenererQuizz { get; set; }
        public Nullable<bool> AjouterQuest { get; set; }
        public Nullable<bool> ModifierQuest { get; set; }
        public Nullable<bool> SupprQuestion { get; set; }
        public Nullable<bool> ModifierCompte { get; set; }
        public Nullable<bool> SupprimerCompte { get; set; }
    }
}
