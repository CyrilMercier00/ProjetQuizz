using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    public class ServiceReponseCandidat
    {

        ReponseCandidatRepository reponseCandidatRepo;

        public ServiceReponseCandidat (ReponseCandidatRepository reponseCandidatRepository) 
        {
            this.reponseCandidatRepo = reponseCandidatRepository;
        }

        public int InsertReponseCandidat ( ReponseCandidatDTO prmRepC )
        {
           return reponseCandidatRepo.InsertReponseCandidat (new ReponseCandidat ()
            {
                Reponse = prmRepC.Reponse,
                Commentaire = prmRepC.Commentaire,
                FkCompte = prmRepC.FkCompte,
                FkQuestion = prmRepC.FkQuestion
            });
        }
    }
}