using System;
using System.Net.Mail;

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
    }
}
