using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.Services
{
    public class ServiceReponseCandidat
    {
        
        public ServiceReponseCandidat (){}

        public void InsertReponseCandidat(ReponseCandidat prmRep, Question prmQuest, Compte prmCompteCandidat)
        {
            prmRep.FkCompte = prmCompteCandidat.PkCompte;
            prmRep.FkQuestion = prmQuest.PkQuestion;

        }
    }
}