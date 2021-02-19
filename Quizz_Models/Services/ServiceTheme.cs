using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using Quizz_Models.Repositories;

namespace Quizz_Models.Services
{
    public class ServiceTheme
    {
        readonly ThemeRepository repoTheme ;

        public ServiceTheme(ThemeRepository themeRepository) {
            repoTheme = themeRepository;
        }

        public List<Theme> GetAllThemes ()
        {
            return repoTheme.GetAllTheme();
        }

        public Theme GetThemeByNom(String prmNomTheme)
        {
            return repoTheme.GetThemeByNom(prmNomTheme);
        }
    }
}