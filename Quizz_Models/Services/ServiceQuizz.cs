using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using Quizz_Models.Repositories;
//
namespace Quizz_Models.Services
{
    public class ServiceQuizz
    {
        readonly ComplexiteRepository repoComplex;
        readonly QuestionRepository repoQuest;
        readonly QuizzRepository repoQuizz;
        readonly ThemeRepository repoTheme;
        readonly CompteRepository repoCompte;
       // readonly Compte repoCompteQuizz;


        public ServiceQuizz(ComplexiteRepository complexiteRepository, QuestionRepository questionRepository, QuizzRepository quizzRepository, ThemeRepository themeRepository, CompteRepository compteRepository)
        {
            repoComplex = complexiteRepository;
            repoQuest = questionRepository;
            repoQuizz = quizzRepository;
            repoTheme = themeRepository;
            repoCompte = compteRepository;
        }



        /// <summary>
        /// Retourne le quizz avec l'id passsé
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <returns></returns>
        public Quizz FindByID(int prmIDQuizz)
        {
            return repoQuizz.GetQuizzByID(prmIDQuizz);
        }



        /// <summary>
        /// Lie un compte a un quizz
        /// </summary>
        /// <param name="prmIDQuizz"></param>
        /// <param name="prmIDCandidat"></param>
        public int assignCandidatToQuizz(int prmIDQuizz, int prmIDCandidat)
        {
            repoQuizz.InsertLiaisonCompte(prmIDQuizz, new CompteQuizz()
            {
                FkCompte = prmIDCandidat,
                FkQuizz = prmIDQuizz
            });

         //   int prmIDRecruteurQuizz = repoCompte.GetComptebyIdQuizz(prmIDQuizz);
          //  SendMailQuizz(prmIDQuizz, prmIDCandidat, prmIDRecruteurQuizz);
            return repoQuizz.Sauvegarde();
        }





        /// <summary>
        /// La methode va generer un quizz avec un nombre de question donné et associé au theme.
        /// </summary>
        /// <param name="prmNBQuestion">Nombre de questions total a generer</param>
        /// <param name="prmComplex">Nom du niveau de complexité du quizz. Utilisé pour savoir combiens de questions doivent etre generer pour chaques diffucltés</param>
        /// <param name="prmTheme">Nom du theme du quizz et des questions</param>
        /// <param name="prmChrono">Le temps que le candidat aura pour passer le quizz</param>
        /// /// <param name="prmUrlCode">Le code unique associer au quizz dans l'url</param>
        /// <returns>Retourne l'entitée du quizz généré ou null si il y a eu une erreur</returns>
        public void GenererQuizz(QuizzDTO prmDTO)
        {
            Theme leTheme = repoTheme.GetThemeByNom(prmDTO.Theme);                             // Objet theme pour ce param
            TauxComplexite leTaux = repoComplex.GetComplexiteByNom(prmDTO.Complexite);         // Objet taux de complexite pour ce param
            List<Question> listQuestionCreation = new List<Question>();                        // La liste des questions choisies
            String leCodeUrl = Utils.GenerateUrl.GenerateCodeUrl();                            // Génere un code unique pour l'url

            // Le nouveau quizz
            Quizz quizzCreation = new Quizz()
            {
                FkTheme = leTheme.PkTheme,
                FkComplexite = leTaux.PkComplexite,
                Chrono = TimeSpan.Parse(prmDTO.Chrono),
                Urlcode = prmDTO.Urlcode
            };

            //Ajouter code Unique pour l'url du Quizz
            quizzCreation.Urlcode = leCodeUrl;

            // Ajouter des questions dans la liste des questions
            GenererQuestions(listQuestionCreation, prmDTO.NbQuestions, leTheme);

            // Traquer le quizz pour permettre un updates
            repoQuizz.AttachQuizz(quizzCreation);

            // Créer un objet de liaison
            quizzCreation.CompteQuizz.Add(new CompteQuizz
            {
                FkCompte = prmDTO.FKCompteRecruteur,
                FkQuizz = quizzCreation.PkQuizz,
                EstCreateur = Convert.ToByte(true)
            });

            // Creation d'une list de questions associées au quizz
            foreach (Question q in listQuestionCreation)        // Pour chaques questions
            {
                QuizzQuestion qq = new QuizzQuestion            // Nouvel objet liaison
                {
                    FkQuestionNavigation = q,                   // PK de cette question
                    FkQuizzNavigation = quizzCreation           // PK du quizz généré
                };

                quizzCreation.QuizzQuestion.Add(qq);            // Ajouter a la liste d'objet de liaisons
            }

            // Sauvegarde & throw si aucunes ligne insert
            repoQuizz.InsertQuizz(quizzCreation);
            if (repoQuizz.Sauvegarde() <= 1)
            {
                throw new Exception("Probleme lors de la sauvegarde du quizz");
            }

        }
        //Envoi  un mail au candidat avec l'url
        public void SendMailQuizz(int prmIDQuizz, int prmIDCandidat, int prmIDRecruteur)
        {
            //****envoi automatique mail candidat à l'assignation
            Quizz quizz = repoQuizz.GetQuizzByID(prmIDQuizz);

            Compte compteCandidat = repoCompte.GetCompteByID(prmIDCandidat);
            Compte compteRecruteur = repoCompte.GetCompteByID(prmIDRecruteur);

            Utils.GestionMailUtils.SendMailCandidat(compteRecruteur, compteCandidat, quizz);
            //********
        }

