using Quizz_Models.bdd_quizz;
using System;
using System.Net.Mail;
using System.Net.Mime;
using Quizz_Models.Repositories;
using EO.WebBrowser.DOM;

namespace Quizz_Models.Utils
{
    class GestionMailUtils
    {
        public static MailMessage msg = new MailMessage();
       // private readonly ThemeRepository _ThemeRepository;
        const string MailCredential = "comptequizztechnique@gmail.com";
        const string PswCredential = "QuizzTech625+";
        //const string UrlSite = "https://localhost:5001/api/quizz/";
        const string UrlSite = "https://localhost:44380/page-demarrage/";
        //public GestionMailUtils(ThemeRepository ThemeRepository)
        //{
        //    _ThemeRepository = ThemeRepository;
        //}


        //fonction qui gere l'envoi des mail 
        public static void SendMail(string mailFrom, string nameFrom, string mailTo, string bodyMail)
        {
            try
            {
                msg.From = new MailAddress(mailFrom, nameFrom);
                msg.To.Add(new MailAddress(MailCredential));
                msg.To.Add(new MailAddress(mailTo));

                msg.Body = bodyMail;
                msg.IsBodyHtml = true;
                // Create SMTP.  
                SmtpClient smtp = new SmtpClient();

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(MailCredential, PswCredential);

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
       
        public static void SendMailRecruteur(Compte CompteRecruteur, string PdfToAttach, Compte CompteCandidat, Quizz quizz)
        {
            string mailAutomatique = MailCredential;
            //string mailToRecruteur = MailCredential;
            string mailToRecruteur = CompteRecruteur.Mail;
            string nomCandidat = CompteCandidat.Nom;
            string nomRecruteur = CompteRecruteur.Nom;
            string prenomCandidat = CompteCandidat.Prenom;
            string prenomRecruteur = CompteRecruteur.Prenom;
            // string PdfToAttach = "C:/dev/Dev Projet Quizz/28_01_2021/ProjQuizz_oldold/ProjQuizz/Resources/Test.pdf";
            attachmentpdf(PdfToAttach);
            msg.Subject = "Test de Compétense " + nomCandidat+ " "+ prenomCandidat;

            //SendMail(mailAutomatique, NomRecruteur, mailToRecruteur, contentMailRecruteur(NomRecruteur, NomCandidat, quizz));


            SendMail(mailAutomatique, nomRecruteur, mailToRecruteur, contentMailRecruteur(nomRecruteur, nomCandidat, prenomCandidat, prenomRecruteur, quizz));


        }

        //************************relation bdd 
        //methode sui gerent l'envoi du mail candidat (utilise SendMail)
        public static void SendMailCandidat(Compte CompteRecruteur, Compte CompteCandidat, Quizz quizz)
        {
            string mailFromRecruteur = MailCredential; //CompteRecruteur.Mail 
            
            //string mailFromRecruteurCCi = CompteRecruteur.Mail;

            string NomCandidat = CompteCandidat.Nom;
            string NomRecruteur = CompteRecruteur.Nom;
            string PrenomCandidat = CompteCandidat.Prenom;
            string prenomRecruteur = CompteRecruteur.Prenom;

            //string mailToCandidat = "\"CompteCandidat.Mail\"";
            string mailToCandidat = CompteCandidat.Mail;
            //string mailToCandidat = MailCredential;


            msg.Subject = "Test de Compétence ";

            SendMail(mailFromRecruteur, NomRecruteur, mailToCandidat, contentMailCandidat(NomRecruteur, NomCandidat, PrenomCandidat, prenomRecruteur, quizz));

        }
        //*****************************


        //methode sui gerent le contenu du mail candidat
        public static string contentMailCandidat(string NomRecruteur, string NomCandidat, string prenomCandidat, string prenomRecruteur, Quizz quizz)
        {
            String UrlCode = quizz.Urlcode;
            String Url = UrlSite + UrlCode;


            string htmlBody = "<html><body> Bonjour, <br><br>" + NomCandidat + " " + prenomCandidat +
                "<h3>Suivez le lien Suivant pour réaliser le test de compétence : " + "<a href = \" " + Url + " \" >" + Url + "</ a ></h3>" +
                "<b>Pour information :</b><br>" +
                "<li>Le Test est à réaliser sans limite de temps," +
                 "<br> un chronomètre vous indiqueras le temps passé sur le test <br> " +
                 "et seras envoyé à votre recruteur. " +
                "</li> <br>" +
                "<li>Penser à vérifier vos réponses avant de les valider, <br>" +
                "car il ne sera pas possible de revenir en arrière" +
                "</li><br>" +
                "<li> Une fois le test terminé, les résultats vous seront communiqués par le recruteur" +
                "</li><br><br>" +
                "Cordialement,<br>" +
                NomRecruteur + " " + prenomRecruteur +
                "</html></body> ";

            return htmlBody;



        }
        //methode sui gerent le contenu du mail recruteur
        public static string contentMailRecruteur(string NomRecruteur, string NomCandidat, string prenomCandidat, string prenomRecruteur, Quizz quizz)
        {


    
            string htmlBody = " <html><body> Bonjour, <br><br>" + NomRecruteur +" "+ prenomRecruteur +
                "<br><b>Ceci est un mail automatique </b><br> " +
                "Vous trouverez ci-joint les resultas du test de compétence du candidat " + NomCandidat + " " + prenomCandidat +
                "<br><br>Cordialement,<br>" +
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
