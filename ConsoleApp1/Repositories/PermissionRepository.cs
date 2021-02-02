using Quizz_Models.bdd_quizz;
using System.Linq;

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
    }
}
