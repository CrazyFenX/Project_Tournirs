using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using DocumentFormat.OpenXml;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using System.Windows.Forms;
using System.Diagnostics;

namespace DataViewer_D_v._001
{
    class Word_Controller
    {
        static string[] categories = new string[] { "Лауреат I степени", "Лауреат II степени", "Лауреат III степени", "Дипломант I степени", "Дипломант II степени", "Дипломант III степени" };
        public static void OpenAndAddTextToWordDocument(string filepath, TournirClass inputTournir, string printerName = "")
        {
            //Копировать файлы, изменяя копии.
            //
            string newFilePath = "";

            int countOfDuets = 0, k = 0;
            foreach (GroupClass groupItem in inputTournir.groups)
                foreach (Duet duetItem in groupItem.duetList)
                    countOfDuets++;

            FileInfo fileInf = new FileInfo(filepath);
            for (k = 0; k < countOfDuets; k++)
            {
                if (fileInf.Exists)
                {
                    string[] splitFilePath = filepath.Split(new char[] { '.' });
                    if (splitFilePath.Length >= 2)
                    fileInf.CopyTo(newFilePath = splitFilePath[0] + k + "." + splitFilePath[1], true);
                    //MessageBox.Show(splitFilePath[0] + "\n" + k + "." + "\n" + splitFilePath[1]);
                }
            }

            k = 0;
            foreach (GroupClass groupItem in inputTournir.groups)
            {
                foreach (Duet duetItem in groupItem.duetList)
                {
                    string[] splitFilePath = filepath.Split(new char[] { '.' });
                    if (splitFilePath.Length >= 2)
                        newFilePath = splitFilePath[0] + k + "." + splitFilePath[1];
    
                        WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(newFilePath, true);

                    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                    foreach (var text in body.Descendants<Text>())
                    {
                        if (text.Text.Contains("<Name>"))
                        {
                            text.Text = text.Text.Replace("<Name>", duetItem.sportsman1.Name);
                        }
                        if (text.Text.Contains("<Surname>"))
                        {
                            text.Text = text.Text.Replace("<Surname>", duetItem.sportsman1.Surname);
                        }
                        if (text.Text.Contains("<Category>"))
                        {
                            int index = 0;
                            switch (duetItem.diplomPlace.Replace(" ",""))
                            {
                                case "Л1":
                                    index = 0;//Лауреат I степени
                                    break;
                                case "Л2":
                                    index = 1; //Лауреат II степени
                                    break;
                                case "Л3":
                                    index = 2; //Лауреат III степени
                                    break;
                                case "Д1":
                                    index = 3; //Дипломант I степени
                                    break;
                                case "Д2":
                                    index = 4; //Дипломант I степени
                                    break;
                                case "Д3":
                                    index = 5; //Дипломант III степени
                                    break;
                            }
                            text.Text = text.Text.Replace("<Category>", categories[index]);
                        }
                    }

                    wordprocessingDocument.Close();
                    //if (k == 15)
                    //    printing_controller.PrintWord(printerName, newFilePath);
                    k++;
                }
            }
        }

