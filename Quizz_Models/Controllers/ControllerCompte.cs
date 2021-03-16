using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System.Collections.Generic;
using Quizz_Models.Authentification;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/compte")]
    public class ControllerCompte : Controller
    {
        readonly CompteService compteService;

        public ControllerCompte(CompteService compteService)
        {
            this.compteService = compteService;
        }

        [HttpGet("{id}")]
        public CompteDTOAdmin Get(int id)
        {
            CompteDTOAdmin compte = this.compteService.GetCompte(id);

            if (compte == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

            return compte;
        }

        [Authorize(AuthorizationEnum.SupprimerCompte, AuthorizationEnum.ModifierCompte, AuthorizationEnum.GenererQuizz)]
        [HttpGet]
        public List<CompteDTOAdmin> Get()
        {
            List<CompteDTOAdmin> comptes = this.compteService.GetCompte();

            if (comptes == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NoContent;
                return null;
            }

            return comptes;
        }
        /// <summary>
        /// Retourne le compte lié au quizz ayant le code passé
        /// </summary>
        /// <param name="prmCode"></param>
        /// <returns></returns>
        [HttpGet("{vide}/{prmCode}/{jwt}")]
        public CompteDTO GetCompteLinkedToQuizz(string prmCode)
        {
            try
            {
                CompteDTO compte = this.compteService.GetCompteByCode(prmCode);

                if (compte == null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    return null;
                }

                return compte;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("{vide}/{idCompteRef}")]
        public List<CompteDTO> GetCompteByRef(string vide, int idCompteRef)
        {
            // Recuperation et transformation en DTO des comptes lié a cette ref
            List<CompteDTO> listDTO = this.compteService.listCompteToDTO(this.compteService.GetCandidatByCompteRef(idCompteRef));

            if (listDTO.Count == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return listDTO;
            }

        }


        [Authorize(AuthorizationEnum.SupprimerCompte)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.compteService.DeleteCompte(id);
        }

        [HttpPut("{idCompte}/permission")]
        public void Put(int idCompte, [FromBody] AffichagePermissionDTO affichagePermissionDTO)
        {
            this.compteService.ModifyComptePermission(idCompte, affichagePermissionDTO.PkPermission);
        }

        [HttpPost]
        public void Post([FromBody] CompteDTO compteDTO)
        {
            compteDTO.MDP = computePassword(compteDTO.MDP);
            int lignes = this.compteService.AjoutCompte(compteDTO);

            if (lignes == -1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            else if (lignes == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            // Si aucune permission n'a été ajouté
            else if (lignes == 1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
            // Si permission ajoutée
            else if (lignes == 2)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
        }

        /// <summary>
        /// Méthode qui crypte un mot de passe via l'algorithme SHA256.
        /// </summary>
        /// <param name="motdepasse">Mot de passe à crypter.</param>
        /// <returns>Mot de passe crypté.</returns>
        public static string computePassword(string motdepasse)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] mdpByte = Encoding.UTF8.GetBytes(motdepasse);
            byte[] hashByte = sha256Hash.ComputeHash(mdpByte);

            // retourne le hash convertie en string
            return BitConverter.ToString(hashByte).Replace("-", String.Empty);
        }

        [HttpPut]
        public void Put([FromBody] ModifyCompteDTO modifyCompteDTO)
        {
            if (modifyCompteDTO.PkCompte < 1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            else
            {
                this.compteService.ModifyCompte(modifyCompteDTO);
            }
        }
    }
}
