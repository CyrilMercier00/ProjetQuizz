using System;
using System.Net.Mail;
using Quizz_Models.DTO;
using Quizz_Models.bdd_quizz;

namespace Quizz_Models
{
    class MailUtils
    {
        /// <summary>
        /// Méthode qui vérifie si un mail est valide.
        /// </summary>
        /// <param name="email">Email à vérifier</param>
        /// <returns>True si l'email est valide, faux sinon.</returns>
        public static bool VerifyMail(string email)
        {
            if (email.Length <= 0) return false;

            try
            {
                email = new MailAddress(email).Address;
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        public static bool VerifyMotDePasse(string mdp)
        {
            if (mdp == null) return false;
            if (mdp.Length <= 0 || mdp.Length > 20) return false;

            return true;
        }

        /// <summary>
        /// Modification des champs du compte passé en paramètre.
        /// </summary>
        /// <param name="c1">Compte à modifier.</param>
        /// <param name="c2">Valeur à affecter.</param>
        public static void ModifyCompte(ref Compte c1, ModifyCompteDTO c2)
        {
            c1.Nom = c2.Nom;
            c1.Prenom = c2.Prenom;
            c1.Mail = c2.Mail;
            c1.MotDePasse = c2.MDP;
        }
    }
}
