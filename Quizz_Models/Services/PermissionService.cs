using System;
using System.Collections.Generic;
using System.Text;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    public class PermissionService
    {
        readonly PermissionRepository repoPermission = new PermissionRepository();
        public PermissionService() { }

        public List<PermissionDTO> GetPermissions()
        {
            List<Permission> permissions = this.repoPermission.GetAllPermissions();

            return TransformListPermissionToListPermissionDTO(permissions);
        }

        private List<PermissionDTO> TransformListPermissionToListPermissionDTO(List<Permission> permissions)
        {
            List<PermissionDTO> permissionDTOs = new List<PermissionDTO>();

            if (permissions.Count == 0) return permissionDTOs;

            foreach(Permission p in permissions)
            {
                PermissionDTO permissionDTO = TransformPermissionToPermissionDTO(p);
                permissionDTOs.Add(permissionDTO);
            }

            return permissionDTOs;
        }

        private PermissionDTO TransformPermissionToPermissionDTO(Permission p)
        {
            return new PermissionDTO
            {
                PkPermission = p.PkPermission,
                AjouterQuest = (p.AjouterQuest != 0),
                GenererQuizz = (p.GenererQuizz != 0),
                ModifierQuest = (p.ModifierQuest != 0),
                SupprQuestion = (p.SupprQuestion != 0),
                SupprimerCompte = (p.SupprimerCompte != 0),
                ModifierCompte = (p.ModifierCompte != 0)
            };
        }

        public int ModifyPermission(PermissionDTO permissionDTO)
        {
            Permission permissionAModifier = this.repoPermission.GetPermissionById(permissionDTO.PkPermission);
            if (permissionAModifier == null) return 0;

            this.repoPermission.ModifyPermission(permissionAModifier);
            MailUtils.ModifyPermission(ref permissionAModifier, permissionDTO);
            return this.repoPermission.Sauvegarder();
        }
    }
}
