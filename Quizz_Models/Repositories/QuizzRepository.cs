using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;

namespace Quizz_Models.Services
{
    public class QuizzRepository
    {
        private readonly bdd_quizzContext bdd_entities ;


        public QuizzRepository () { }

        public void InsertQuizz ( Quizz prmQuizz )
        {
            bdd_entities.Quizz.Add (prmQuizz);
            bdd_entities.SaveChanges ();
        }

        public Quizz GetQuizzByID ( int prmIDQuizz )
        {
            return bdd_entities.Quizz
                .Find (prmIDQuizz);
        }

        public void SupprimerQuizz ( Quizz prmQuizz )
        {
            bdd_entities.Quizz.Remove (prmQuizz);
            bdd_entities.SaveChanges ();
        }

        /// <summary>
        /// Méthode qui recupére un quizz via son ID
        /// </summary>
        /// <param name="PermissionEntity">Entité de la Permission</param>
        /// <returns>Retourne la Permission trouvée ou lance une exception si aucune n'a été trouvée.</returns>

       
    }
}