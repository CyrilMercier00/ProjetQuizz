using System;

namespace Quizz_Models.DTO
{
    public class ReponseCandidatDTO
    {
        public string Reponse { get; set; }
        public string Commentaire { get; set; }
        public int FkCompte { get; set; }
        public int FkQuestion { get; set; }
        public bool isTrue { get; set; }
    }
}
