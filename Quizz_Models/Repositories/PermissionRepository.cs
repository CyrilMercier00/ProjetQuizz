using Quizz_Models.bdd_quizz;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Quizz_Models.Repositories
{
    class PermissionRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext();
        public PermissionRepository() { }

        /// <summary>
        /// Méthode qui insère une Permission.
        /// </summary>
        /// <param name="PermissionEntity">Entité de la Permission</param>
        public void InsertPermission(Permission PermissionEntity)
        {
            bdd_entities.Permission.Add(PermissionEntity);
            bdd_entities.SaveChanges ();
        }

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
            return bdd_entities.Permission
                    .Where(x => x.AjouterQuest == PermissionEntity.AjouterQuest
                        && x.GenererQuizz == PermissionEntity.GenererQuizz
                        && x.ModifierQuest == PermissionEntity.ModifierQuest
                        && x.SupprQuestion == PermissionEntity.SupprQuestion)
                    .Single();
        }

        public void ModifyPermission(Permission permission)
        {
            bdd_entities.Entry(permission).State = EntityState.Modified;
        }

        public void Sauvegarder()
        {
            bdd_entities.SaveChanges();
        }
    }
}
