using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizz_Models.DTO;

namespace Quizz_Models.Services
{
    public class ThemeRepository    {
        public ThemeRepository () { }

        /* Theme */
        /// <summary>
        /// Retourne l'id de la complexite ou le nom correspond (sensible a la casse)
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        private int GetIDThemeByNom(String prmNomComplexite)
        {
            return bdd_entities.theme
            .Where(x => x.nom_theme == prmNomComplexite)
            .Single().pk_theme;
        }
    }
}
