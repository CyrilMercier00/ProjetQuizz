using Quizz_Models.bdd_quizz;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Quizz_Models.Repositories
{
    public class PermissionRepository
    {
        private readonly bdd_quizzContext bdd_entities ;

        public PermissionRepository(bdd_quizzContext prmContext) 
        {
            bdd_entities = prmContext;
        }

        /// <summary>
        /// Méthode qui insère une Permission.
        /// </summary>
        /// <param name="PermissionEntity">Entité de la Permission</param>
        public void InsertPermission(Permission PermissionEntity)
        {
            bdd_entities.Permission.Add(PermissionEntity);
            bdd_entities.SaveChanges ();
        }

        public Permission GetPermissionByNom(string prmNomPerm)
        {
            return bdd_entities.Permission
                .Where(x => x.Nom == prmNomPerm)
                .Single();
        }

        /// <summary>
        /// Méthode qui renvoie la liste de toutes les permissions.
        /// </summary>
        /// <returns>La liste de toutes les permissions.</returns>
        public List<Permission> GetAllPermissions()
        {
            return bdd_entities.Permission.ToList();
        }

        /// <summary>
        /// Méthode qui retourne une permission de la bdd par ID.
        /// </summary>
        /// <param name="permID">ID de la permission.</param>
        /// <returns>Permission voulue.</returns>
        public Permission GetPermissionById(int permID)
        {
            return bdd_entities.Permission.Find(permID);
        }

        /// <summary>
        /// Méthode qui cherche une Permission par ses différentes valeurs.
        /// </summary>
        /// <param name="PermissionEntity">Entité de la Permission</param>
        /// <returns>Retourne la Permission trouvée ou lance une exception si aucune n'a été trouvée.</returns>
        public Permission FindPermissionByValues(Permission PermissionEntity)
        {
            var sql = bdd_entities.Permission
                    .Where(x => x.AjouterQuest == PermissionEntity.AjouterQuest)
                    .Where(x => x.GenererQuizz == PermissionEntity.GenererQuizz)
                    .Where(x => x.ModifierQuest == PermissionEntity.ModifierQuest)
                    .Where(x => x.SupprQuestion == PermissionEntity.SupprQuestion)
                    .Where(x => x.ModifierCompte == PermissionEntity.ModifierCompte)
                    .Where(x => x.SupprimerCompte == PermissionEntity.SupprimerCompte);

            Permission p = null;
            try
            {
                p = sql.First();
            } catch(InvalidOperationException)
            {
            }

            return p;
        }

        /// <summary>
        /// Méthode qui ajoute de nouvelles permissions à la base..
        /// </summary>
        /// <param name="permission">Permission à ajouter.</param>
        /// <returns>Nombre de lignes ajoutées.</returns>
        public void AddPermission(Permission permission)
        {
            bdd_entities.Permission.Add(permission);
        }

        /// <summary>
        /// Méthode qui prépare la bdd à une modification de permission.
        /// </summary>
        /// <param name="permission">Entité de la permission à modifier.</param>
        public void ModifyPermission(Permission permission)
        {
            bdd_entities.Entry(permission).State = EntityState.Modified;
        }

        /// <summary>
        /// Sauvegarde qui enregistre les éléments du contexte dans la bdd.
        /// </summary>
        /// <returns>Nombre de lignes ajoutées dans la bdd.</returns>
        public int Sauvegarder()
        {
            return bdd_entities.SaveChanges();
        }
    }
}
