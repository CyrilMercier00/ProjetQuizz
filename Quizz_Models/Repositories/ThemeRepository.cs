using System;
using System.Linq;


namespace Quizz_Models.Services
{
    public class ThemeRepository
    {
        bdd_quizzEntities bdd_entities;

        public ThemeRepository () { }

        /* Theme */
        /// <summary>
        /// Retourne l'id de la complexite ou le nom correspond (sensible a la casse)
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public int GetIDThemeByNom ( String prmNomComplexite )
        {
            return bdd_entities.theme
            .Where (x => x.nom_theme == prmNomComplexite)
            .Single ().pk_theme;
        }
    }
}
