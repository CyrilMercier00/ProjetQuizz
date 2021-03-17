using System;
using System.Collections.Generic;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using iText.Layout.Properties;
using Quizz_Models.bdd_quizz;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using Quizz_Web.Controllers;

namespace Quizz_Models.Utils
{
    class PdfUtils
    {
        // public static string pdfPath = @"..\TestCompetence.pdf";
        private static string pdfPath = @"C:\Users\Public\Downloads\TestCompetence.pdf";
        private static PdfWriter writer = new PdfWriter(pdfPath);
        private static PdfDocument pdf = new PdfDocument(writer);
        private static iText.Layout.Document document = new iText.Layout.Document(pdf);



        //********************************************************************************
        private static Compte Ccandidat { get; set; }
        private static Compte Crecruteur { get; set; }
        private static List<AffichageQuizzDto> listQuestion { get; set; } //Question
                                                                          //  private static string reponsesQuestion { get; set; } //Reponse q
                                                                          // private static ICollection<ReponseCandidat> reponsesCandidat { get; set; } //Reponse Candidat
                                                                          // private static string commentaireCandidat { get; set; }//commentaire
        private static string technologie { get; set; }//Technologie
        private static string nomCandidat { get; set; }//nom Ccandidat
        private static string prenomCandidat { get; set; }//prenom candidat
        private static string nomRecruteur { get; set; }//nom
        private static string prenomRecruteur { get; set; }//nom
        public static int Nb_QUEST { get; set; }
        public static int Nb_RepOk { get; set; }
        public static string Complexite { get; set; }
        public static AffichageQuizzDto affichageQuizz { get; set; }
        private static string chrono { get; set; }
        private static List<QuestionReponseDTO> listQuestionRep { get; set; } //Question
        private static List<QuestionReponseReponseCandidatDTO> listQuestionrepRepCDTO { get; set; }//question solution rep candidat
        public static Quizz quizz { get; set; }
        //modifier les attributs et methode pour faire le lien avec la bdd




        //Methode qui la creation du pdf avec son contenue le contenu du pdf 
        public static void ContentPdf(AffichageQuizzDto quizz, Compte candidatQuizz, Compte recruteurQuizz)
        {
            try
            {
                affichageQuizz = quizz;
                Ccandidat = candidatQuizz;
                Crecruteur = recruteurQuizz;
                nomCandidat = Ccandidat.Nom;
                prenomCandidat = Ccandidat.Prenom;
                nomRecruteur = Crecruteur.Nom;//modifier test
                prenomRecruteur = Crecruteur.Prenom;
                technologie = affichageQuizz.NomTheme;
                Complexite = affichageQuizz.Complexite;
                listQuestionRep = affichageQuizz.ListQuestionrep;
                listQuestionrepRepCDTO = affichageQuizz.ListQuestionrepRepCDTO;
                // listQuestion= GetQuestionReponsesRepCandidat();
                // question = affichageQuizz.ListeReponses;
                Nb_QUEST = affichageQuizz.NbQuestions;
                chrono = affichageQuizz.Chrono;
                Nb_RepOk = calculNote();


                //ajout attribut et modif methode

                PdfHeader();
                PdfSubHeader();
                NewLine();
                ScoreTable();

                QuizzTable();
                PdfBody();
                PdfPageNumber();
                //writer.SetCompressionLevel(9);
                document.Close();
                writer.Dispose();

                document.Close();
                GestionMailUtils.SendMailRecruteur(candidatQuizz, pdfPath, recruteurQuizz, quizz);
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
        public static void NewLine()
        {
            Paragraph newline = new Paragraph(new Text("\n"));
            document.Add(newline);
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
            Paragraph recruteur = new Paragraph(" Recruteur : " + nomRecruteur + " " + prenomRecruteur)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);

            Paragraph candidat = new Paragraph(" Candidat : " + nomCandidat + " " + prenomCandidat)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);

            Paragraph header = new Paragraph(" Test Compétences ")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);

