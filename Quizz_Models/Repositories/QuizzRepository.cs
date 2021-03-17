using Quizz_Models.bdd_quizz;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
        /// Appel de SaveChanges et retour du nombre de ligne modifiÈes
        /// </summary>
        /// <returns></returns>
        public int Sauvegarde()
        {
            return bdd_entities.SaveChanges();
        }



        /// <summary>
        /// Retourne l'objet quizz avec la pk passÅE
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <returns></returns>
        public Quizz GetQuizzByID(int prmIDQuizz)
        {
            return bdd_entities.Quizz
                .Find(prmIDQuizz);
        }

        public List<CompteQuizz> GetQuizzByCreateur(int idCreateur)
        {
            List<CompteQuizz> compteQuizz = bdd_entities.CompteQuizz
                                                        .Where(cq => cq.FkCompte == idCreateur && cq.EstCreateur == (byte)1)
                                                        .Include(cq => cq.FkQuizzNavigation)
                                                        .ToList();

            return compteQuizz;
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
        /// Supprimer l'objet quizz passÅE
        /// </summary>
        /// <param name="prmQuizz"></param>
        public void SupprimerQuizz(Quizz prmQuizz)
        {
            bdd_entities.Quizz.Remove(prmQuizz);
            bdd_entities.SaveChanges();
        }



        /// <summary>
        /// CrÈer un nouvel objet CompteQuizz avec les clÅEpassÈe
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



        /// <summary>
        /// Retourn le quizz avec le champs codeurl correspondant au code passÅE Retourne null si n'existe pas
        /// </summary>
        /// <param name="prmCodeQuizz"></param>
        /// <returns></returns>
        internal Quizz GetQuizzByCode(string prmCodeQuizz)
        {
            Quizz valRet;

            try
            {
                valRet =  bdd_entities.Quizz.Where(x => x.Urlcode == prmCodeQuizz).Single();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                valRet = null;
            }

            return valRet;
        }
    }
}