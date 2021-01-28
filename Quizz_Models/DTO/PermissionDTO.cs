using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.DTO
{
    class PermissionDTO
    {
        public Nullable<bool> generer_quizz { get; set; }
        public Nullable<bool> ajouter_quest { get; set; }
        public Nullable<bool> modifier_quest { get; set; }
        public Nullable<bool> suppr_question { get; set; }
    }
}
