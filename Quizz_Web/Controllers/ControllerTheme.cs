using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/theme")]
    public class ControllerTheme : Controller
    {
        readonly ServiceTheme servTheme;

        public ControllerTheme()
        {
            this.servTheme = new ServiceTheme();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.servTheme.GetAllThemes());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }



        [HttpGet("{id}")]
        public IActionResult Get(String prmNomTheme)
        {
            if (float.TryParse(prmNomTheme, out float n))
            {
                try
                {
                    return Ok(this.servTheme.GetThemeByNom(prmNomTheme));
                }
                catch (Exception e)
                {
                    return NotFound(e.Message);
                }
            } else
            {
                return BadRequest("Le parametre n'est pas un nom");
            }
        }
    }
}
