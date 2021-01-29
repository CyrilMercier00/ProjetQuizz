using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_Models.Repositories
{
    class PermissionRepository
    {
        bdd_quizzEntities bdd_entities;
        public PermissionRepository () { }

        /// <summary>
        /// Méthode qui insère une permission.
        /// </summary>
        /// <param name="permissionEntity">Entité de la permission</param>
        public void InsertPermission ( permission permissionEntity )
        {
            bdd_entities.permission.Add (permissionEntity);
        }

        /// <summary>
        /// Méthode qui cherche une permission par ses différentes valeurs.
        /// </summary>
        /// <param name="permissionEntity">Entité de la permission</param>
        /// <returns>Retourne la permission trouvée ou lance une exception si aucune n'a été trouvée.</returns>
        public permission FindPermissionByValues ( permission permissionEntity )
        {
            return bdd_entities.permission
                    .Where (x => x.ajouter_quest == permissionEntity.ajouter_quest
                         && x.generer_quizz == permissionEntity.generer_quizz
                         && x.modifier_quest == permissionEntity.modifier_quest
                         && x.suppr_question == permissionEntity.suppr_question)
                    .Single ();
        }
    }
}
