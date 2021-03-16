using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.DTO
{
    public class LoginDTO
    {
        public int PkCompte { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; set; }
    }
}
