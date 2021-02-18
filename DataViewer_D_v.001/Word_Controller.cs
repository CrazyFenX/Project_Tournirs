using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using DocumentFormat.OpenXml;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DataViewer_D_v._001
{
    class Word_Controller
    {
        public static void OpenAndAddTextToWordDocument(string filepath, TournirClass inputTournir)
        {
            //Копировать файлы, изменяя копии.
            //
            int countOfDuets = 0, k = 0;
            foreach (GroupClass groupItem in inputTournir.groups)
                foreach (Duet duetItem in groupItem.duetList)
                    countOfDuets++;

            FileInfo fileInf = new FileInfo(filepath);
            for (k = 0; k < countOfDuets; k++)
            {
                if (fileInf.Exists)
                    fileInf.CopyTo(filepath + " " + k, true);
            }

            k = 0;
            foreach (GroupClass groupItem in inputTournir.groups)
            {
                foreach (Duet duetItem in groupItem.duetList)
                {
                    WordprocessingDocument wordprocessingDocument =
                    WordprocessingDocument.Open(filepath + " " + k, true);

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
                            switch (duetItem.diplomPlace.Replace(" ",""))
                            {
                                case "Л1":
                                    text.Text = text.Text.Replace("<Category>", "Лауреат I степени"); //Лауреат I степени
                                    break;
                                case "Л2":
                                    text.Text = text.Text.Replace("<Category>", "Лауреат II степени"); //Лауреат II степени
                                    break;
                                case "Л3":
                                    text.Text = text.Text.Replace("<Category>", "Лауреат III степени"); //Лауреат III степени
                                    break;
                                case "Д1":
                                    text.Text = text.Text.Replace("<Category>", "Дипломант I степени"); //Дипломант I степени
                                    break;
                                case "Д2":
                                    text.Text = text.Text.Replace("<Category>", "Дипломант II степени"); //Дипломант I степени
                                    break;
                                case "Д3":
                                    text.Text = text.Text.Replace("<Category>", "Дипломант III степени"); //Дипломант III степени
                                    break;
                            }
                        }
                    }
                    //// Add new text.
                    //Paragraph para = body.AppendChild(new Paragraph());
                    //Run run = para.AppendChild(new Run());
                    //run.AppendChild(new Text(txt));

                    // Close the handle explicitly.
                    wordprocessingDocument.Close();
                    k++;
                }
            }
        }
    }
}

