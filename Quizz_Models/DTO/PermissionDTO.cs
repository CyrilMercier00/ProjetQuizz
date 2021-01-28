using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    class PermissionDTO
    {
        public Nullable<bool> Generer_quizz { get; set; }
        public Nullable<bool> Ajouter_quest { get; set; }
        public Nullable<bool> Modifier_quest { get; set; }
        public Nullable<bool> Suppr_question { get; set; }
    }
}
