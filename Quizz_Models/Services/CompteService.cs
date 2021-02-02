using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;
using System;
using System.Collections.Generic;

namespace Quizz_Models.Services
{
    public class CompteService
    {
        readonly PermissionRepository repoPermission = new PermissionRepository();
        readonly CompteRepository repoCompte = new CompteRepository();

        const int ADMIN_PERMISSION_ID = 1;
        const int RECRUTEUR_PERMISSION_ID = 2;
        const int CANDIDAT_PERMISSION_ID = 3;

        public CompteService() { }

        /// <summary>
        /// Méthode qui crée un Compte avec un CompteDTO et une PermissionDTO.
        /// </summary>
        /// <param name="CompteDTO">DTO pour la création d'un Compte</param>
        /// <param name="PermissionDTO">DTO pour la création d'une Permission</param>
        public void AjoutCompte(CompteDTO CompteDTO, PermissionDTO PermissionDTO)
        {
            Permission p = TransformPermissionDTOToPermissionEntity(PermissionDTO);
            int PermissionID;

            try
            {
                PermissionID = repoPermission.FindPermissionByValues(p).PkPermission;
            }
            catch (ArgumentNullException)
            {
                repoPermission.InsertPermission(p);
                PermissionID = repoPermission.FindPermissionByValues(p).PkPermission;
            }

            AjoutCompte(CompteDTO, PermissionID);
        }

        /// <summary>
        /// Méthode qui crée un Compte et lui assigne une Permission.
        /// </summary>
        /// <param name="CompteDTO">DTO pour la création d'un Compte.</param>
        /// <param name="PermissionID">ID de la Permission voulue.</param>
        public void AjoutCompte(CompteDTO CompteDTO, int PermissionID)
        {
            Compte c = TransformCompteDTOToCompteEntity(CompteDTO);

            if(PermissionID >= ADMIN_PERMISSION_ID && PermissionID <= CANDIDAT_PERMISSION_ID)
            {
                c.Role = PermissionID;
                c.FkPermission = PermissionID;
            }

            repoCompte.InsertCompte(c);
        }

        /// <summary>
        /// Ajout d'un compte sans Permission. Destinée uniquement pour les tests.
        /// </summary>
        /// <param name="CompteDTO">Compte à ajouter.</param>
        /// <returns>Nombre de lignes insérées.</returns>
        public int AjoutCompte(CompteDTO CompteDTO)
        {
            Compte c = TransformCompteDTOToCompteEntity(CompteDTO);
            c.FkPermissionNavigation = new Permission();
            repoCompte.InsertCompte(c);

            return repoCompte.Sauvegarder();
        }


        /// <summary>
        /// Méthode qui crée un Compte avec un CompteDTO et le nom d'une Permission.<br></br>
        /// Cette méthode doit être utilisée pour les Permissions de base (Compte candidat, recruteur, administrateur).
        /// </summary>
        /// <param name="CompteDTO">DTO pour la création d'un Compte</param>
        /// <param name="nomPermission">Nom de la Permission (candidat, recruteur, administrateur</param>
        public void AjoutCompte(CompteDTO CompteDTO, string nomPermission)
        {

        }

        /// <summary>
        /// Retourne la liste des comptes en DTO.
        /// </summary>
        public List<CompteDTO> GetCompte()
        {
            List<Compte> comptes = repoCompte.GetAllComptes();

            if (comptes.Count == 0) return null;
            else return TransferListCompteDTOToEntity(comptes);
        }

        /// <summary>
        /// Transforme une entité compte au DTO correspondant.
        /// </summary>
        /// <param name="CompteID">Entité à transformer.</param>
        /// <returns>DTO correspondant.</returns>
        public CompteDTO GetCompte(int CompteID)
        {
            Compte compte = repoCompte.GetCompteByID(CompteID);

            if (compte == null) return null;
            return TransformCompteEntityToCompteDTO(compte);
        }

        /// <summary>
        /// Méthode qui supprime un compte en donnant l'ID correspondant.
        /// </summary>
        /// <param name="CompteID">ID du compte.</param>
        public void DeleteCompte(int CompteID)
        {
            repoCompte.DeleteCompte(CompteID);
            repoCompte.Sauvegarder();
        }

        /// <summary>
        /// Transforme un CompteDTO en entité Compte.
        /// </summary>
        /// <param name="CompteDTO"></param>
        /// <returns>Retourne l'entité correspondante.</returns>
        private Compte TransformCompteDTOToCompteEntity(CompteDTO CompteDTO)
        {
            Compte c = new Compte
            {
                Nom = CompteDTO.Nom,
                Prenom = CompteDTO.Prenom,
                Mail = CompteDTO.Mail
            };

            return c;
        }

        /// <summary>
        /// Transforme un PermissionDTO en entité Permission.
        /// </summary>
        /// <param name="PermissionDTO">DTO de la permission.</param>
        /// <returns>Retourne l'entité correspondante.</returns>
        private Permission TransformPermissionDTOToPermissionEntity(PermissionDTO PermissionDTO)
        {
            Permission p = new Permission
            {
                AjouterQuest = Convert.ToByte(PermissionDTO.Ajouter_quest),
                GenererQuizz = Convert.ToByte(PermissionDTO.Generer_quizz),
                ModifierQuest = Convert.ToByte(PermissionDTO.Modifier_quest),
                SupprQuestion = Convert.ToByte(PermissionDTO.Suppr_question)
            };

            return p;
        }

        /// <summary>
        /// Cette méthode transforme une entité Compte en DTO Compte.
        /// </summary>
        /// <param name="cpt">Entité du compte à transformer.</param>
        /// <returns>DTO correspondant.</returns>
        private CompteDTO TransformCompteEntityToCompteDTO(Compte cpt)
        {
            CompteDTO CompteDTO = new CompteDTO
            {
                Nom = cpt.Nom,
                Prenom = cpt.Prenom,
                Mail = cpt.Mail
            };

            return CompteDTO;
        }

        /// <summary>
        /// Transforme une liste de Compte entité en liste de Compte DTO.
        /// </summary>
        /// <param name="comptes">Liste d'entités Compte.</param>
        /// <returns>Liste de DTO Compte correspondante.</returns>
        private List<CompteDTO> TransferListCompteDTOToEntity(List<Compte> comptes)
        {
            List<CompteDTO> compteDTOs = new List<CompteDTO>();
            foreach (Compte compte in comptes)
            {
                compteDTOs.Add(TransformCompteEntityToCompteDTO(compte));
            }
            return compteDTOs;
        }
    }
}
