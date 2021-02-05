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
                Ajouter_quest = (p.AjouterQuest != 0),
                Generer_quizz = (p.GenererQuizz != 0),
                Modifier_quest = (p.ModifierQuest != 0),
                Suppr_question = (p.SupprQuestion != 0),
                supprimer_compte = (p.SupprimerCompte != 0),
                modifier_compte = (p.ModifierCompte != 0)
            };
        }

        public void ModifyPermission(PermissionDTO permissionDTO)
        {
            Permission permissionAModifier = this.repoPermission.GetPermissionById(permissionDTO.PkPermission);
            this.repoPermission.ModifyPermission(permissionAModifier);
            MailUtils.ModifyPermission(ref permissionAModifier, permissionDTO);
            this.repoPermission.Sauvegarder();
        }
    }
}
