using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerQuizz : Controller
    {

        [HttpPost]
        public void Post([FromBody] QuizzDTO prmQuizzDTO)
        {

        }
    }
}
