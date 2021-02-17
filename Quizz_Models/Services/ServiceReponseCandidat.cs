using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.Services
{
    public class ServiceReponseCandidat
    {

        ReponseCandidatRepository RepoRepC = new ReponseCandidatRepository ();

        public ServiceReponseCandidat () { }

        public void InsertReponseCandidat ( ReponseCandidatDTO prmRepC )
        {
            RepoRepC.InsertReponseCandidat (new ReponseCandidat ()
            {
                Reponse = prmRepC.Reponse,
                Commentaire = prmRepC.Commentaire,
                FkCompte = prmRepC.FkCompte,
                FkQuestion = prmRepC.FkQuestion
            });
        }
    }
}