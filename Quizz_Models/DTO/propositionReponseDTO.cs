using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.DTO
{
    public class PropositionReponseDTO
    {
        public int PkReponse { get; set; }
        public string Text { get; set; }
        public bool estBonne { get; set; }
        public int FkQuestion { get; set; }

    }

}
