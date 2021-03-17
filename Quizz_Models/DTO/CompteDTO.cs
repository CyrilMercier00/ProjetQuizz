using Quizz_Models.bdd_quizz;

namespace Quizz_Models.DTO
{
    public class CompteDTO
    {
        public int Pk { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string MDP { get; set; }
    }

}
