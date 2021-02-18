using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iTextSharp;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Diagnostics;
using Microsoft.Win32;

namespace DataViewer_D_v._001
{
    class pdf_controller
    {

        public static void getResultsPDF(TournirClass inputTournir, GroupClass inputGroup)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\Results\{"Group " + inputGroup.number.ToString() + " " + inputGroup.tournir_name.Replace(" ", "")}.pdf", FileMode.Create));
            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Fradm.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Open();

            doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name}", fgFontHuge) { });

            doc.Add(new Phrase($"\nГруппа {inputGroup.number.ToString() + ". " + inputGroup.name}", fgFontHuge));
            doc.Add(new Phrase($"\n{inputTournir.place}", fgFontHuge));
            doc.Add(new Phrase($"\n\nИтоговый отчет группы", fgFontHuge));

            PdfPTable table = new PdfPTable(15);
            table.TotalWidth = 560;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 30, 50, 39, 39, 39, 39, 39, 39, 39, 39, 39, 39, 30, 30, 30 };
            table.SetWidths(tableCellWidth);
            addCell(table, "Номер\nпары", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "ФИО", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCellcol(table, "Оценки", fgFont, 10, BaseColor.LIGHT_GRAY);
            addCell(table, "Сумма\nоценок", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Ср.\nбалл", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Место", fgFont, 1, BaseColor.LIGHT_GRAY);

            //foreach (Duet duetItem in inputGroup.duetList)
            foreach (Duet duetItem in inputGroup.sortDuetList)
            {
                addCell(table, $"{duetItem.number}", fgFont, 1, BaseColor.WHITE);
                addCell(table, $"{duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name + "\n" + duetItem.sportsman1.Patronymic + "\n" + duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name + "\n" + duetItem.sportsman2.Patronymic}", fgFontSmall, 1, BaseColor.WHITE);
                int counter = 0;
                foreach (List<int> itemList in duetItem.judgeMarkList)
                {
                    string retStr = "";
                    retStr += inputGroup.DancesList[counter];
                    retStr += "\n";
                    foreach (Judge judItem in inputGroup.JudgeList)
                    {
                        retStr += judItem.judgeChar.ToString();
                        if (inputGroup.JudgeList.Count < 8)
                            retStr += " ";
                    }
                    retStr += "\n";
                    foreach (int item in itemList)
                    {
                        retStr += item.ToString();
                        if (inputGroup.JudgeList.Count < 8)
                            retStr += " ";
                    }
                    addCell(table, retStr, fgFontSmall, 1, BaseColor.WHITE);
                    counter++;
                }
                for (int i = 0; i < 10 - counter; i++)
                    addCell(table, $"", fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $"{Math.Round(duetItem.markSum, 1)}", fgFont, 1, BaseColor.WHITE);
                addCell(table, $"{Math.Round(duetItem.mark, 1)}", fgFont, 1, BaseColor.WHITE);
                addCell(table, $"{duetItem.diplomPlace}", fgFont, 1, BaseColor.WHITE);
            } //заполнение таблицы участников
            doc.Add(table);

            doc.Add(new Phrase($"\nСудейская коллегия:", fgFontHuge));
            table = new PdfPTable(4);
            table.TotalWidth = 558;
            table.LockedWidth = true;
            tableCellWidth = new int[] { 30, 176, 176, 176 };
            table.SetWidths(tableCellWidth);

            addCell(table, "ID", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Судьи", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Город", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Судейская категория", fgFont, 1, BaseColor.LIGHT_GRAY);
            foreach (Judge judItem in inputGroup.JudgeList)
            {
                addCell(table, judItem.judgeChar + "(" + judItem.Number + ")", fgFont, 1, BaseColor.WHITE, 0);
                addCell(table, judItem.Surname + " " + judItem.Name, fgFont, 1, BaseColor.WHITE, 0);
                addCell(table, judItem.City, fgFont, 1, BaseColor.WHITE, 0);
                addCell(table, judItem.JudgeClass, fgFont, 1, BaseColor.WHITE, 0);
            }
            doc.Add(table);

            doc.Add(new Phrase($"\n", fgFontHuge));

            table = new PdfPTable(2);
            table.TotalWidth = 558;
            table.LockedWidth = true;
            tableCellWidth = new int[] { 458, 100 };
            table.SetWidths(tableCellWidth);

            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ГС")
                {
                    addCell(table, $"\nГлавный Судья: " + posItem.Surname + " " + posItem.Name + " " + posItem.Patronymic, fgFont, 0, BaseColor.WHITE);
                    addCell(table, "___________________", fgFont, 0, BaseColor.WHITE);
                }


            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ГСК")
                {
                    addCell(table, $"\nГлавный Секретарь: " + posItem.Surname + " " + posItem.Name + " " + posItem.Patronymic, fgFont, 0, BaseColor.WHITE);
                    addCell(table, "___________________", fgFont, 0, BaseColor.WHITE);
                }

            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ПДСК")
                {
                    addCell(table, $"\nПредседатель ДСК: " + posItem.Surname + " " + posItem.Name + " " + posItem.Patronymic, fgFont, 0, BaseColor.WHITE);
                    addCell(table, "___________________", fgFont, 0, BaseColor.WHITE);
                }


            doc.Add(table);
            doc.Close();
        }

        public static void getBlankForJudgePDF(TournirClass inputTournir, GroupClass inputGroup)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));

            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Fradm.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            foreach (string danceItem in inputGroup.DancesList)
            {
                var doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\MarkBlanks\{"Group " + inputGroup.number.ToString() + " " + danceItem + " " + inputGroup.tournir_name.Replace(" ", "")}.pdf", FileMode.Create));

                doc.Open();

                doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name}", fgFontHuge) { });

                doc.Add(new Phrase($"\n{inputTournir.name}", fgFontHuge));
                doc.Add(new Phrase($"\n{inputGroup.name}", fgFontHuge));
                doc.Add(new Phrase($"\nТанец: {danceItem}", fgFontHuge));

                //далее в foreach перебираем заходы
                ////////////////////////////////////////////////////////////////////
                foreach (SetClass setItem in inputGroup.SetList)
                {
                    int countOfCells = setItem.DuetList.Count + 1;
                    PdfPTable table = new PdfPTable(countOfCells);
                    //table.TotalWidth = 560;
                    //table.LockedWidth = true;
                    //int[] tableCellWidth = new int[countOfCells];
                    //for (int i = 0; i < countOfCells; i++)
                    //    tableCellWidth[i] = 35;
                    //table.SetWidths(tableCellWidth);
                    addCell(table, "Заход " + setItem.number.ToString(), fgFont, 1, BaseColor.LIGHT_GRAY);
                    foreach (Duet duetItem in setItem.DuetList)
                        addCell(table, duetItem.number.ToString(), fgFont, 1, BaseColor.WHITE);
                    //PdfPTable nested = new PdfPTable(countOfCells);
                    for (int g = 0; g < countOfCells; g++)
                        //addCell(table, "", fgFont, 1, BaseColor.WHITE);
                        table.AddCell(" ");

                    doc.Add(table);
                    doc.Add(new Phrase($"\n", fgFontHuge));
                }
                doc.Close();
            }
        }

        public static string getNumberCard_largeWithAdv(string folderName, Sportsman sportsman1, Sportsman sportsman2, int number, string advText = "")
        {
            var doc = new Document();
            doc.SetPageSize(PageSize.A4.Rotate());

            folderName = folderName.Remove(folderName.LastIndexOf('\\'), folderName.Length - folderName.LastIndexOf('\\'));
            //MessageBox.Show(folderName);

            PdfWriter.GetInstance(doc, new FileStream(folderName += $@"\DuetNumbers\{"Duet " + number.ToString()}.pdf", FileMode.Create));
            string ARIALNTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
            Phrase new_prase = new Phrase();

            BaseFont ARIALNTTFFont = BaseFont.CreateFont(ARIALNTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font ArialFontAdv = new iTextSharp.text.Font(ARIALNTTFFont, 75, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font ArialFontHuge = new iTextSharp.text.Font(ARIALNTTFFont, 380, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font ArialFontSmall = new iTextSharp.text.Font(ARIALNTTFFont, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            doc.Open();

            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 560;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 800 };

            table.SetWidths(tableCellWidth);

            addCell(table, advText, ArialFontAdv, 1, BaseColor.WHITE, 1, 0);
            addCell(table, number.ToString(), ArialFontHuge, 1, BaseColor.WHITE, 1, 0);
            addCell(table, "\n" + sportsman1.ToString(), ArialFontSmall, 1, BaseColor.WHITE, 0, 0);
            addCell(table, sportsman2.ToString(), ArialFontSmall, 1, BaseColor.WHITE, 0, 0);
            doc.Add(table);

            doc.Close();
            return folderName;
        }

        public static void getDiplomsPDF()
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Application.StartupPath + @"\NewDiplom.pdf", FileMode.Create));

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("Diplom.jpg");


            // Page site and margin left, right, top, bottom is defined
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            pdfDoc.Open();
            pdfDoc.NewPage();

            //Resize image depend upon your need
            //For give the size to image
            jpg.ScaleToFit(3000, 770);

            //If you want to choose image as background then,

            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;

            //If you want to give absolute/specified fix position to image.
            //jpg.SetAbsolutePosition(7, 69);
            Paragraph paragraph = new Paragraph("this is the testing text for demonstrate the image is in background \n\n\n this is the testing text for demonstrate the image is in background");

            //pdfDoc.Add(jpg);

            pdfDoc.Add(paragraph);

            pdfDoc.Close();
            //Response.Write(pdfDoc);



            //Response.End();
        }

        private static void addCell(PdfPTable table, string text, iTextSharp.text.Font font, int rowspan, BaseColor color)
        {
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.BackgroundColor = color;
            table.AddCell(cell);
        }

        private static void addCell(PdfPTable table, string text, iTextSharp.text.Font font, int rowspan, BaseColor color, int alligner)
        {
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = alligner;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.BackgroundColor = color;
            table.AddCell(cell);
        }

        private static void addCell(PdfPTable table, string text, iTextSharp.text.Font font, int rowspan, BaseColor color, int alligner, int border)
        {
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = alligner;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.BackgroundColor = color;
            cell.Border = border;
            table.AddCell(cell);
        }

        private static void addCellcol(PdfPTable table, string text, iTextSharp.text.Font font, int colspan, BaseColor color)
        {
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Colspan = colspan;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.BackgroundColor = color;
            table.AddCell(cell);
        }
    }
}
