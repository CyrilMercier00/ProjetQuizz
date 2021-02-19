using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Quizz_Models.DTO;
using Quizz_Models.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quizz_Web.Controllers
{
    [Route("api/complexite")]

    [ApiController]
    public class ControllerComplexite : ControllerBase
    {
        ComplexiteService complexiteService;

        public ControllerComplexite(ComplexiteService complexiteService)
        {
            this.complexiteService = complexiteService;
        }


        // GET: api/<ControllerComplexite>
        [HttpGet]
        public List<Taux_complexiteDTO> Get()
        {
            return complexiteService.GetComplexites();
        }

        // GET api/<ControllerComplexite>/5
        [HttpGet("{id}")]
        public Taux_complexiteDTO Get(int id)
        {
            return complexiteService.GetComplexite(id);
        }

        // POST api/<ControllerComplexite>
        [HttpPost]
        public Quizz_Models.bdd_quizz.TauxComplexite Post([FromBody] Quizz_Models.bdd_quizz.TauxComplexite noveautxcomplexite)
        {
           return  complexiteService.AjouterTauxComplexite(noveautxcomplexite);
        }

        // PUT api/<ControllerComplexite>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quizz_Models.bdd_quizz.TauxComplexite noveautxcomplexite)
        {
             complexiteService.ModifierVentilation(id, noveautxcomplexite);
        }

        // DELETE api/<ControllerComplexite>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            complexiteService.Delete(id);
        }
    }
}
