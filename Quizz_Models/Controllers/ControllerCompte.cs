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
        

        [Authorize]
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



        [HttpGet("{methode}/{idCompteRef}")]
        public List<CompteDTO> GetCompteByRef(string methode, int idCompteRef)
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
