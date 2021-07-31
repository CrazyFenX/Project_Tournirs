using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

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
            if (!process.WaitForExit(40000)) //default 20000
            {
                // Kill Adobe Reader/Acrobat
                process.Kill();
            }

            process.Close();
        }

        public static void PrintWord(string printerName, string filePath)
        {
            try
            {
                System.Diagnostics.Process printProcess = new System.Diagnostics.Process();
                printProcess.StartInfo.FileName = filePath;
                printProcess.StartInfo.Verb = "Print";
                printProcess.StartInfo.CreateNoWindow = true;
                printProcess.Start();
                //printProcess.WaitForExit();
            }
            catch
            {
                
            }
        }

        public static string GetDefaultPrinterName()
        {
            string default_printer = "";

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (new PrinterSettings() { PrinterName = printer }.IsDefaultPrinter)
                {
                    default_printer = printer;
                }
                else
                {
                    default_printer = null;
                }
            }

            return default_printer;
        }
    }
}
