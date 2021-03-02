using System;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using iText.Layout.Properties;
using Quizz_Models.bdd_quizz;

namespace Quizz_Models.Utils
{
    class PdfUtils
    {
        public static string pdfPath = @"..\TestCompetence.pdf";
        //private static string pdfPath = @"C:\Users\Public\Downloads\Test.pdf";
        private static PdfWriter writer = new PdfWriter(pdfPath);
        private static PdfDocument pdf = new PdfDocument(writer);
        private static iText.Layout.Document document = new iText.Layout.Document(pdf);
        //********************************************************************************
        private static Compte candidat { get; set; }
        private static Compte recruteur{ get; set; }
        private static string question { get; set; } //Question
        private static string reponsesQuestion { get; set; } //Reponse q
        private static string reponsesCandidat { get; set; } //Reponse C
        private static string commentaireCandidat { get; set; }//Technologie
        private static string technologie { get; set; }//Technologie
        private static string nomCandidat { get; set; }//nom
        private static string prenomCandidat { get; set; }//nom
        private static string nomRecruteur { get; set; }//nom
        private static string prenomRecruteur { get; set; }//nom
        //modifier les attributs et methode pour faire le lien avec la bdd


        public PdfUtils()
        {
        }


        //Methode qui la creation du pdf avec son contenue le contenu du pdf 
        public static void ContentPdf(Quizz quizz,Compte candidatQuizz, Compte recruteurQuizz)
        {
            try
            {
                candidat = candidatQuizz;
                recruteur = recruteurQuizz;
                nomCandidat =candidat.Nom;
                prenomCandidat = candidat.Prenom;
                nomRecruteur = recruteur.Nom;
                prenomRecruteur = recruteur.Prenom;

                //ajout attribut et modif methode

                PdfHeader();
                PdfSubHeader();
                ScoreTable();
                PdfPageNumber();
                PdfBody();
                
                document.Close();
                writer.Dispose();

                document.Close();
              //  GestionMailUtils.SendMailRecruteur(nomCandidat, prenomCandidat, nomRecruteur, prenomRecruteur, pdfPath,quizz);
                System.IO.File.Delete(pdfPath);
                Console.WriteLine("pdf + mail 2 ok");
            }
            catch (Exception e)
            {
                Console.WriteLine("prob mail + pdf" + e);
            }
            finally
            {
                document.Close();
                writer.Dispose();

            }

        }


        public static void PdfLogo()
        {
            // Add image
            Image img = new Image(ImageDataFactory
               .Create(@"..\..\image.jpg"))
               .SetTextAlignment(TextAlignment.CENTER);
            document.Add(img);
        

        }
        public static void PdfHeader()
        {
            Paragraph recruter = new Paragraph(" Recruteur : "+ nomRecruteur + " " + prenomRecruteur)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);

            Paragraph candidat = new Paragraph(" Candidat : "+ nomCandidat+ " " +prenomCandidat)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);

            Paragraph header = new Paragraph(" Test Competence ")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);

            document.Add(recruter);
            document.Add(candidat);
            document.Add(header);
          

        }
        public static void PdfBody() 
        {

            Paragraph question = new Paragraph(" Question ")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(15);
            document.Add(question);

            Paragraph reponse = new Paragraph(" Reponse")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);
            document.Add(reponse);

            Paragraph reponsecandidat = new Paragraph(" Reponsecandidat ")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(15);
            document.Add(reponsecandidat);

            Paragraph commentaireCandidat = new Paragraph(" Commentaire Candidat ")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);
            document.Add(commentaireCandidat);
            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
            
        }
        public static void PdfSubHeader()
        {

            Paragraph subheader = new Paragraph(" Technologie : " + technologie )
                .SetTextAlignment(TextAlignment.CENTER)
                .SetUnderline()
                .SetFontSize(15);
            document.Add(subheader);
            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

        }
        public static void PdfPageNumber() 
        {
            // Page numbers
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                    .Format("page" + i + " of " + n)),
                    559, 806, i, TextAlignment.CENTER,
                    VerticalAlignment.BOTTOM, 0);
            }
        }

        public static void ScoreTable ()
        {
            // Table
            Table scoreTable = new Table(2, false);
            Cell cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.BLUE)
               .SetTextAlignment(TextAlignment.RIGHT)
               .Add(new Paragraph(" Nombre de question "));
            Cell cell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.BLUE)
               .SetTextAlignment(TextAlignment.RIGHT)
               .Add(new Paragraph("Nombre de bonne réponse "));

            Cell cell21 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("10"));
            Cell cell22 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("10"));

            scoreTable.AddCell(cell11);
            scoreTable.AddCell(cell12);
            scoreTable.AddCell(cell21);
            scoreTable.AddCell(cell22);

            document.Add(scoreTable);

        }
    }
}
