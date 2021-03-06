﻿using System;
using System.Collections.Generic;
using System.Text;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;
using Quizz_Models.Utils;

namespace Quizz_Models.Services
{
    public class PermissionService
    {
        readonly PermissionRepository repoPermission;
        public PermissionService(PermissionRepository prmRepoPerm) 
        {
            repoPermission = prmRepoPerm;
        }


        /// <summary>
        /// Retourne toutes les permissions de la bdd.
        /// </summary>
        /// <returns>Liste de toute les permissions sous format PermissionDTO.</returns>
        public List<PermissionDTO> GetPermissions()
        {
            List<Permission> permissions = this.repoPermission.GetAllPermissions();

            return TransformListPermissionToListPermissionDTO(permissions);
        }

        public List<AffichagePermissionDTO> GetPermissionsNames()
        {
            List<Permission> permissions = this.repoPermission.GetAllPermissions();

            return TransformListPermissionNamesToListPermissionNamesDTO(permissions);
        }

        private List<AffichagePermissionDTO> TransformListPermissionNamesToListPermissionNamesDTO(List<Permission> permissions)
        {
            List<AffichagePermissionDTO> permissionsNames = new List<AffichagePermissionDTO>();

            foreach(Permission p in permissions)
            {
                permissionsNames.Add(TransformPermissionToPermissionNameDTO(p));
            }

            return permissionsNames;
        }

        private AffichagePermissionDTO TransformPermissionToPermissionNameDTO(Permission p)
        {
            return new AffichagePermissionDTO
            {
                PkPermission = p.PkPermission,
                Nom = p.Nom
            };
        }

        /// <summary>
        /// Transforme une liste de permission (entité) en liste de PermissionDTO.
        /// </summary>
        /// <param name="permissions">Liste de permission(entité).</param>
        /// <returns>Liste de PermissionDTO correspondant.</returns>
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

        /// <summary>
        /// Transforme une permission(entité) en PermissionDTO.
        /// </summary>
        /// <param name="p">Permission(entité) à transformer.</param>
        /// <returns>PermissionDTO correspondant.</returns>
        public static PermissionDTO TransformPermissionToPermissionDTO(Permission p)
        {
            return new PermissionDTO
            {
                PkPermission = p.PkPermission,
                Nom = p.Nom,
                AjouterQuest = (p.AjouterQuest != 0),
                GenererQuizz = (p.GenererQuizz != 0),
                ModifierQuest = (p.ModifierQuest != 0),
                SupprQuestion = (p.SupprQuestion != 0),
                SupprimerCompte = (p.SupprimerCompte != 0),
                ModifierCompte = (p.ModifierCompte != 0)
            };
        }

        /// <summary>
        /// Transforme un PermissionDTO en entité Permission.
        /// </summary>
        /// <param name="p">PermissionDTO à transformer.</param>
        /// <returns>Permission(entité) correspondante.</returns>
        private Permission TransformPermissionDTOToPermission(PermissionDTO p)
        {
            return new Permission
            {
                PkPermission = p.PkPermission,
                Nom = p.Nom,
                AjouterQuest = Convert.ToByte(p.AjouterQuest),
                GenererQuizz = Convert.ToByte(p.GenererQuizz),
                ModifierQuest = Convert.ToByte(p.ModifierQuest),
                SupprQuestion = Convert.ToByte(p.SupprQuestion),
                SupprimerCompte = Convert.ToByte(p.SupprimerCompte),
                ModifierCompte = Convert.ToByte(p.ModifierCompte)
            };
        }

        /// <summary>
        /// Ajoute une permission à la bdd.
        /// </summary>
        /// <param name="permissionDTO">PermissioDTO à ajouter.</param>
        /// <returns>Nombre de lignes ajoutées.</returns>
        public int AddPermission(PermissionDTO permissionDTO)
        {
            if(IsAllValueNull(permissionDTO))
            {
                return -1;
            }

            Permission p = TransformPermissionDTOToPermission(permissionDTO);

            Permission test = this.repoPermission.FindPermissionByValues(p);

            if(test != null)
            {
                return 0;
            }

            this.repoPermission.AddPermission(p);

            return this.repoPermission.Sauvegarder();
        }

        /// <summary>
        /// Modifie une permission dans la bdd grâce au PermissionDTO correspondant.
        /// </summary>
        /// <param name="permissionDTO">PermissionDTO correspondant.</param>
        /// <returns>Nombre de lignes modifiées.</returns>
        public int ModifyPermission(PermissionDTO permissionDTO)
        {
            Permission permissionAModifier = this.repoPermission.GetPermissionById(permissionDTO.PkPermission);
            if (permissionAModifier == null) return 0;

            this.repoPermission.ModifyPermission(permissionAModifier);
            MailUtils.ModifyPermission(ref permissionAModifier, permissionDTO);
            return this.repoPermission.Sauvegarder();
        }

        /// <summary>
        /// Check si toutes les valeurs sont à nuls (mauvaise requête).
        /// </summary>
        /// <param name="permissionDTO"></param>
        /// <returns>True si toutes les valeurs du DTO sont à null.</returns>
        private bool IsAllValueNull(PermissionDTO permissionDTO)
        {
            if(permissionDTO.AjouterQuest == null && permissionDTO.ModifierCompte == null && permissionDTO.ModifierQuest == null
                && permissionDTO.SupprimerCompte == null && permissionDTO.SupprQuestion == null && permissionDTO.GenererQuizz == null)
            {
                return true;
            }

            return false;
        }
    }
}
