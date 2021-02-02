using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System.Net;
using System.Collections.Generic;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/compte")]
    public class ControllerCompte : Controller
    {
        readonly CompteService compteService;

        public ControllerCompte()
        {
            this.compteService = new CompteService();
        }

        [HttpGet("{id}")]
        public CompteDTO Get(int id)
        {
            CompteDTO compte =  this.compteService.GetCompte(id);

            if (compte == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

            return compte;
        }

        [HttpGet]
        public List<CompteDTO> Get()
        {
            List<CompteDTO> comptes = this.compteService.GetCompte();

            if(comptes == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return null;
            }

            return comptes;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.compteService.DeleteCompte(id);
        }

        [HttpPost]
        public void Post([FromBody] CompteDTO compteDTO)
        {
            int lignes = this.compteService.AjoutCompte(compteDTO);

            if(lignes == -1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            else if(lignes == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            // Si aucune permission n'a été ajouté
            else if(lignes == 1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
            // Si permission ajoutée
            else if(lignes == 2)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
        }
    }
}
