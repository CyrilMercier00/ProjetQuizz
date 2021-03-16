using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/reponse-candidat")]
    public class ControllerReponseCandidat : Controller
    {
        readonly ServiceReponseCandidat repService;

        public ControllerReponseCandidat(ServiceReponseCandidat serviceReponseCandidat)
        {
            repService = serviceReponseCandidat;
        }

        [HttpPost]
        [Route("{prmDTO}")]

        public IActionResult Post([FromBody] ReponseCandidatDTO prmDTO)
        {
            switch (repService.InsertReponseCandidat(prmDTO))
            {
                case 0:
                    return NotFound();

                case 1:
                    return Ok();

                default:
                    return Problem("More than one column were inserted");
            }
        }
    }
}
