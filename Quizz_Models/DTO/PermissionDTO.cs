using System;

namespace Quizz_Models.DTO
{
    public class PermissionDTO
    {
        public int PkPermission;
        public Nullable<bool> Generer_quizz { get; set; }
        public Nullable<bool> Ajouter_quest { get; set; }
        public Nullable<bool> Modifier_quest { get; set; }
        public Nullable<bool> Suppr_question { get; set; }
        public Nullable<bool> modifier_compte { get; set; }
        public Nullable<bool> supprimer_compte { get; set; }
    }
}
