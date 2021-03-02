using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;
using Quizz_Models.Utils;
using System;
using System.Collections.Generic;

namespace Quizz_Models.Services
{
    public class CompteService
    {
        readonly PermissionRepository repoPermission;
        readonly CompteRepository repoCompte;

        public CompteService(PermissionRepository repoPermission, CompteRepository repoCompte)
        {
            this.repoPermission = repoPermission;
            this.repoCompte = repoCompte;
        }
        /// <summary>
        /// Renvoie une liste des compte ayant comme referent l'id du compte passé
        /// </summary>
        /// <param name="prmIDCompteRef"></param>
        /// <returns></returns>
        public List<Compte> GetCandidatByCompteRef(int prmIDCompteRef)
        {
            return repoCompte.GetCompteByCompteRef(prmIDCompteRef);
        }

        /// <summary>
        /// Transforme une liste de compte en liste de DTO
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public List<CompteDTO> listCompteToDTO(List<Compte> prmList)
        {
            List<CompteDTO> listRetour = new List<CompteDTO>();

            foreach (Compte c in prmList)
            {
                listRetour.Add(new CompteDTO()
                {
                    Nom = c.Nom,
                    Prenom = c.Prenom,
                    Mail = c.Mail,
                    MDP = c.MotDePasse
                });
            }
            return listRetour;
        }

        /// <summary>
        /// Retourne tout les comptes ayant le nom de cette permisison (Sensible a la casse).
        /// </summary>
        /// <param name="prmNom"></param>
        /// <returns></returns>
        public List<Compte> GetCompteByNomPerm(string prmNom)
        {
            int IDPerm = repoPermission.GetPermissionByNom(prmNom).PkPermission;
            return repoCompte.GetCompteByNomPerm(IDPerm);
        }

        /// <summary>
        /// Ajout d'un compte sans Permission. Destinée uniquement pour les tests.
        /// </summary>
        /// <param name="CompteDTO">Compte à ajouter.</param>
        /// <returns>Nombre de lignes insérées.</returns>
        public int AjoutCompte(CompteDTO CompteDTO)
        {
            if (!MailUtils.VerifyMail(CompteDTO.Mail) || !MailUtils.VerifyMotDePasse(CompteDTO.MDP))
            {
                return 0;
            }

            Compte c = TransformCompteDTOToCompteEntity(CompteDTO);

            c.FkPermissionNavigation = this.repoPermission.GetPermissionById(c.FkPermission);
            repoCompte.InsertCompte(c);

            int lignes;
            try
            {
                lignes = repoCompte.Sauvegarder();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                lignes = -1;
            }

            return lignes;
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

        public Compte FindCompteByMail(string mail)
        {
            return this.repoCompte.FindCompteByMail(mail);
        }

        /// <summary>
        /// Retourne la liste des comptes en DTO.
        /// </summary>
        public List<CompteDTOAdmin> GetCompte()
        {
            List<Compte> comptes = repoCompte.GetAllComptes();

            if (comptes.Count == 0) return null;
            else return TransformListCompteEntityToCompteDTOAdmin(comptes);
        }

        /// <summary>
        /// Transforme une entité compte au DTO correspondant.
        /// </summary>
        /// <param name="CompteID">Entité à transformer.</param>
        /// <returns>DTO correspondant.</returns>
        public CompteDTOAdmin GetCompte(int CompteID)
        {
            Compte compte = repoCompte.GetCompteByID(CompteID);

            if (compte == null) return null;
            return TransformCompteEntityToCompteDTOAdmin(compte);
        }

        public PermissionDTO GetCurrentComptePermission(int compteID)
        {
            PermissionDTO permissionDTO = null;
            Compte c = this.repoCompte.GetCompteByID(compteID);

            if(c != null)
            {
                Permission p = this.repoPermission.GetPermissionById(c.FkPermission);
                permissionDTO = PermissionService.TransformPermissionToPermissionDTO(p);
            }

            return permissionDTO;
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
        /// Modification d'un compte.
        /// </summary>
        /// <param name="modifyCompteDTO">Valeur de modification.</param>
        public void ModifyCompte(ModifyCompteDTO modifyCompteDTO)
        {
            Compte compteAModifier = this.repoCompte.GetCompteByID(modifyCompteDTO.PkCompte);
            this.repoCompte.ModifyCompte(compteAModifier);
            MailUtils.ModifyCompte(ref compteAModifier, modifyCompteDTO);
            this.repoCompte.Sauvegarder();
        }

        /// <summary>
        /// Méthode qui modifie la permission d'un utilisateur.
        /// </summary>
        /// <param name="idCompte">ID du compte à modifier.</param>
        /// <param name="idPermission">ID de la permission voulue.</param>
        public void ModifyComptePermission(int idCompte, int idPermission)
        {
            this.repoCompte.ModifyPermission(idCompte, idPermission);
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
                Mail = CompteDTO.Mail,
                MotDePasse = CompteDTO.MDP,
                FkPermission = 3
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
                AjouterQuest = Convert.ToByte(PermissionDTO.AjouterQuest),
                GenererQuizz = Convert.ToByte(PermissionDTO.GenererQuizz),
                ModifierQuest = Convert.ToByte(PermissionDTO.ModifierQuest),
                SupprQuestion = Convert.ToByte(PermissionDTO.SupprQuestion)
            };

            return p;
        }

        /// <summary>
        /// Cette méthode transforme une entité Compte en DTO Compte admin.
        /// </summary>
        /// <param name="cpt">Entité du compte à transformer.</param>
        /// <returns>DTO correspondant.</returns>
        private CompteDTOAdmin TransformCompteEntityToCompteDTOAdmin(Compte cpt)
        {
            CompteDTOAdmin compteDTOAdmin = new CompteDTOAdmin
            {
                Id = cpt.PkCompte,
                Nom = cpt.Nom,
                Prenom = cpt.Prenom,
                Mail = cpt.Mail,
                MDP = cpt.MotDePasse,
                Role = cpt.FkPermissionNavigation.Nom
            };

            return compteDTOAdmin;
        }

        /// <summary>
        /// Transforme une liste de Compte entité en liste de Compte DTO admin.
        /// </summary>
        /// <param name="comptes">Liste d'entités Compte.</param>
        /// <returns>Liste de DTO Compte correspondante.</returns>
        private List<CompteDTOAdmin> TransformListCompteEntityToCompteDTOAdmin(List<Compte> comptes)
        {
            List<CompteDTOAdmin> compteDTOs = new List<CompteDTOAdmin>();
            foreach (Compte compte in comptes)
            {
                compteDTOs.Add(TransformCompteEntityToCompteDTOAdmin(compte));
            }
            return compteDTOs;
        }
    }
}