        //public static void OpenAndAddTextToWordDocument(string filepath, TournirClass inputTournir, int groupnumber, string printerName = "")
        public static void OpenAndAddTextToWordDocument(string filepath, TournirClass inputTournir, int groupnumber, string printerName = "", int sys = 0)
        {
            //Копировать файлы, изменяя копии.
            //
            string newFilePath = "";
            string formatedFilePath = "";

            FileInfo fileInf = new FileInfo(filepath);
            if (sys == 0)
                foreach (Duet duetItem in inputTournir.groups[groupnumber].duetList)
                {
                    formatedFilePath = filepath.Remove(filepath.LastIndexOf('\\') + 1) + (groupnumber + 1).ToString() + ") " + inputTournir.groups[groupnumber].name + "\\";
                    fileInf.CopyTo(formatedFilePath + duetItem.number.ToString() + " " + duetItem.sportsman1.ToString() + ".docx", true);
                    newFilePath = formatedFilePath + duetItem.number.ToString() + " " + duetItem.sportsman1.ToString() + ".docx";
                    WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(newFilePath, true);
                    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                    foreach (var text in body.Descendants<Text>())
                    {
                        if (text.Text.Contains("Name"))
                        {
                            text.Text = text.Text.Replace("Name", duetItem.sportsman1.Name);
                        }
                        if (text.Text.Contains("Surname"))
                        {
                            text.Text = text.Text.Replace("Surname", duetItem.sportsman1.Surname);
                        }
                        if (text.Text.Contains("Place"))
                        {
                            int index = 0;
                            switch (duetItem.diplomPlace.Replace(" ", ""))
                            {
                                case "Л1":
                                    index = 0;//Лауреат I степени
                                    break;
                                case "Л2":
                                    index = 1; //Лауреат II степени
                                    break;
                                case "Л3":
                                    index = 2; //Лауреат III степени
                                    break;
                                case "Д1":
                                    index = 3; //Дипломант I степени
                                    break;
                                case "Д2":
                                    index = 4; //Дипломант I степени
                                    break;
                                case "Д3":
                                    index = 5; //Дипломант III степени
                                    break;
                            }
                            text.Text = text.Text.Replace("Place", categories[index]);
                        }
                        if (text.Text.Contains("Pos"))
                        {
                            MessageBox.Show("Найдено Position!");
                            text.Text = text.Text.Replace("Pos", duetItem.skatingPosition.ToString());
                        }
                        if (text.Text.Contains("Category"))
                        {
                            text.Text = text.Text.Replace("Category", inputTournir.groups[groupnumber].name.Replace("_", " "));
                        }
                    }
                    wordprocessingDocument.Close();

                    //MessageBox.Show(duetItem.type);
                    if (duetItem.type.Replace(" ", "") == "Пара")
                    {
                        formatedFilePath = filepath.Remove(filepath.LastIndexOf('\\') + 1) + (groupnumber + 1).ToString() + ") " + inputTournir.groups[groupnumber].name + "\\";

                        newFilePath = formatedFilePath + duetItem.number.ToString() + " " + duetItem.sportsman2.ToString() + ".docx";
                        fileInf.CopyTo(newFilePath, true);
                        //MessageBox.Show(newFilePath);

                        WordprocessingDocument wordprocessingDocument1 = WordprocessingDocument.Open(newFilePath, true);

                        body = wordprocessingDocument1.MainDocumentPart.Document.Body;

                        foreach (var text in body.Descendants<Text>())
                        {
                            if (text.Text.Contains("Name"))
                            {
                                text.Text = text.Text.Replace("Name", duetItem.sportsman2.Name);
                            }
                            if (text.Text.Contains("Surname"))
                            {
                                text.Text = text.Text.Replace("Surname", duetItem.sportsman2.Surname);
                            }
                            if (text.Text.Contains("Place"))
                            {
                                int index = 0;
                                switch (duetItem.diplomPlace.Replace(" ", ""))
                                {
                                    case "Л1":
                                        index = 0;//Лауреат I степени
                                        break;
                                    case "Л2":
                                        index = 1; //Лауреат II степени
                                        break;
                                    case "Л3":
                                        index = 2; //Лауреат III степени
                                        break;
                                    case "Д1":
                                        index = 3; //Дипломант I степени
                                        break;
                                    case "Д2":
                                        index = 4; //Дипломант I степени
                                        break;
                                    case "Д3":
                                        index = 5; //Дипломант III степени
                                        break;
                                }
                                text.Text = text.Text.Replace("Place", categories[index]);
                            }
                            if (text.Text.Contains("Pos"))
                            {
                                MessageBox.Show("Найдено Position!");
                                text.Text = text.Text.Replace("Pos", duetItem.skatingPosition.ToString());
                            }
                            if (text.Text.Contains("Category"))
                            {
                                text.Text = text.Text.Replace("Category", inputTournir.groups[groupnumber].name.Replace("_", " "));
                            }
                        }
                        wordprocessingDocument1.Close();
                    }
                }
            else
            {
                foreach (Duet duetItem in inputTournir.groups[groupnumber].sortDuetListFinal)
                {
                    fileInf = new FileInfo(filepath);
                    formatedFilePath = filepath.Remove(filepath.LastIndexOf('\\') + 1) + (groupnumber + 1).ToString() + ") " + inputTournir.groups[groupnumber].name + " scating\\";
                    fileInf.CopyTo(formatedFilePath + duetItem.number.ToString() + " " + duetItem.sportsman1.ToString() + ".docx", true);
                    newFilePath = formatedFilePath + duetItem.number.ToString() + " " + duetItem.sportsman1.ToString() + ".docx";
                    WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(newFilePath, true);
                    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                    foreach (var text in body.Descendants<Text>())
                    {
                        if (text.Text.Contains("Name"))
                            text.Text = text.Text.Replace("Name", duetItem.sportsman1.Name);
                        if (text.Text.Contains("Surname"))
                            text.Text = text.Text.Replace("Surname", duetItem.sportsman1.Surname);
                        if (text.Text.Contains("Place"))
                            text.Text = text.Text.Replace("Place", duetItem.skatingPosition.ToString());
                        if (text.Text.Contains("Category"))
                            text.Text = text.Text.Replace("Category", inputTournir.groups[groupnumber].name.Replace("_", " "));
                    }
                    wordprocessingDocument.Close();

                    //MessageBox.Show(duetItem.type);
                    if (duetItem.type.Replace(" ", "") == "Пара")
                    {
                        newFilePath = formatedFilePath + duetItem.number.ToString() + " " + duetItem.sportsman2.ToString() + ".docx";
                        fileInf.CopyTo(newFilePath, true);
                        WordprocessingDocument wordprocessingDocument1 = WordprocessingDocument.Open(newFilePath, true);

                        body = wordprocessingDocument1.MainDocumentPart.Document.Body;

                        foreach (var text in body.Descendants<Text>())
                        {
                            if (text.Text.Contains("Name"))
                                text.Text = text.Text.Replace("Name", duetItem.sportsman2.Name);
                            if (text.Text.Contains("Surname"))
                                text.Text = text.Text.Replace("Surname", duetItem.sportsman2.Surname);
                            if (text.Text.Contains("Place"))
                                    text.Text = text.Text.Replace("Place", duetItem.skatingPosition.ToString());
                            if (text.Text.Contains("Category"))
                                text.Text = text.Text.Replace("Category", inputTournir.groups[groupnumber].name.Replace("_", " "));
                        }
                        wordprocessingDocument1.Close();
                    }
                }
                for (int i = 1; i < inputTournir.groups[groupnumber].tours.Count; i++)
                {
                    for (int j = inputTournir.groups[groupnumber].tours[i - 1].countOfDuets; j < inputTournir.groups[groupnumber].tours[i].sortDuetList.Count; j++)
                    {
                        fileInf.CopyTo(formatedFilePath + inputTournir.groups[groupnumber].tours[i].sortDuetList[j].number.ToString() + " " + inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman1.ToString() + ".docx", true);
                        newFilePath = formatedFilePath + inputTournir.groups[groupnumber].tours[i].sortDuetList[j].number.ToString() + " " + inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman1.ToString() + ".docx";
                        WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(newFilePath, true);
                        Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                        foreach (var text in body.Descendants<Text>())
                        {
                            if (text.Text.Contains("Name"))
                                text.Text = text.Text.Replace("Name", inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman1.Name);
                            if (text.Text.Contains("Surname"))
                                text.Text = text.Text.Replace("Surname", inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman1.Surname);
                            if (text.Text.Contains("Place"))
                                text.Text = text.Text.Replace("Place", inputTournir.groups[groupnumber].tours[i].sortDuetList[j].skatingPosition.ToString());
                            if (text.Text.Contains("Category"))
                                text.Text = text.Text.Replace("Category", inputTournir.groups[groupnumber].name.Replace("_", " "));
                        }
                        wordprocessingDocument.Close();

                        //MessageBox.Show(duetItem.type);
                        if (inputTournir.groups[groupnumber].tours[i].sortDuetList[j].type.Replace(" ", "") == "Пара")
                        {
                            newFilePath = formatedFilePath + inputTournir.groups[groupnumber].tours[i].sortDuetList[j].number.ToString() + " " + inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman2.ToString() + ".docx";
                            fileInf.CopyTo(newFilePath, true);
                            WordprocessingDocument wordprocessingDocument1 = WordprocessingDocument.Open(newFilePath, true);

                            body = wordprocessingDocument1.MainDocumentPart.Document.Body;

                            foreach (var text in body.Descendants<Text>())
                            {
                                if (text.Text.Contains("Name"))
                                    text.Text = text.Text.Replace("Name", inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman2.Name);
                                if (text.Text.Contains("Surname"))
                                    text.Text = text.Text.Replace("Surname", inputTournir.groups[groupnumber].tours[i].sortDuetList[j].sportsman2.Surname);
                                if (text.Text.Contains("Place"))
                                    text.Text = text.Text.Replace("Place", inputTournir.groups[groupnumber].tours[i].sortDuetList[j].skatingPosition.ToString());
                                if (text.Text.Contains("Category"))
                                    text.Text = text.Text.Replace("Category", inputTournir.groups[groupnumber].name.Replace("_", " "));
                            }
                            wordprocessingDocument1.Close();
                        }
                    }
                }
            }
        }

