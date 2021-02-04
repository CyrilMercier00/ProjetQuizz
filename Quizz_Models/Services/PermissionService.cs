using System;
using System.Collections.Generic;
using System.Text;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    class PermissionService
    {
        readonly PermissionRepository repoPermission = new PermissionRepository();
        public PermissionService() { }

        public void ModifyPermission(PermissionDTO permissionDTO)
        {
            Permission permissionAModifier = this.repoPermission.GetPermissionById(permissionDTO.PkPermission);
            this.repoPermission.ModifyPermission(permissionAModifier);
            MailUtils.ModifyPermission(ref permissionAModifier, permissionDTO);
            this.repoPermission.Sauvegarder();
        }
    }
}
