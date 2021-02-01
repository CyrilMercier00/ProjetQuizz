using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class ControllerQuizz : Controller
    {
        QuizzService servQuizz = new QuizzService ();

        [HttpPost]
        public void Post ( [FromBody] QuizzDTO prmQuizzDTO )
        {

            servQuizz.GenererQuizz (
                prmQuizzDTO.NbQuestions,
                prmQuizzDTO.Complexite, 
                prmQuizzDTO.Theme, 
                prmQuizzDTO.Chrono
                );
        }
    }
}
