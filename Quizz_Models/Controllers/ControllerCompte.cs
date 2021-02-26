using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System.Collections.Generic;
using Quizz_Models.bdd_quizz;

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



        [HttpGet("{vide}/{nomPerm}")]
        public List<CompteDTO> Get(string nomPerm)
        {
            List<Compte> listCompte = this.compteService.GetCompteByNomPerm(nomPerm);
            List<CompteDTO> listDTO = new List<CompteDTO>();

            if (listCompte == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

            foreach (Compte c in listCompte)
            {
                listDTO.Add(new CompteDTO() { 
                    Nom = c.Nom, 
                    Prenom = c.Prenom, 
                    Mail = c.Mail, 
                    MDP = c.MotDePasse 
                });

            }

            return listDTO;
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
