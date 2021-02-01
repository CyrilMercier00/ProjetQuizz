using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;
using System;

namespace Quizz_Models.Services
{
    public class CompteService
    {
        readonly PermissionRepository repoPermission = new PermissionRepository();
        readonly CompteRepository repoCompte = new CompteRepository();

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
            c.FkPermission = PermissionID;
            repoCompte.InsertCompte(c);
        }

        public void AjoutCompte(CompteDTO CompteDTO)
        {
            Compte c = TransformCompteDTOToCompteEntity(CompteDTO);
            repoCompte.InsertCompte(c);
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

        public CompteDTO GetCompte(int CompteID)
        {
            Compte c = repoCompte.GetCompteByID(CompteID);
            CompteDTO CompteDTO = TransformCompteEntityToCompteDTO(c);
            return CompteDTO;
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
        /// <param name="PermissionDTO"></param>
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
    }
}