        public static void CreateDiplomPattern(string filepath)
        {
            using (WordprocessingDocument wordDocument =
            WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document, true))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("Награждается\nName Surname\nCategory") {  });
                mainPart.Document.Save();

                ProcessStartInfo startInfo = new ProcessStartInfo { FileName = filepath };
                Process.Start(startInfo);
            }
        }

        public static void writeInTryPattern(string filepath, TournirClass inputTournir)
        {
            //Копировать файлы, изменяя копии.

            FileInfo fileInf = new FileInfo(filepath);
            string formatedFilePath = filepath.Remove(filepath.LastIndexOf('.')) + "_Try" + ".docx";
            fileInf.CopyTo(formatedFilePath, true);

            //MessageBox.Show(formatedFilePath);
            WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(formatedFilePath, true);

            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            foreach (var text in body.Descendants<Text>())
            {
                if (text.Text.Contains("Name"))
                {
                    text.Text = text.Text.Replace("Name", "Иван");
                }
                if (text.Text.Contains("Surname"))
                {
                    text.Text = text.Text.Replace("Surname", "Иванов");
                }
                if (text.Text.Contains("Place"))
                {
                    text.Text = text.Text.Replace("Place", "Лауреат I степени");
                }
                if (text.Text.Contains("Category"))
                {
                    text.Text = text.Text.Replace("Category", "Дети 1 + Дети 2");
                }
            }
            wordprocessingDocument.Close();

            ProcessStartInfo startInfo = new ProcessStartInfo { FileName = formatedFilePath };
            Process.Start(startInfo);
        }
    }
}

