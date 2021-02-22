using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Repositories;
using System;

namespace Quizz_Models.Services
{
    public class QuestionService
    {
        readonly ThemeRepository repoTheme;
        readonly ComplexiteRepository repoComplex;
        readonly QuestionRepository repoQuestion;

        public QuestionService(ThemeRepository prmRepoTheme, ComplexiteRepository prmRepoComplex, QuestionRepository prmRepoQuestion)
        {
            this.repoTheme = prmRepoTheme;
            this.repoComplex = prmRepoComplex;
            this.repoQuestion = prmRepoQuestion;
        }


        /// <summary>
        /// Insertion d'un DTO dans la bdd & creation des naviagations
        /// </summary>
        /// <param name="prmDTO">DTO a inserer </param>
        /// <returns></returns>
        public int Insert(QuestionDTO prmDTO)
        {
            int nbLigneInsert;
            Question q = DTOConvert(prmDTO);

            repoQuestion.Insert(q);

            try
            {
                nbLigneInsert = repoQuestion.Sauvegarder();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                nbLigneInsert = -1;
            }

            return nbLigneInsert;
        }

        /// <summary>
        /// Convertion de d'un DTO en objet
        /// </summary>
        /// <param name="prmDTO"></param>
        /// <returns></returns>
        public Question DTOConvert(QuestionDTO prmDTO)
        {
            TauxComplexite c = repoComplex.GetComplexiteByNom(prmDTO.NomComplexite);
            Theme t = repoTheme.GetThemeByNom(prmDTO.NomTheme);

            return new Question()
            {
                Enonce = prmDTO.Enonce,
                FkComplexite = c.PkComplexite,
                FkComplexiteNavigation = c,
                FkTheme = t.PkTheme,
                FkThemeNavigation = t,
                RepLibre = Convert.ToByte(prmDTO.RepLibre)
            };
        }
    }
}
