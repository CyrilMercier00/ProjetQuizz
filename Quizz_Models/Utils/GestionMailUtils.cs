using System;
using System.Net.Mail;
using System.Net.Mime;


namespace Quizz_Models.Utils
{
    class GestionMailUtils
    {
        public static MailMessage msg = new MailMessage();



        //fonction qui gere l'envoi des mail 
        public static void SendMail(string mailFrom, string nameFrom, string mailTo, string nomCandidat, string bodyMail)
        {
            try
            {
                msg.From = new MailAddress(mailFrom, nameFrom);
                msg.To.Add(new MailAddress(mailTo));
                //  msg.Subject = "Test de Compétense ";
                msg.Body = bodyMail;
                msg.IsBodyHtml = true;
                // Create SMTP.  
                SmtpClient smtp = new SmtpClient();

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential("comptequizztechnique@gmail.com", "QuizzTech625+");

                //smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                //send message
                smtp.Send(msg);
                Console.WriteLine("Mail envoyer");
            }
            catch (Exception message)
            {
                Console.WriteLine("Mail non envoyé" + message.Message + "");

            }
            finally
            {
                msg.Dispose();

            }
        }

        //methode gerent l'envoi du mail recruteur (utilise SendMail)
        public static void SendMailRecruteur(string NomRecruteur, string NomCandidat, string PdfToAttach)
        {
            string mailAutomatique = "comptequizztechnique@gmail.com";
            NomRecruteur = "Recruteur";
            NomCandidat = "Candidat";
            string mailToRecruteur = "comptequizztechnique@gmail.com";
            // string PdfToAttach = "C:/dev/Dev Projet Quizz/28_01_2021/ProjQuizz_oldold/ProjQuizz/Resources/Test.pdf";
            attachmentpdf(PdfToAttach);
            msg.Subject = "Test de Compétense " + NomCandidat;
            SendMail(mailAutomatique, NomRecruteur, mailToRecruteur, NomCandidat, contentMailRecruteur(NomRecruteur, NomCandidat));

        }
        //methode sui gerent l'envoi du mail candidat (utilise SendMail)
        public static void SendMailCandidat(string NomRecruteur, string NomCandidat)
        {
            string mailFRomRecruteur = "comptequizztechnique@gmail.com";
            NomCandidat = "Candidat";
            NomRecruteur = "recruteur";
            string mailToCandidat = "comptequizztechnique@gmail.com";

            msg.Subject = " Test de Compétense ";
            SendMail(mailFRomRecruteur, NomRecruteur, mailToCandidat, NomCandidat, contentMailCandidat(NomRecruteur, NomCandidat));

        }
        //methode sui gerent le contenu du mail candidat
        public static string contentMailCandidat(string NomRecruteur, string NomCandidat)
        {
            NomRecruteur = "nom recruteur";
            NomCandidat = "nom Candidat";
            String Url = "https:localhost/5001/Api/Quizz/xxxxxxxxx";
           // String UrlCode = "xxxxxxxxx";

            string htmlBody = "<html><body> Bonjour, <br><br>" + NomCandidat +
                "<h3>Suivez le lien Suivant pour réaliser le test de compétence :" + "<a href = \" " + Url + " \" >" + Url + "</ a ></h3>" +
                "<b>Pour information :</b><br>" +
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
                NomRecruteur +
                "</html></body> ";

            return htmlBody;



        }
        //methode sui gerent le contenu du mail recruteur
        public static string contentMailRecruteur(string NomRecruteur, string NomCandidat)
        {
            
           NomRecruteur = "nom recruteur";
           NomCandidat = "nom Candidat";

            string htmlBody = " <html><body> Bonjour, <br><br>" + NomRecruteur +
                "ceci est un mail automatique <br> " +
                "Vous trouverez ci-joint les resultas du test de compétence du candidat " + NomCandidat + "." +
                "Cordialement,<br>" +
                "</html></body> ";
            return htmlBody;

        }

        //methhode ajout piece joint au mail
        public static void attachmentpdf(string PdfToAttach)
        {
            // Create  the file attachment for this e-mail message.
            Attachment PdfAttachement = new Attachment(PdfToAttach, MediaTypeNames.Application.Pdf);

            msg.Attachments.Add(PdfAttachement);
        }
    }
}
