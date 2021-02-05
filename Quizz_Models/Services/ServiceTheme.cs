using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_Models.Services
{
    public class ServiceTheme
    {
        readonly ThemeRepository RepoTheme ;

        public ServiceTheme() {
            RepoTheme = new ThemeRepository();
        }

        public List<Theme> GetAllThemes ()
        {
            return RepoTheme.GetAllTheme();
        }
    }
}