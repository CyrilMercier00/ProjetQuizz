using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    public class CompteService
    {
        readonly PermissionRepository repoPermission = new PermissionRepository();
        readonly CompteRepository repoCompte = new CompteRepository();

        public CompteService() { }

        /// <summary>
        /// Méthode qui crée un compte avec un CompteDTO et une PermissionDTO.
        /// </summary>
        /// <param name="compteDTO">DTO pour la création d'un compte</param>
        /// <param name="permissionDTO">DTO pour la création d'une permission</param>
        public void AjoutCompte(CompteDTO compteDTO, PermissionDTO permissionDTO)
        {
            permission p = TransformPermissionDTOToPermissionEntity(permissionDTO);
            int permissionID;

            try
            {
                permissionID = repoPermission.FindPermissionByValues(p).pk_permission;
            } 
            catch(ArgumentNullException)
            {
                repoPermission.InsertPermission(p);
                permissionID = repoPermission.FindPermissionByValues(p).pk_permission;
            }

            AjoutCompte(compteDTO, permissionID);
        }

        /// <summary>
        /// Méthode qui crée un compte et lui assigne une permission.
        /// </summary>
        /// <param name="compteDTO">DTO pour la création d'un compte.</param>
        /// <param name="permissionID">ID de la permission voulue.</param>
        public void AjoutCompte(CompteDTO compteDTO, int permissionID)
        {
            compte c = TransformCompteDTOToCompteEntity(compteDTO);
            c.fk_permission = permissionID;
            repoCompte.InsertCompte(c);
        }

        public void AjoutCompte(CompteDTO compteDTO)
        {
            compte c = TransformCompteDTOToCompteEntity(compteDTO);
            repoCompte.InsertCompte(c);
        }


        /// <summary>
        /// Méthode qui crée un compte avec un CompteDTO et le nom d'une permission.<br></br>
        /// Cette méthode doit être utilisée pour les permissions de base (Compte candidat, recruteur, administrateur).
        /// </summary>
        /// <param name="compteDTO">DTO pour la création d'un compte</param>
        /// <param name="nomPermission">Nom de la permission (candidat, recruteur, administrateur</param>
        public void AjoutCompte(CompteDTO compteDTO, string nomPermission)
        {

        }

        public CompteDTO GetCompte(int compteID)
        {
            compte c = repoCompte.GetCompteByID(compteID);
            CompteDTO compteDTO = TransformCompteEntityToCompteDTO(c);
            return compteDTO;
        }

        /// <summary>
        /// Transforme un CompteDTO en entité compte.
        /// </summary>
        /// <param name="compteDTO"></param>
        /// <returns>Retourne l'entité correspondante.</returns>
        private compte TransformCompteDTOToCompteEntity(CompteDTO compteDTO)
        {
            compte c = new compte
            {
                nom = compteDTO.Nom,
                prenom = compteDTO.Prenom,
                mail = compteDTO.Mail
            };

            return c;
        }

        /// <summary>
        /// Transforme un PermissionDTO en entité permission.
        /// </summary>
        /// <param name="permissionDTO"></param>
        /// <returns>Retourne l'entité correspondante.</returns>
        private permission TransformPermissionDTOToPermissionEntity(PermissionDTO permissionDTO)
        {
            permission p = new permission
            {
                ajouter_quest = Convert.ToSByte (permissionDTO.Ajouter_quest),
                generer_quizz = Convert.ToSByte (permissionDTO.Generer_quizz),
                modifier_quest = Convert.ToSByte (permissionDTO.Modifier_quest),
                suppr_question = Convert.ToSByte (permissionDTO.Suppr_question)
            };

            return p;
        }

        private CompteDTO TransformCompteEntityToCompteDTO(compte cpt)
        {
            CompteDTO compteDTO = new CompteDTO
            {
                Nom = cpt.nom,
                Prenom = cpt.prenom,
                Mail = cpt.mail
            };

            return compteDTO;
        }
    }
}