            document.Add(recruteur);
            document.Add(candidat);
            document.Add(header);


        }
        public static void PdfBody()
        {


            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
         
            if (Nb_QUEST > 0)
            {
                for (int i = 0; i < Nb_QUEST; i++)
                {
                    NewLine();
                    int Nb_QuestTitre = i + 1;
                    Paragraph SubTitle = new Paragraph("Question " + Nb_QuestTitre + " : ")
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(20);
                    document.Add(SubTitle);


                 
                    if (listQuestionrepRepCDTO[i].ListeReponses is null)
                    {
                      

                        Paragraph questionV = new Paragraph("Énoncé: X")
                      .SetTextAlignment(TextAlignment.LEFT)
                      .SetFontSize(11);
                        document.Add(questionV);
                    }
                    else
                    {
                      
                        Paragraph question = new Paragraph(" Énoncé  : "+listQuestionrepRepCDTO[i].Enonce)
                      .SetTextAlignment(TextAlignment.LEFT)
                      .SetFontSize(11);
                        document.Add(question);
                    }

                    //TitleTable("Propositions réponses : ");
                    if (listQuestionrepRepCDTO[i].ListeReponses is null)
                    {
                       
                        Paragraph reponseV = new Paragraph("Propositions réponses :  X")
                         .SetTextAlignment(TextAlignment.LEFT)
                         .SetFontSize(11);
                        document.Add(reponseV);

                    }
                    else
                    {
                        
                        int nb = 1;
                        foreach (var n in listQuestionrepRepCDTO[i].ListeReponses)
                        {
                           
                            Paragraph reponse = new Paragraph("Proposition  réponses " + nb +" : " +n.Text)
                             .SetTextAlignment(TextAlignment.LEFT)
                             .SetFontSize(11);
                            document.Add(reponse);
                            nb++;
                        }
                    }
             

                    //TitleTable("Réponse Candidat : ");
                    if (listQuestionrepRepCDTO[i].RepCandidat is null) { }
                    else
                    {

                        if (listQuestionrepRepCDTO[i].RepCandidat.Reponse is null)
                        {

                            Paragraph reponsecandidatV = new Paragraph("Réponse Candidat :  X")
                                .SetFontColor(ColorConstants.RED)
                               .SetTextAlignment(TextAlignment.LEFT)
                               .SetFontSize(11);
                            document.Add(reponsecandidatV);

                      
                        }
                        else
                        {


                            if (listQuestionrepRepCDTO[i].RepCandidat.isTrue)
                            {
                                Paragraph reponsecandidatT = new Paragraph("Réponse Candidat :  " + listQuestionrepRepCDTO[i].RepCandidat.Reponse)
                                    .SetFontColor(ColorConstants.GREEN)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .SetFontSize(11);
                                document.Add(reponsecandidatT);

                            }
                            else
                            {
                                Paragraph reponsecandidatF = new Paragraph("Réponse Candidat :  " + listQuestionrepRepCDTO[i].RepCandidat.Reponse)
                                    .SetFontColor(ColorConstants.RED)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                        .SetFontSize(11);
                                document.Add(reponsecandidatF);
                               
                            }
                        }

                        if (listQuestionrepRepCDTO[i].RepCandidat.Reponse is null)
                        {

                            Paragraph reponsetrueorfalsevide = new Paragraph(" La réponse est fausse ")
                               .SetFontColor(ColorConstants.RED)
                               .SetTextAlignment(TextAlignment.LEFT)
                               .SetFontSize(11);
                            document.Add(reponsetrueorfalsevide);
                        }
                        else
                        {
                            if (listQuestionrepRepCDTO[i].RepCandidat.isTrue)
                            {
                                Paragraph reponsecandidatTrue = new Paragraph(" La réponse est bonne")
                                    .SetFontColor(ColorConstants.GREEN)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .SetFontSize(11);
                                document.Add(reponsecandidatTrue);
                            }
                            else
                            {
                                Paragraph reponsecandidatfalse = new Paragraph(" La réponse est fausse")
                                   .SetFontColor(ColorConstants.RED)
                                   .SetTextAlignment(TextAlignment.LEFT)
                                   .SetFontSize(11);
                                document.Add(reponsecandidatfalse);
                            }

                        }
                        NewLine();
                        // TitleTable("Commentaire candidat : ");

                        if (listQuestionrepRepCDTO[i].RepCandidat.Commentaire is null)
                        {
                           
                            Paragraph commentaireCandidatV = new Paragraph("Commentaire candidat : " + "  ")
                           .SetTextAlignment(TextAlignment.LEFT)
                           .SetFontSize(11);
                            document.Add(commentaireCandidatV);
                         

                        }
                        else
                        {
                            
                            Paragraph commentaireCandidat = new Paragraph("Commentaire candidat : " + listQuestionrepRepCDTO[i].RepCandidat.Commentaire)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(11);
                            document.Add(commentaireCandidat);
                            
                        }

                        
                        NewLine();
                        document.Add(ls);
                        
                    }
                }
            }
            document.Add(ls);

        }
        public static void PdfSubHeader()
        {

            Paragraph subheader = new Paragraph(" Technologie : " + technologie)
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
                    .Format("p" + i + "/" + n)),
                    600, 900, i, TextAlignment.RIGHT,
                    VerticalAlignment.BOTTOM, 0);
            }
        }
        public static int NoteSur20(int nb_Q, int nb_RepOk)
        {

            int nb_Note = nb_RepOk * 20;
            if (nb_Note > 0)
            { nb_Note = nb_Note / nb_Q; }
            else
            {
                nb_Note = 0;
            }

            return nb_Note;
        }
        public static void ScoreTable()
        {
            //Nb_RepOk = affichageQuizz.nbRepOK;
            //Nb_QUEST = affichageQuizz.NbQuestions;
            LineSeparator ls = new LineSeparator(new SolidLine());

            //Nb_RepOk = 10;
            int nb_Note = NoteSur20(Nb_QUEST, Nb_RepOk);
            // création Tableau avec 4 col
            Table scoreTable = new Table(4, true);

            //creation des cellule de la prem ligne
            Cell cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.CYAN)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Nombre de questions"));

            Cell cell12 = new Cell(1, 2)
               .SetBackgroundColor(ColorConstants.CYAN)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Nombre de bonnes réponses"));

            Cell cell13 = new Cell(1, 3)
                .SetBackgroundColor(ColorConstants.CYAN)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Note"));



            // Complexite
            //creation des cellule de la deuxieme ligne
            Cell cell21 = new Cell(2, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Nb_QUEST.ToString()));

            Cell cell22 = new Cell(2, 2)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(Nb_RepOk.ToString()));

            Cell cell23 = new Cell(2, 3)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph(nb_Note + " / 20 "));



            //ajout des cellules au tableau

            //1er ligne (5 col)
            scoreTable.AddCell(cell11);
            scoreTable.AddCell(cell12);
            scoreTable.AddCell(cell13);


            //2eme ligne (5 col)
            scoreTable.AddCell(cell21);
            scoreTable.AddCell(cell22);
            scoreTable.AddCell(cell23);


            //Ajout du tableau à la cellule 
            document.Add(scoreTable);
            document.Add(ls);




        }
        public static void QuizzTable()
        {

            LineSeparator ls = new LineSeparator(new SolidLine());

            // création Tableau avec 4 col
            Table TableQuizz = new Table(3, true);

            Cell qcell11 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.CYAN)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Temps total du quizz"));

            Cell qcell12 = new Cell(1, 2)
              .SetBackgroundColor(ColorConstants.CYAN)
              .SetTextAlignment(TextAlignment.CENTER)
              .Add(new Paragraph("Niveau"));

            Cell qcell21 = new Cell(2, 1)
           .SetTextAlignment(TextAlignment.CENTER)
           .Add(new Paragraph(chrono));

            Cell qcell22 = new Cell(2, 2)
             .SetTextAlignment(TextAlignment.CENTER)
             .Add(new Paragraph(Complexite));


            TableQuizz.AddCell(qcell11);
            TableQuizz.AddCell(qcell12);

            TableQuizz.AddCell(qcell21);
            TableQuizz.AddCell(qcell22);
            //Ajout du tableau à la cellule 
            document.Add(TableQuizz);
            document.Add(ls);


        }

        //tab titre
        public static void TitleTable(String title)
        {

            LineSeparator ls = new LineSeparator(new SolidLine());

            // création Tableau avec 1 col
            Table TitleTable = new Table(1, true);

            Cell TitleTablecell11 = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(title));



            TitleTable.AddCell(TitleTablecell11);
            //Ajout du tableau à la cellule 
            document.Add(TitleTable);
            document.Add(ls);


        }

        public static int calculNote()
        {
            if (Nb_QUEST > 0)
            {
                for (int i = 0; i < Nb_QUEST; i++)
                {
                    if (listQuestionrepRepCDTO[i].RepCandidat != null)
                    {
                        if (listQuestionrepRepCDTO[i].RepCandidat.Reponse != null)
                        {
                            if (listQuestionrepRepCDTO[i].RepCandidat.isTrue)
                            {
                                Nb_RepOk++;
                            }
                        }
                    } 

                }
            }else Nb_RepOk = 0;
            return Nb_RepOk = 0;
        }
    }
}
