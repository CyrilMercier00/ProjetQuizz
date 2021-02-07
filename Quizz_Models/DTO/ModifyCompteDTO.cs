using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.DTO
{
    public class ModifyCompteDTO
    {
        public int PkCompte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; set; }
    }
}
