using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using System;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/compte")]
    public class ControllerTheme : Controller
    {
        readonly ServiceTheme servTheme ;

        public ControllerTheme()
        {
            this.servTheme = new ServiceTheme();
        }

        [HttpGet]
        public void Get()
        {
            this.servTheme.GetAllThemes();
        }

    }
}
