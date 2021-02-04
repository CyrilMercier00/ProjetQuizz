﻿using System;
using System.Reflection;
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
            for(int i = 0; i < c2.GetType().GetProperties().Length; i++)
            {
                Tuple<PropertyInfo, PropertyInfo> tuple = GetCorrespondingProperty(c1, c2, i);
                var valproperty2 = tuple.Item2.GetValue(c2);

                if (tuple.Item1 != null && tuple.Item1.Name.CompareTo("Mail") == 0)
                {
                    if (!VerifyMail((string)valproperty2)) continue;
                }

                if (tuple.Item1 != null && valproperty2 != null)
                {
                    tuple.Item1.SetValue(c1, valproperty2);
                }
            }
        }

        public static void ModifyPermission(ref Permission p1, PermissionDTO p2)
        {
            for (int i = 0; i < p2.GetType().GetProperties().Length; i++)
            {
                Tuple<PropertyInfo, PropertyInfo> tuple = GetCorrespondingProperty(p1, p2, i);
                var valproperty2 = tuple.Item2.GetValue(p2);

                if (tuple.Item1 != null && valproperty2 != null)
                {
                    tuple.Item1.SetValue(p1, valproperty2);
                }
            }
        }

        /// <summary>
        /// Extrait la ieme propriété du 2eme paramètre et cherche une propriété correspondante dans le premier paramètre.
        /// </summary>
        /// <param name="c1">Première entité.</param>
        /// <param name="c2">Deuxième entité.</param>
        /// <param name="i">Compteur.</param>
        private static Tuple<PropertyInfo, PropertyInfo> GetCorrespondingProperty(Object c1, Object c2, int i)
        {
            var property2 = c2.GetType().GetProperties()[i];
            return Tuple.Create(c1.GetType().GetProperty(property2.Name), property2);
        }
    }
}
