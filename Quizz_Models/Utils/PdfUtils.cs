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

namespace Quizz_Models.Utils
{
    class PdfUtils
    {
        // public static PdfWriter writer = new PdfWriter("C:\\Users\\IB\\Desktop\\Test\\Test.pdf");
        public static PdfWriter writer = new PdfWriter("C:\\*\\*\\*\\Downloads\\Test.pdf");
        public static PdfDocument pdf = new PdfDocument(writer);
        public static iText.Layout.Document document = new iText.Layout.Document(pdf);
   



        public void SavePdf()
        {
           

        }

        public static void ContentPdf()
        {
            PdfHeader();
            PdfSubHeader();
            ScoreTable();
            PdfPageNumber();
            PdfBody();
            document.Close();

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

            Paragraph subheader = new Paragraph(" Technologie : C# ")
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
