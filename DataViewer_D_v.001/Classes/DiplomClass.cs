using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTextSharp;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
//using System.Drawing;

namespace DataViewer_D_v._001
{
    public class DiplomClass : IPdfPTableEvent
    //public class ImageTableEvent : IPdfPTableEvent
    {
        public Image TableBackgroundImage;

        public void TableLayout(PdfPTable table, float[][] widths, float[] heights, int headerRows, int rowStart, PdfContentByte[] canvases)
        {
            PdfContentByte cb = canvases[PdfPTable.BACKGROUNDCANVAS];

            float coefficient = ((PageSize.A4.Width - 40.0f) / 2) / TableBackgroundImage.Width;
            float width = TableBackgroundImage.Width * coefficient;
            float height = TableBackgroundImage.Height * coefficient;

            TableBackgroundImage.ScaleAbsoluteWidth(width);
            TableBackgroundImage.ScaleAbsoluteHeight(height);

            float absoluteHeight = heights.First() - height;

            TableBackgroundImage.SetAbsolutePosition(20.0f, absoluteHeight);

            cb.AddImage(TableBackgroundImage);
        }
    }
}
