using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class QuizzRepository
    {
        bdd_quizzEntities bdd_entities;


        public QuizzRepository (){}

        public void InsertQuizz (quizz prmQuizz)
        {
            bdd_entities.quizz.Add (prmQuizz);
        }
        
    }
}