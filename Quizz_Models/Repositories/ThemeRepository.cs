using Quizz_Models.bdd_quizz;
using System;
using System.Linq;


namespace Quizz_Models.Services
{
    public class ThemeRepository
    {
        private readonly bdd_quizzContext bdd_entities = new bdd_quizzContext();

        public ThemeRepository() { }

        /* Theme */
        /// <summary>
        /// Retourne l'id de la complexite ou le nom correspond (sensible a la casse)
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public int GetIDThemeByNom(String prmNomComplexite)
        {
            return bdd_entities.Theme
            .Where(x => x.NomTheme == prmNomComplexite)
            .Single().PkTheme;
        }
    }
}
