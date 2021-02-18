using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    class printing_controller
    {
        private const string adobeReaderPath = "C:\\Program Files (x86)\\Adobe\\Acrobat Reader DC\\Reader\\AcroRd32.exe";
        private const string filePath = "D:\\Documents\\test.pdf";
        private const string printToFile = "D:\\Documents\\test.tiff";
        private const string printerName = "TIFF Image Printer 11.0";

        public static void PrintPDF(string printerName, string filePath, string printToFile)
        {
            //var printerName = "TIFF Image Printer 11.0";
            var args = string.Format("/t \"{0}\" \"{1}\" \"{2}\"", filePath, printerName, printToFile);

            var startInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "printto",
                FileName = adobeReaderPath,
                Arguments = args,
                ErrorDialog = false,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Normal
            };

            var process = Process.Start(startInfo);
            if (!process.WaitForExit(10000)) //default 20000
            {
                // Kill Adobe Reader/Acrobat
                process.Kill();
            }

            process.Close();
        }

        public static void PrintWord(string printerName, string filePath, string printToFile)
        {
            //app.Documents.Open(namefile);
            //// Обрабатываю файл
            //app.ActiveDocument.Save();
            //app.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
            //app.ActiveDocument.Close();

            //Document doc = new Document();
            //doc.LoadFromFile("sample.doc");
            //PrintDialog dialog = new PrintDialog();
            //dialog.AllowPrintToFile = true;
            //dialog.AllowCurrentPage = true;
            //dialog.AllowSomePages = true;
            //dialog.UseEXDialog = true;
            //doc.PrintDialog = dialog;
            //PrintDocument printDoc = doc.PrintDocument;
            //printDoc.Print();
        }
    }
}
