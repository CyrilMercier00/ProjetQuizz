﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Quizz_Models
{
    class MailUtisl
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
            catch(FormatException)
            {
                return false;
            }

            return true;
        }
    }
}
