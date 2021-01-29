using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizz_Models.Services
{
    public class QuizzRepository
    {
        bdd_quizzEntities bdd_entities;
        ComplexiteRepository repoComplex;
        QuestionRepository repoQuest;

        public QuizzRepository ()
        {

        }


        /// <summary>
        /// La methode va generer un quizz avec un nombre de question donné et associé au theme.
        /// </summary>
        /// <param name="prmNBQuestion">Nombre de questions total a generer</param>
        /// <param name="prmComplex">Nom du niveau de complexité du quizz. Utilisé pour savoir combiens de questions doivent etre generer pour chaques diffucltés</param>
        /// <param name="prmTheme">Nom du theme du quizz et des questions</param>
        /// <param name="prmChrono">Le temps que le candidat aura pour passer le quizz</param>
        /// <returns>Retourne l'entitée du quizz généré ou null si il y a eu une erreur</returns>
        public quizz GenererQuizz(int prmNBQuestion, String prmComplex, String prmTheme, TimeSpan prmChrono)
        {
            quizz valRet = null;
            try
            {
                quizz quizzCreation = new quizz();         // Le nouveau quizz
                List<question> listQuestionCreation = new List<question>();    // La liste des questions choisies
                List<String> listComplexite;                // Contient tout les nom des taux de compléxité
                List<int?> listTauxComplex;                 // Contient les taux de complexité pour le niveau demandé

                listTauxComplex = repoComplex.GetComplexiteByNom (prmComplex);                  // Recuperer une liste avec les 3 taux de complexité


                // Ajouter quizz dans la base
                bdd_entities.quizz.Add(quizzCreation);
                Console.WriteLine($"L'objet a été inséré avec les parametres: complexite = {quizzCreation.taux_complexite.niveau} et theme= {quizzCreation.theme.nom_theme}");

                listComplexite = repoComplex.GetAllNomComplexite();                             // Recuperer tout les niveau de complexité possibles 

                // Generer 
                for (int i = 0; i < listComplexite.Count(); i++)
                {   // Calcul du nombre de question necessaire pour ce niveau de complexité
                    int nbQuest = (int)Math.Round(
                        prmNBQuestion /                                              // Nb question / % question
                        float.Parse("0." + listTauxComplex[i].ToString())          // Transformation du int en % (70 => 0.70)
                        );

                    repoQuest.GenererQuestions (listQuestionCreation, nbQuest, prmTheme, listComplexite[i]);
                    Console.WriteLine($"{nbQuest} ont été générées pour la difficultée {listComplexite[i]}");
                }

                repoQuest.MAJManyToManyQuest (listQuestionCreation, quizzCreation);           // Relier les questions a la table quizz
                valRet = quizzCreation;
                //
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return valRet;
        }

        /// <summary>
        /// Méthode qui insère une permission.
        /// </summary>
        /// <param name="permissionEntity">Entité de la permission</param>
        public void InsertPermission(permission permissionEntity)
        {
            bdd_entities.permission.Add(permissionEntity);
        }

        /// <summary>
        /// Méthode qui cherche une permission par ses différentes valeurs.
        /// </summary>
        /// <param name="permissionEntity">Entité de la permission</param>
        /// <returns>Retourne la permission trouvée ou lance une exception si aucune n'a été trouvée.</returns>
        public permission FindPermissionByValues(permission permissionEntity)
        {
            return bdd_entities.permission
                    .Where(x => x.ajouter_quest == permissionEntity.ajouter_quest
                        && x.generer_quizz == permissionEntity.generer_quizz
                        && x.modifier_quest == permissionEntity.modifier_quest
                        && x.suppr_question == permissionEntity.suppr_question)
                    .Single();
        }
    }
}