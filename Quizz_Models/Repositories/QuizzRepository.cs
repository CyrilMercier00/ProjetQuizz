using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;

namespace Quizz_Models.Repositories
{
    public class QuizzRepository
    {
        private readonly bdd_quizzContext bdd_entities;


        public QuizzRepository(bdd_quizzContext context)
        {
            bdd_entities = context;
        }



        /// <summary>
        /// Insere un objet quizz
        /// </summary>
        /// <param name="prmQuizz"></param>
        public void InsertQuizz(Quizz prmQuizz)
        {
            bdd_entities.Quizz.Add(prmQuizz);
        }



        /// <summary>
        /// Ajoute le quizz au contexte sans le sauvegarder
        /// </summary>
        /// <param name="prmQuizz"></param>
        public void AttachQuizz(Quizz prmQuizz)
        {
            bdd_entities.Attach(prmQuizz);
        }



        /// <summary>
        /// Appel de SaveChanges et retour du nombre de ligne modifiées
        /// </summary>
        /// <returns></returns>
        public int Sauvegarde()
        {
            return bdd_entities.SaveChanges();
        }



        /// <summary>
        /// Retourne l'objet quizz avec la pk passé
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <returns></returns>
        public Quizz GetQuizzByID(int prmIDQuizz)
        {
            return bdd_entities.Quizz
                .Find(prmIDQuizz);
        }



        /// <summary>
        /// Ajoue une liaison entre un compte et un quizz
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <param name="compteQuizz"></param>
        internal void InsertLiaisonCompte(int prmIDQuizz, CompteQuizz prmCompteQuizz)
        {
            bdd_entities.Quizz.Find(prmIDQuizz).CompteQuizz.Add(prmCompteQuizz);
        }



        /// <summary>
        /// Supprimer l'objet quizz passé
        /// </summary>
        /// <param name="prmQuizz"></param>
        public void SupprimerQuizz(Quizz prmQuizz)
        {
            bdd_entities.Quizz.Remove(prmQuizz);
        }



        /// <summary>
        /// Créer un nouvel objet CompteQuizz avec les clé passée
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <param name="prmIDCompte"></param>
        public void UpdateNavgationCompte(int prmIDQuizz, int prmIDCompte)
        {
            bdd_entities.Quizz.Find(prmIDQuizz).CompteQuizz.Add(new CompteQuizz()
            {
                FkCompte = prmIDCompte,
                FkQuizz = prmIDQuizz
            });
        }

    }
}