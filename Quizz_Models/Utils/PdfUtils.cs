using System;
using System.IO;
using System.Runtime.InteropServices;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Web;
using Ubiety.Dns.Core;
using Microsoft.AspNetCore.Http;
using Grpc.Core;
using Org.BouncyCastle.Utilities;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.parser;
using Quizz_Models.bdd_quizz;

namespace Quizz_Models.Utils
{
    class PdfUtils
    {
        private static string pdfPath = @"C:\Users\Public\Downloads\Test.pdf";
        private static PdfWriter writer = new PdfWriter(pdfPath);
        private static PdfDocument pdf = new PdfDocument(writer);
        private static iText.Layout.Document document = new iText.Layout.Document(pdf);
        //********************************************************************************
        private static Compte candidat { get; set; }
        private static Compte recruteur{ get; set; }
        private static Compte question { get; set; } //Question
        private static Compte reponsesQuestion { get; set; } //Reponse
        private static Compte reponsesCandidat { get; set; } //Reponse
        private static Compte commentaireCandidat { get; set; }//Technologie
        private static Compte technologie { get; set; }//Technologie
        private static string nomCandidat { get; set; }//Technologie
        //modifier les attributs et methode pour faire le lien avec la bdd


        public PdfUtils()
        {
        }


        //Methode qui la creation du pdf avec son contenue le contenu du pdf 
        public static void ContentPdf(Quizz quizz,Compte candidatQuizz)
        {
            try
            {
                candidat = candidatQuizz;
                nomCandidat=candidat.Nom;
                
                //ajout attribut et modif methode

                PdfHeader();
                PdfSubHeader();
                ScoreTable();
                PdfPageNumber();
                PdfBody();
                
                //trouver solution envoi mail sans enregistrer

                document.Close();
                GestionMailUtils.SendMailRecruteur("toto", "titi", pdfPath,quizz);

                Console.WriteLine("pdf + mail 2 ok");
            }
            catch (Exception e)
            {
                Console.WriteLine("pb mail + pdf" + e);
            }

        }

        public static void pdfmemory() {
           

            PdfWriter writer = PdfWriter.GetHighPrecision(document, new FileStream(Server.MapPath(~/ Times /) + pdf.GetPdfObject, FileMode.CreateNew));


            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);

            IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(pdfDocument, writer)));

            XMLWorker worker = new XMLWorker(pipeline, true);
            XMLParser xmlParse = new XMLParser(true, worker);

            this.Page.RenderControl(htw);
            StringReader sr = new StringReader(sw.ToString());
            xmlParse.Parse(sr);
            xmlParse.Flush();
            pdfDocument.Close();
            //Response.Write(pdfDocument);
            Response.End();
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
            Paragraph recruter = new Paragraph(" Recruteur : ")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);

            Paragraph candidat = new Paragraph(" Candidat : ")
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

            Paragraph subheader = new Paragraph(" Technologie : ")
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
               .Add(new Paragraph(" Nombre de question"));
            Cell cell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.BLUE)
               .SetTextAlignment(TextAlignment.RIGHT)
               .Add(new Paragraph("Nombre de bonne réponse"));

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
