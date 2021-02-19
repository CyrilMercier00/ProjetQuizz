using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.DTO
{
    public class CompteDTOAdmin
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string MDP { get; set; }
        public string Role { get; set; }
    }
}
