﻿using Quizz_Models.bdd_quizz;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Quizz_Models.Repositories
{
    public class ThemeRepository
    {
        private readonly bdd_quizzContext bdd_entities ;

        public ThemeRepository() { }

        /* Theme */
        /// <summary>
        /// Retourne l'id de la complexite ou le nom correspond (sensible a la casse)
        /// </summary>
        /// <param name="prmNomComplexite"></param>
        /// <returns></returns>
        public int GetIDThemeByNom(String prmNomTheme)
        {
            return bdd_entities.Theme
            .Where(x => x.NomTheme == prmNomTheme)
            .Single().PkTheme;
        }
        /// <summary>
        /// Retourne l'objet Teme en fonction du nom du theme passé
        /// </summary>
        /// <param name="prmNiveauComplex"></param>
        /// <returns></returns>
        public Theme GetThemeByNom ( String prmNiveauComplex )
        {
            return bdd_entities.Theme
            .Where (x => x.NomTheme.Equals (prmNiveauComplex))
            .Single ();
        }
        /// <summary>
        /// Retourne tout ojets theme
        /// </summary>
        /// <param name="prmNiveauComplex"></param>
        /// <returns></returns>
        public List<Theme> GetAllTheme()
        {
            return bdd_entities.Theme
                .ToList();
        }
    }
}
