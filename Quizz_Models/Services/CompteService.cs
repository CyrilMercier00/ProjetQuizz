using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizz_Models.DTO;

namespace Quizz_Models.Services
{
    public class CompteService
    {
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
                permissionID = QuizzBDD.bdd_instance.FindPermissionByValues(p).pk_permission;
            } 
            catch(ArgumentNullException)
            {
                QuizzBDD.bdd_instance.InsertPermission(p);
                permissionID = QuizzBDD.bdd_instance.FindPermissionByValues(p).pk_permission;
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
            QuizzBDD.bdd_instance.InsertCompte(c);
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
            compte c = QuizzBDD.bdd_instance.GetCompteByID(compteID);
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
            compte c = new compte();
            c.nom = compteDTO.Nom;
            c.prenom = compteDTO.Prenom;
            c.mail = compteDTO.Mail;

            return c;
        }

        /// <summary>
        /// Transforme un PermissionDTO en entité permission.
        /// </summary>
        /// <param name="permissionDTO"></param>
        /// <returns>Retourne l'entité correspondante.</returns>
        private permission TransformPermissionDTOToPermissionEntity(PermissionDTO permissionDTO)
        {
            permission p = new permission();

            p.ajouter_quest = Convert.ToSByte(permissionDTO.Ajouter_quest);
            p.generer_quizz = Convert.ToSByte(permissionDTO.Generer_quizz);
            p.modifier_quest = Convert.ToSByte(permissionDTO.Modifier_quest);
            p.suppr_question = Convert.ToSByte(permissionDTO.Suppr_question);

            return p;
        }

        private CompteDTO TransformCompteEntityToCompteDTO(compte cpt)
        {
            CompteDTO compteDTO = new CompteDTO();

            compteDTO.Nom = cpt.nom;
            compteDTO.Prenom = cpt.prenom;
            compteDTO.Mail = cpt.mail;

            return compteDTO;
        }
    }
}