        //Cree le pdf recrutrue et envoi  un mail au recruteur

        public void SendMailFinQuizz(int prmIDQuizz,int prmIDCandidat, int prmIDRecruteur)
        {
            //Cree le pdf recrutrue et envoi  un mail au recruteur  
            Quizz quizz= repoQuizz.GetQuizzByID(prmIDQuizz);
            Compte candidatQuizz = repoCompte.GetCompteByID(prmIDCandidat);
            Compte recruteurQuizz= repoCompte.GetCompteByID(prmIDRecruteur);

            
            Utils.PdfUtils.ContentPdf(quizz, candidatQuizz, recruteurQuizz);
         
        }
        

        private void GenererQuestions(List<Question> prmListQuestions, int prmNBQuestTotal, Theme prmThemeQuestions)
        {
            // Gen questions junior
            repoQuest.GenererQuestions(
                prmListQuestions,
                CalculerNombreQuestion(prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.junior),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.junior
            );

            // Gen questions confirmé
            repoQuest.GenererQuestions(
                prmListQuestions,
                CalculerNombreQuestion(prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.confirme),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.confirme
            );

            // Gen questions experimenté
            repoQuest.GenererQuestions(
                prmListQuestions,
                CalculerNombreQuestion(prmNBQuestTotal, Globales.EnumNiveauxComplexiteDispo.experimente),
                prmThemeQuestions,
                Globales.EnumNiveauxComplexiteDispo.experimente
            );
        }



        public void SupprimerQuizz(int prmIDQuizz)
        {
            try
            {
                repoQuizz.SupprimerQuizz(repoQuizz.GetQuizzByID(prmIDQuizz));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        /// <summary>
        /// Calcul le nombre de question de chaque niveau pour un taux de complexité du quizz defini
        /// </summary>
        /// <param name="prmNBQuestion"> nombre de question total du quizz</param>
        /// <param name="prmTauxComplexiteQuizz"> taux de complexité du quizz</param>
        /// <returns></returns>
        private int CalculerNombreQuestion(int prmNBQuestionTotal, Enum prmNomComplex)
        {
            String complex = prmNomComplex.ToString().ToLower();

            var valRet = complex switch
            {
                "junior" => repoComplex.GetComplexiteByNom(prmNomComplex.ToString()).QuestionJunior.GetValueOrDefault(),
                "confirme" => repoComplex.GetComplexiteByNom(prmNomComplex.ToString()).QuestionConfirme.GetValueOrDefault(),
                "experimente" => repoComplex.GetComplexiteByNom(prmNomComplex.ToString()).QuestionExperimente.GetValueOrDefault(),
                _ => throw new Exception("Le taux de complexitée n'existe pas"),
            };

            String s1 = prmNBQuestionTotal.ToString();
            String s2 = "0." + valRet.ToString();
            float n1 = float.Parse(s1);
            float n2 = float.Parse(s2.Replace(".", ","));
            return (int)Math.Round(n1 * n2);
        }



        /// <summary>
        /// Retourne le quizz avec le code passé en parametre. Retourne null si le code n'est pas valide
        /// </summary>
        /// <returns>Liste de toute les permissions sous format PermissionDTO.</returns>
        public QuizzDTO GetQuizz(string prmCodeQuizz)
        {
            Quizz quizz = this.repoQuizz.GetQuizzByCode(prmCodeQuizz);
            QuizzDTO retour;

            if (quizz != null)
            {
                retour = TransformQuizzToQuizzDTO(quizz);
            }
            else
            {
                retour = null;
            }
            return retour;
        }



        private QuizzDTO TransformQuizzToQuizzDTO(Quizz quizz)
        {
            return new QuizzDTO
            {
                PkQuizz = quizz.PkQuizz,
                NbQuestions = quizz.PkQuizz,
                Chrono = Convert.ToString(quizz.Chrono),
                Theme = Convert.ToString(quizz.FkTheme),
                Complexite = Convert.ToString(quizz.FkComplexite),
                Urlcode = quizz.Urlcode

            };
        }
    }
}
