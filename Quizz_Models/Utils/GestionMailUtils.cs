using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Quizz_Models.Utils
{
    class GestionMailUtils
    {

            public static MailMessage msg = new MailMessage();



            //public void CreateMail()
            //{
            //    try
            //    {
            //        string mailFrom = "test@gmail.com";
            //        string nomFrom = "Recruteur";
            //        string mailTo = "sabrina.arif@outlook.fr";



            //        msg.From = new MailAddress(mailFrom, nomFrom);
            //        msg.To.Add(new MailAddress(mailTo));
            //        msg.Subject = "Test de Compétende ";
            //        msg.Body = "test";
            //        // Creat SMTP.  
            //        SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587);

            //        // Send the message.  
            //        smtp.Send(msg);
            //        MessageBox.Show("Mail envoyer");
            //    }
            //    catch (Exception message)
            //    {
            //        MessageBox.Show("probleme envoi" + message.Message + "");

            //    }

            //}
            public void SendMail(string mailFrom, string nameFrom, string mailTo, string nomCandidat, string bodyMail)
            {
                try
                {
                    msg.From = new MailAddress(mailFrom, nameFrom);
                    msg.To.Add(new MailAddress(mailTo));
                    msg.Subject = "Test de Compétende ";
                    msg.Body = "test";
                    msg.IsBodyHtml = true;
                // Create SMTP.  
                SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587);
                    smtp.Send(msg);
                    //MessageBox.Show("Mail envoyer");
                }
                catch (Exception message)
                {
                   // string erreur = message;

                }
            }
            public void SendMailRecruteur()
            {
                string mailRecruteur = "test@gmail.com";
                string NomRecruteur = "Recruteur";
                string NomCandidat = "Candidat";
                string mailTo = "sabrina.arif@outlook.fr";

                msg.Subject = "Test de Compétense " + NomCandidat;
                SendMail(mailRecruteur, NomRecruteur, mailTo, NomCandidat, contentMailCandidat(NomRecruteur, NomCandidat));

            }
            public void SendMailCandidat()
            {
                string mailCandidat = "test@gmail.com";
                string NomCandidat = "Candidat";
                string NomRecruteur = "recruteur";
                string mailTo = "sabrina.arif@outlook.fr";

                msg.Subject = " Test de Compétense ";
                SendMail(mailCandidat, NomRecruteur, NomCandidat, mailTo, contentMailCandidat(NomRecruteur, NomCandidat));


            }

            public static string contentMailCandidat(string NomRecruteur, string NomCandidat)
            {
                NomRecruteur = "nom recruteur";
                NomCandidat = "nom Candidat";

                string htmlBody = "<html><body> Bonjour, <br><br>" + NomCandidat +
                    "<h1>Suivez le lien Suivant pour réaliser le test de compétence : </h1>" +
                    "<b>Pour information :</b><br><br>" +
                    "<li>Le Test est à réliser sans limite de temps," +
                        "<br> un chronométre vous indiqueras le temps passer sur le test <br> " +
                        "et seras envoyer à votre recruteur. " +
                    "</li> <br>" +
                    "<li>Penser à verifier vos reponses avant de les valider, <br>" +
                    "car il ne seras pas possible de revenir en arrière" +
                    "</li><br>" +
                    "<li> Une fois le test terminer, les resultats vous serons communiquer par le recruteur" +
                    "</li><br><br>" +
                    "Cordialement,<br>" +
                    NomRecruteur+
                    "</html></body> ";
                    
                return htmlBody;

            }
            public static string contentMailRecruteur()
            {
                string NomRecruteur = "nom recruteur";
                string NomCandidat = "nom Candidat";

                string htmlBody = " <html><body> Bonjour, <br><br>" + NomRecruteur +
                    "ceci est un mail automatique <br> " +
                    "Vous trouverez ci-joint les resultas du test de compétence du candidat " + NomCandidat + "." +
                    "Cordialement,<br>"+
                    "</html></body> ";
                return htmlBody;

            }
        
    }


}

