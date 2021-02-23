using Quizz_Models.bdd_quizz;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Quizz_Models.Repositories
{
    public class CompteRepository
    {
        private readonly bdd_quizzContext bdd_entities ;
        public CompteRepository(bdd_quizzContext quizzContext) 
        {
            bdd_entities = quizzContext;
        }

        /// <summary>
        /// Méthode qui retourne tout les comptes de la bdd.
        /// </summary>
        /// <returns>Liste de tout les comptes.</returns>
        public List<Compte> GetAllComptes()
        {
            return bdd_entities.Compte.Include(c => c.FkPermissionNavigation).ToList();
        }

        public List<Compte> GetCompteByNomPerm(int prmidPerm)
        {
            return bdd_entities.Compte
                .Where(x => x.FkPermission == prmidPerm)
                .ToList();
                
        }
        /// <summary>
        /// Retourne les comptes ayant comme referent le compte avec l'id passé.
        /// </summary>
        /// <param name="iDPerm"></param>
        /// <returns></returns>
        internal List<Compte> GetCompteByCompteRef(int prmID)
        {
            return bdd_entities.Compte.Where(x => x.PkCompte == prmID).ToList();
        }

        /// <summary>
        /// Méthode qui retourne un compte par son ID.
        /// </summary>
        /// <param name="prmID">ID du compte.</param>
        /// <returns>Le compte demandé.</returns>
        public Compte GetCompteByID(int prmID)
        {
            return bdd_entities.Compte.Where(c => c.PkCompte == prmID).Include(c => c.FkPermissionNavigation).Single();
        }

        /// <summary>
        /// Méthode qui ajoute un compte dans la bdd.
        /// </summary>
        /// <param name="prmCompte">Entité du compte.</param>
        public void InsertCompte(Compte prmCompte)
        {
            bdd_entities.Compte.Add(prmCompte);
        }

        /// <summary>
        /// Méthode qui prépare la bdd à une modification de compte.
        /// </summary>
        /// <param name="compte">Entité du compte à modifier.</param>
        public void ModifyCompte(Compte compte)
        {
            bdd_entities.Entry(compte).State = EntityState.Modified;
        }

        /// <summary>
        /// Méthode qui supprime un compte via l'ID du compte.
        /// </summary>
        /// <param name="CompteID">ID du compte.</param>
        public void DeleteCompte(int CompteID)
        {
            Compte CompteEntity = bdd_entities.Compte.Find(CompteID);
            bdd_entities.Compte.Remove(CompteEntity);
        }

        /// <summary>
        /// Sauvegarde les éléments du contexte dans la base de donnée.
        /// </summary>
        /// <returns>Nombre de lignes ajoutées dans la bdd.</returns>
        public int Sauvegarder()
        {
            int lignes;
            try
            {
                lignes = bdd_entities.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                lignes = -1;
            }
            return lignes;
        }
    }
}
