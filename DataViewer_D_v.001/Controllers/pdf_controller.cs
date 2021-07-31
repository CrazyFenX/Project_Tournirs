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
using DataViewer_D_v._001.Classes;

namespace DataViewer_D_v._001
{
    class pdf_controller
    {
        
        public static void getResultsPDF(TournirClass inputTournir, GroupClass inputGroup)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));
            //MessageBox.Show(folderName);

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\Results\{inputGroup.number.ToString() + ") " + inputGroup.name}.pdf", FileMode.Create));
            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 11, iTextSharp.text.Font.ITALIC, BaseColor.BLACK); //9
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);   //7
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK); //7
            doc.Open();

            doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name + ", " + inputTournir.place}", fgFontHuge) { });

            doc.Add(new Phrase($"\nГруппа {inputGroup.number.ToString() + ". " + inputGroup.name}", fgFontHuge));
            doc.Add(new Phrase($"\nИтоговый отчет группы", fgFontHuge));

            PdfPTable table = new PdfPTable(15);
            table.TotalWidth = 560;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 30, 80, 39, 39, 39, 39, 39, 39, 39, 39, 39, 39, 20, 20, 20 };
            table.SetWidths(tableCellWidth);
            addCell(table, "Номер\nпары", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "ФИО", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCellcol(table, "Оценки", fgFont, 10, BaseColor.LIGHT_GRAY);
            addCell(table, "Сумма\nбаллов", fgFontSmall, 1, BaseColor.LIGHT_GRAY, 0, 1, 270);
            addCell(table, "Ср.\nбалл", fgFontSmall, 1, BaseColor.LIGHT_GRAY, 0, 1, 270);
            addCell(table, "Место", fgFontSmall, 1, BaseColor.LIGHT_GRAY, 0, 1, 270);

            //foreach (Duet duetItem in inputGroup.duetList)
            foreach (Duet duetItem in inputGroup.sortDuetList)
            {
                addCell(table, $"{duetItem.number}", fgFont, 1, BaseColor.WHITE);
                if (duetItem.sportsman1.Name == "" || duetItem.sportsman1.Name == null)
                    duetItem.sportsman1.Name = " ";
                if (duetItem.sportsman1.Patronymic == "" || duetItem.sportsman1.Patronymic == null)
                    duetItem.sportsman1.Patronymic = " ";
                if (duetItem.sportsman2.Name == "" || duetItem.sportsman2.Name == null)
                    duetItem.sportsman2.Name = " ";
                if (duetItem.sportsman2.Patronymic == "" || duetItem.sportsman2.Patronymic == null)
                    duetItem.sportsman2.Patronymic = " ";
                //addCell(table, $"{duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name[0] + "." + duetItem.sportsman1.Patronymic[0] + ".\n" + duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name[0] + "." + duetItem.sportsman2.Patronymic[0]}", fgFontSmall, 1, BaseColor.WHITE);

                string message = $"{duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name + " " + duetItem.sportsman1.Patronymic}";
                if (duetItem.type == "Пара")
                    message += $"{ "\n" + duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name + " " + duetItem.sportsman2.Patronymic}";
                addCell(table, message, fgFontSmall, 1, BaseColor.WHITE);
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

            doc.Add(new Phrase($"Судейская коллегия:", fgFontHuge));
            table = new PdfPTable(4);
            table.TotalWidth = 558;
            table.LockedWidth = true;
            tableCellWidth = new int[] { 30, 176, 176, 176 };
            table.SetWidths(tableCellWidth);

            addCell(table, "ID", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Судья", fgFont, 1, BaseColor.LIGHT_GRAY);
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


            //ОПТИМИЗИРОВАТЬ \/
            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ГС")
                {
                    addCell(table, $"\nГлавный Судья: " + posItem.Surname + " " + posItem.Name + " " + posItem.Patronymic, fgFont, 1, BaseColor.WHITE);
                    addCell(table, "___________________", fgFont, 0, BaseColor.WHITE);
                }

            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ГСГСК")
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

        public static void getInfoReportPDF(TournirClass inputTournir, GroupClass inputGroup)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\InfoReports\\{inputGroup.number.ToString() + ") " + inputGroup.name}.pdf", FileMode.Create));
            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 11, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Open();

            doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name}", fgFontHuge) { });

            doc.Add(new Phrase($"\nГруппа {inputGroup.number.ToString() + ". " + inputGroup.name}", fgFontHuge));
            doc.Add(new Phrase($"\n{inputTournir.place}", fgFontHuge));
            doc.Add(new Phrase($"\n\nИтоговый отчет группы", fgFontHuge));

            PdfPTable table = new PdfPTable(9);
            table.TotalWidth = 560;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 30, 30, 80, 70, 70, 70, 70, 70, 70 };
            table.SetWidths(tableCellWidth);
            addCell(table, "Номер\nпары", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Место", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "ФИО", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCellcol(table, "Дата рождения", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Город", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Клуб", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Старший Тренер", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Первый Тренер", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Второй Тренер", fgFont, 1, BaseColor.LIGHT_GRAY);

            //foreach (Duet duetItem in inputGroup.duetList)
            foreach (Duet duetItem in inputGroup.sortDuetList)
            {
                string SNP = "", BirthDates = "", Cities = "", Club = "", OldTrainer = "", FirstTrainer = "", SecondTrainer = "";
                addCell(table, $"{duetItem.number}", fgFont, 1, BaseColor.WHITE);
                if (duetItem.sportsman1.Name == "")
                    duetItem.sportsman1.Name = " ";
                if (duetItem.sportsman1.Patronymic == "")
                    duetItem.sportsman1.Patronymic = " ";
                if (duetItem.sportsman2.Name == "")
                    duetItem.sportsman2.Name = " ";
                if (duetItem.sportsman2.Patronymic == "")
                    duetItem.sportsman2.Patronymic = " ";

                SNP += duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name + " " + duetItem.sportsman1.Patronymic;
                BirthDates += duetItem.sportsman1.BirthDate;
                Cities += duetItem.sportsman1.City;
                Club += duetItem.sportsman1.ClubName;
                //OldTrainer += duetItem.sportsman1.OlderTrainer.ToString();
                //FirstTrainer += duetItem.sportsman1.FirstTrainer.ToString();
                //SecondTrainer += duetItem.sportsman1.SecondTrainer.ToString();
                try
                {
                    OldTrainer += duetItem.trainers[0].ToString();
                    FirstTrainer += duetItem.trainers[1].ToString();
                    SecondTrainer += duetItem.trainers[2].ToString();
                }
                catch (Exception ex) { }

                if (duetItem.type == "Пара")
                {
                    SNP += $"\n{duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name + " " + duetItem.sportsman2.Patronymic}";
                    BirthDates += "\n" + duetItem.sportsman2.BirthDate;
                    Cities += "\n" + duetItem.sportsman2.City;
                    Club += "\n" + duetItem.sportsman2.ClubName;
                    OldTrainer += "\n" + duetItem.sportsman2.OlderTrainer.ToString();
                    FirstTrainer += "\n" + duetItem.sportsman2.FirstTrainer;
                    SecondTrainer += "\n" + duetItem.sportsman2.SecondTrainer;
                }
                addCell(table, $"{duetItem.diplomPlace}", fgFont, 1, BaseColor.WHITE);
                addCell(table, SNP, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, BirthDates, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, Cities, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, Club, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, OldTrainer, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, FirstTrainer, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, SecondTrainer, fgFontSmall, 1, BaseColor.WHITE);
            } //заполнение таблицы участников
            doc.Add(table);

            doc.Add(new Phrase($"\nСудейская коллегия:", fgFontHuge));
            table = new PdfPTable(4);
            table.TotalWidth = 558;
            table.LockedWidth = true;
            tableCellWidth = new int[] { 30, 176, 176, 176 };
            table.SetWidths(tableCellWidth);

            addCell(table, "ID", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Судья", fgFont, 1, BaseColor.LIGHT_GRAY);
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


            //ОПТИМИЗИРОВАТЬ \/
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
            try
            {
                string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));

                string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
                Phrase new_prase = new Phrase();

                BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 14, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
                iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                foreach (Judge judgeItem in inputTournir.judges)
                {
                    foreach (string danceItem in inputGroup.DancesList)
                    {
                        var doc = new Document();
                        PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\MarkBlanks\{inputGroup.number.ToString() + ") " + inputGroup.name}\{inputGroup.number.ToString() + ") " + inputGroup.name + danceItem + " " + judgeItem.Name + "_" + judgeItem.Surname + "_" + judgeItem.Patronymic}.pdf", FileMode.Create));

                        doc.Open();
                        doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name}", fgFontHuge));

                        doc.Add(new Phrase($"\n{inputGroup.name}", fgFontHuge));
                        doc.Add(new Phrase($"\nТанец: {danceItem}", fgFontHuge));
                        doc.Add(new Phrase($"\nСудья: {judgeItem.ToSNP()}", fgFont));

                        int countOfCells = 16;
                        PdfPTable table = new PdfPTable(countOfCells);
                        table.TotalWidth = 560;
                        table.LockedWidth = true;
                        int[] tableCellWidth = new int[] { 50, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34 };
                        table.SetWidths(tableCellWidth);

                        foreach (SetClass setItem in inputGroup.SetList)
                        {
                            addCell(table, "Заход_" + setItem.number.ToString(), fgFont, 1, BaseColor.LIGHT_GRAY);
                            foreach (Duet duetItem in setItem.DuetList)
                                addCell(table, duetItem.number.ToString(), fgFontHuge, 1, BaseColor.WHITE);
                            for (int g = 0; g < 32 - setItem.DuetList.Count - 1; g++)
                                table.AddCell(" ");
                        }
                        doc.Add(table);
                        doc.Add(new Phrase($"\nПодпись судьи:", fgFont));
                        doc.Add(new Phrase("___________________", fgFont));

                        doc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string getNumberCard_largeWithAdv(string folderName, string groupName, Sportsman sportsman1, Sportsman sportsman2, int number, string advText = "")
        {
            var doc = new Document();
            doc.SetPageSize(PageSize.A4.Rotate());

            folderName = folderName.Remove(folderName.LastIndexOf('\\'), folderName.Length - folderName.LastIndexOf('\\'));
            //MessageBox.Show(folderName);
            folderName += $@"\DuetNumbers\{groupName}\{number.ToString() + " " + sportsman1.ToString(1)}.pdf";
            //MessageBox.Show(folderName);

            PdfWriter.GetInstance(doc, new FileStream(folderName, FileMode.Create));

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
            addCell(table, "\n" + sportsman1.ToString(), ArialFontSmall, 1, BaseColor.WHITE, 1, 0);
            addCell(table, sportsman2.ToString(), ArialFontSmall, 1, BaseColor.WHITE, 1, 0);
            doc.Add(table);

            doc.Close();
            //MessageBox.Show(folderName);
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

        private static void addCell(PdfPTable table, string text, iTextSharp.text.Font font, int rowspan, BaseColor color, int alligner, int border, int rotation)
        {
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = alligner;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.BackgroundColor = color;
            cell.Border = border;
            cell.Rotation = rotation;
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

        public static void getReglamentReport(TournirClass inputTournir)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));
            //MessageBox.Show(folderName);

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\Reglament\{inputTournir.name}.pdf", FileMode.Create));
            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 11, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Open();

            doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name}", fgFontHuge) { });

            PdfPTable table = new PdfPTable(10);
            table.TotalWidth = 560;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 25, 15, 60, 30, 45, 10, 10, 15, 15, 15 };
            table.SetWidths(tableCellWidth);
            addCell(table, "Время", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Тур", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCellcol(table, "Группа", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Прогрмма", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Танцы", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Танцев", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Заходов", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Кол-во пар", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "В сл.тур", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Время", fgFont, 1, BaseColor.LIGHT_GRAY);

            //foreach (Duet duetItem in inputGroup.duetList)

            //foreach (Branch branchItem in inputTournir.Branches)
            //{
            //    addCell(table, $"Отделение {branchItem.number}", fgFont, 1, BaseColor.LIGHT_GRAY); //Time
            //    addCell(table, $"", fgFont, 8, BaseColor.LIGHT_GRAY); //Tour
            //    foreach (int item in branchItem.groupOrderList)
            //    {
            //        addCell(table, $"{inputTournir.date.ToString()}", fgFont, 1, BaseColor.WHITE); //Time
            //        addCell(table, $"", fgFont, 1, BaseColor.WHITE); //Tour
            //        addCell(table, $"{inputTournir.groups[item - 1].name}", fgFont, 1, BaseColor.WHITE); //Name
            //        addCell(table, $"", fgFont, 1, BaseColor.WHITE); //programm
            //        addCell(table, $"{inputTournir.groups[item - 1].getDancesToString()}", fgFont, 1, BaseColor.WHITE);
            //        addCell(table, $"{inputTournir.groups[item - 1].DancesList.Count}", fgFont, 1, BaseColor.WHITE);
            //        addCell(table, $"{inputTournir.groups[item - 1].SetList.Count}", fgFont, 1, BaseColor.WHITE);
            //        addCell(table, $"", fgFont, 1, BaseColor.WHITE);
            //        addCell(table, $"", fgFont, 1, BaseColor.WHITE);
            //    }
            //}
            int tmpBranchNum = 0;
            //foreach (ushort regItem in inputTournir.groupsOrder)
            //{
            foreach (Branch branchItem in inputTournir.Branches)
            {
                addCell(table, $"Отделение {branchItem.number}", fgFont, 1, BaseColor.LIGHT_GRAY);
                addCellcol(table, $"", fgFont, 9, BaseColor.LIGHT_GRAY); //Tour
                //tmpBranchNum = inputTournir.groups[branchItem.number].branchNumber;
                foreach (int item in branchItem.groupOrderList)
                {
                    if (inputTournir.groups[item - 1].tours.Count > 0)
                        foreach (Tour tourItem in inputTournir.groups[item - 1].tours)
                        {
                            MessageBox.Show(inputTournir.groups[item - 1].name + " " + Tour.getStringDegr(tourItem.degree));
                            addCell(table, $"{inputTournir.date.ToString()}", fgFont, 1, BaseColor.WHITE); //Time
                            addCell(table, $"{Tour.getStringDegr(tourItem.degree)}", fgFont, 1, BaseColor.WHITE); //Tour
                            addCell(table, $"{inputTournir.groups[item - 1].name}", fgFont, 1, BaseColor.WHITE); //Name
                            addCell(table, $"", fgFont, 1, BaseColor.WHITE); //programm
                            addCell(table, $"{inputTournir.groups[item - 1].getDancesToString()}", fgFont, 1, BaseColor.WHITE);
                            addCell(table, $"{inputTournir.groups[item - 1].DancesList.Count}", fgFont, 1, BaseColor.WHITE);
                            addCell(table, $"{inputTournir.groups[item - 1].SetList.Count}", fgFont, 1, BaseColor.WHITE);
                            //addCell(table, $"{inputTournir.groups[item - 1].duetList.Count}", fgFont, 1, BaseColor.WHITE);
                            addCell(table, $"{tourItem.countOfDuets.ToString()}", fgFont, 1, BaseColor.WHITE);

                            if (tourItem.degree > 0)
                                addCell(table, $"{inputTournir.groups[item - 1].tours[inputTournir.groups[item - 1].tours.IndexOf(tourItem) - 1].countOfDuets}", fgFont, 1, BaseColor.WHITE);
                            else
                                addCell(table, $"", fgFont, 1, BaseColor.WHITE);
                            addCell(table, $"", fgFont, 1, BaseColor.WHITE);
                        }
                    else
                    {
                        addCell(table, $"{inputTournir.date.ToString()}", fgFont, 1, BaseColor.WHITE); //Time
                        addCell(table, $"", fgFont, 1, BaseColor.WHITE); //Tour
                        addCell(table, $"{inputTournir.groups[item - 1].name}", fgFont, 1, BaseColor.WHITE); //Name
                        addCell(table, $"", fgFont, 1, BaseColor.WHITE); //programm
                        addCell(table, $"{inputTournir.groups[item - 1].getDancesToString()}", fgFont, 1, BaseColor.WHITE);
                        addCell(table, $"{inputTournir.groups[item - 1].DancesList.Count}", fgFont, 1, BaseColor.WHITE);
                        addCell(table, $"{inputTournir.groups[item - 1].SetList.Count}", fgFont, 1, BaseColor.WHITE);
                        addCell(table, $"{inputTournir.groups[item - 1].duetList.Count}", fgFont, 1, BaseColor.WHITE);
                        addCell(table, $"", fgFont, 1, BaseColor.WHITE);
                        addCell(table, $"", fgFont, 1, BaseColor.WHITE);
                    }
                }

            }

            doc.Add(table);
            doc.Close();
        }

        public static void getTourResultsPDF(TournirClass inputTournir, GroupClass inputGroup, Tour inputTour)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));
            //MessageBox.Show(folderName);

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\Results\{inputGroup.number.ToString() + ") " + inputGroup.name + " " + Tour.getShortStringDegr(inputTour.degree)}.pdf", FileMode.Create));
            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 11, iTextSharp.text.Font.ITALIC, BaseColor.BLACK); //9
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);   //7
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK); //7
            doc.Open();

            doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name + ", " + inputTournir.place}", fgFontHuge) { });

            doc.Add(new Phrase($"\nГруппа {inputGroup.number.ToString() + ". " + inputGroup.name}", fgFontHuge));
            doc.Add(new Phrase($"\nИтоговый отчет тура " + Tour.getStringDegr(inputTour.degree), fgFontHuge));

            PdfPTable table = new PdfPTable(13);
            table.TotalWidth = 560;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 30, 80, 20, 39, 39, 39, 39, 39, 39, 39, 39, 39, 39};
            table.SetWidths(tableCellWidth);
            addCell(table, "Номер\nпары", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "ФИО", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Сумма\nбаллов", fgFontSmall, 1, BaseColor.LIGHT_GRAY, 0, 1, 90);
            //addCellcol(table, "Оценки", fgFont, 10, BaseColor.LIGHT_GRAY);
            foreach (String item in inputGroup.DancesList)
                addCell(table, item, fgFont, 1, BaseColor.LIGHT_GRAY);
            if (inputGroup.DancesList.Count < 10)
                for(int i = 0; i < 10 - inputGroup.DancesList.Count; i++)
                    addCell(table, "", fgFont, 1, BaseColor.LIGHT_GRAY);
            //addCell(table, "Ср.\nбалл", fgFontSmall, 1, BaseColor.LIGHT_GRAY, 0, 1, 270);
            //addCell(table, "Место", fgFontSmall, 1, BaseColor.LIGHT_GRAY, 0, 1, 270);

            //foreach (Duet duetItem in inputGroup.duetList)
            int limiter = 0;
            foreach (Duet duetItem in inputGroup.sortDuetList)
            {
                addCell(table, $"{duetItem.number}", fgFont, 1, BaseColor.WHITE);
                if (duetItem.sportsman1.Name == "" || duetItem.sportsman1.Name == null)
                    duetItem.sportsman1.Name = " ";
                if (duetItem.sportsman1.Patronymic == "" || duetItem.sportsman1.Patronymic == null)
                    duetItem.sportsman1.Patronymic = " ";
                if (duetItem.sportsman2.Name == "" || duetItem.sportsman2.Name == null)
                    duetItem.sportsman2.Name = " ";
                if (duetItem.sportsman2.Patronymic == "" || duetItem.sportsman2.Patronymic == null)
                    duetItem.sportsman2.Patronymic = " ";
                //addCell(table, $"{duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name[0] + "." + duetItem.sportsman1.Patronymic[0] + ".\n" + duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name[0] + "." + duetItem.sportsman2.Patronymic[0]}", fgFontSmall, 1, BaseColor.WHITE);

                string message = $"{duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name + " " + duetItem.sportsman1.Patronymic}";
                if (duetItem.type == "Пара")
                    message += $"{ "\n" + duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name + " " + duetItem.sportsman2.Patronymic}";
                addCell(table, message, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $"{Math.Round(duetItem.markSum, 1)}", fgFont, 1, BaseColor.WHITE);
                int counter = 0;
                foreach (List<bool> itemList in duetItem.judgeMarkListScating)
                {
                    string retStr = "";
                    //retStr += inputGroup.DancesList[counter];
                    //retStr += "\n";
                    foreach (Judge judItem in inputGroup.JudgeList)
                    {
                        retStr += judItem.judgeChar.ToString();
                        if (inputGroup.JudgeList.Count < 8)
                            retStr += " ";
                    }
                    retStr += "\n";
                    foreach (bool item in itemList)
                    {
                        if (item)
                            retStr += "X";
                        else
                            retStr += "-";
                        if (inputGroup.JudgeList.Count < 8)
                            retStr += " ";
                    }
                    addCell(table, retStr, fgFontSmall, 1, BaseColor.WHITE);
                    counter++;
                }
                for (int i = 0; i < 10 - counter; i++)
                    addCell(table, $"", fgFontSmall, 1, BaseColor.WHITE);
                //addCell(table, $"{Math.Round(duetItem.mark, 1)}", fgFont, 1, BaseColor.WHITE);
                //addCell(table, $"{duetItem.diplomPlace}", fgFont, 1, BaseColor.WHITE);
                limiter++;
                if (limiter == inputGroup.tours[inputGroup.tours.IndexOf(inputTour) - 1].countOfDuets)
                    addCellcol(table, " ", fgFont, 13, BaseColor.LIGHT_GRAY);
            } //заполнение таблицы участников
            doc.Add(table);

            doc.Add(new Phrase($"Судейская коллегия:", fgFontHuge));
            table = new PdfPTable(4);
            table.TotalWidth = 558;
            table.LockedWidth = true;
            tableCellWidth = new int[] { 30, 176, 176, 176 };
            table.SetWidths(tableCellWidth);

            addCell(table, "ID", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Судья", fgFont, 1, BaseColor.LIGHT_GRAY);
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


            //ОПТИМИЗИРОВАТЬ \/
            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ГС")
                {
                    addCell(table, $"\nГлавный Судья: " + posItem.Surname + " " + posItem.Name + " " + posItem.Patronymic, fgFont, 1, BaseColor.WHITE);
                    addCell(table, "___________________", fgFont, 0, BaseColor.WHITE);
                }

            foreach (Judge posItem in inputTournir.positionsList)
                if (posItem.position == "ГСГСК")
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

        public static void getFinalTourResultsPDF(TournirClass inputTournir, GroupClass inputGroup)
        {
            string folderName = inputTournir.path.Remove(inputTournir.path.LastIndexOf('\\'), inputTournir.path.Length - inputTournir.path.LastIndexOf('\\'));
            //MessageBox.Show(folderName);

            var doc = new Document();
            doc.SetPageSize(PageSize.A4.Rotate());
            PdfWriter.GetInstance(doc, new FileStream(folderName + $@"\Results\{inputGroup.number.ToString() + ") " + inputGroup.name + " (Skating)"}.pdf", FileMode.Create));
            string FradmTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALN.TTF");
            Phrase new_prase = new Phrase();

            BaseFont fgBaseFont = BaseFont.CreateFont(FradmTTF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fgFontHuge = new iTextSharp.text.Font(fgBaseFont, 13, iTextSharp.text.Font.ITALIC, BaseColor.BLACK); //9
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);   //7
            iTextSharp.text.Font fgFontSmall = new iTextSharp.text.Font(fgBaseFont, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK); //7
            doc.Open();

            doc.Add(new_prase = new Phrase($"{inputTournir.date.ToString() + " " + inputTournir.name + ", " + inputTournir.place}", fgFontHuge) { });

            doc.Add(new Phrase($"\nГруппа {inputGroup.number.ToString() + ". " + inputGroup.name}", fgFontHuge));

            PdfPTable table = new PdfPTable(8);
            table.TotalWidth = 820;
            table.LockedWidth = true;
            int[] tableCellWidth = new int[] { 30, 120, 120, 140, 50, 50 ,50, 50};
            table.SetWidths(tableCellWidth);
            addCell(table, "Номер\nпары", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "ФИО", fgFont, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Город\nклуб", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Руководители\nТренеры", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Место", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, " ", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, " ", fgFontSmall, 1, BaseColor.LIGHT_GRAY);
            addCell(table, "Сумма", fgFontSmall, 1, BaseColor.LIGHT_GRAY);

            //foreach (Duet duetItem in inputGroup.duetList)

            //Финал
            addCellcol(table, "Финал", fgFont, 8, BaseColor.LIGHT_GRAY);
            //addCellcol(table, "Финал", fgFont, 8, BaseColor.LIGHT_GRAY, 0, 1);
            foreach (Duet duetItem in inputGroup.sortDuetListFinal)
            {
                addCell(table, $"{duetItem.number}", fgFont, 1, BaseColor.WHITE);
                string message = $"{duetItem.sportsman1.Surname + " " + duetItem.sportsman1.Name + " " + duetItem.sportsman1.Patronymic}";
                if (duetItem.type == "Пара")
                    message += $"{ "\n" + duetItem.sportsman2.Surname + " " + duetItem.sportsman2.Name + " " + duetItem.sportsman2.Patronymic}";
                addCell(table, message, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $"{duetItem.sportsman1.City + "\n" + duetItem.sportsman1.ClubName}", fgFont, 1, BaseColor.WHITE);
                message = "";
                foreach (Trainer item in duetItem.trainers)
                    message += item.ToLongString() + ", ";
                addCell(table, message, fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $"{duetItem.skatingPosition}", fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $" ", fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $" ", fgFontSmall, 1, BaseColor.WHITE);
                addCell(table, $"{duetItem.markSum}", fgFontSmall, 1, BaseColor.WHITE);

            } //заполнение таблицы участников
            for (int i = 1; i < inputGroup.tours.Count; i++)
            {
                addCellcol(table, Tour.getStringDegr(i), fgFont, 8, BaseColor.LIGHT_GRAY);
                for (int j = inputGroup.tours[i - 1].countOfDuets; j < inputGroup.tours[i].sortDuetList.Count; j++)
                {
                    addCell(table, $"{inputGroup.tours[i].sortDuetList[j].number}", fgFont, 1, BaseColor.WHITE);
                    string message = $"{inputGroup.tours[i].sortDuetList[j].sportsman1.Surname + " " + inputGroup.tours[i].sortDuetList[j].sportsman1.Name + " " + inputGroup.tours[i].sortDuetList[j].sportsman1.Patronymic}";
                    if (inputGroup.tours[i].sortDuetList[j].type == "Пара")
                        message += $"{ "\n" + inputGroup.tours[i].sortDuetList[j].sportsman2.Surname + " " + inputGroup.tours[i].sortDuetList[j].sportsman2.Name + " " + inputGroup.tours[i].sortDuetList[j].sportsman2.Patronymic}";
                    addCell(table, message, fgFontSmall, 1, BaseColor.WHITE);
                    addCell(table, $"{inputGroup.tours[i].sortDuetList[j].sportsman1.City + "\n" + inputGroup.tours[i].sortDuetList[j].sportsman1.ClubName}", fgFont, 1, BaseColor.WHITE);
                    message = "";
                    foreach (Trainer trainItem in inputGroup.tours[i].sortDuetList[j].trainers)
                        message += trainItem.ToLongString() + ", ";
                    addCell(table, message, fgFontSmall, 1, BaseColor.WHITE);
                    addCell(table, $"{inputGroup.tours[i].sortDuetList[j].skatingPosition}", fgFontSmall, 1, BaseColor.WHITE);
                    addCell(table, $" ", fgFontSmall, 1, BaseColor.WHITE);
                    addCell(table, $" ", fgFontSmall, 1, BaseColor.WHITE);
                    addCell(table, $"{inputGroup.tours[i].sortDuetList[j].markSum}", fgFontSmall, 1, BaseColor.WHITE);
                }
            }   
            doc.Add(table);
            doc.Close();
        }
    }
}
