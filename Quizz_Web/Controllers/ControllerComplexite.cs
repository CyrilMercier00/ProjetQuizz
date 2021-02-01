using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizz_Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quizz_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerComplexite : ControllerBase
    {
        Quizz_Models.Services.ComplexiteService complexiteService;

        public ControllerComplexite()
        {
            this.complexiteService = new Quizz_Models.Services.ComplexiteService();
        }


        // GET: api/<ControllerComplexite>
        [HttpGet]
        public List<Taux_complexiteDTO> Get()
        {
            return complexiteService.GetComplexites();
        }

        // GET api/<ControllerComplexite>/5
        [HttpGet("{id}")]
        public Taux_complexiteDTO Get(string nomcomplex)
        {
            return complexiteService.GetComplexite(nomcomplex);
        }

        // POST api/<ControllerComplexite>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ControllerComplexite>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ControllerComplexite>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
