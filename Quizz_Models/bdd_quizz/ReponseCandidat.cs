using System;
using System.Collections.Generic;

namespace Quizz_Models.bdd_quizz
{
    public partial class ReponseCandidat
    {
        public int PkReponse { get; set; }
        public string Reponse { get; set; }
        public string Commentaire { get; set; }
        public int FkCompte { get; set; }
        public int FkQuestion { get; set; }

        public virtual Compte FkCompteNavigation { get; set; }
        public virtual Question FkQuestionNavigation { get; set; }
    }
}
