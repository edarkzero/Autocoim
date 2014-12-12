using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;

namespace Autocoim
{
    class PdfManager
    {
        private int type;
        private Voucher voucher;
        public const int TYPE_IVA = 0;
        public const int TYPE_ISRL = 1;
        public const int TYPE_MUNICIPAL = 2;

        public PdfManager(int t,Voucher v)
        {
            type = t;
            voucher = v;
        }

        public void render()
        {
            if (type == TYPE_IVA)
            {
                // Create a new PDF document
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Flowserve IVA";
                document.Info.Author = "Camaleon Tech";
                document.Info.Subject = "Flowserve IVA";
                document.Info.Keywords = "IVA,Flowserve,Venezuela,Camaleon tech";

                // Create an empty page
                PdfPage page = document.AddPage();

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Set the text formatter
                XTextFormatter tf = new XTextFormatter(gfx);
                tf.Alignment = XParagraphAlignment.Center;

                // Create page fonts
                XFont fontPage = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont fontTitle = new XFont("Calibri", 10, XFontStyle.Bold | XFontStyle.Underline);
                XFont fontSubtitle = new XFont("Calibri", 10, XFontStyle.Bold);
                XFont fontContent = new XFont("Calibri", 10);

                // Draw logo
                XRect logoRect = new XRect(20, 20, 150, 50);
                XImage image = XImage.FromFile("Images/flowserve.png");
                gfx.DrawImage(image, logoRect.X, logoRect.Y, logoRect.Width, logoRect.Height);

                // Draw title text
                XRect titleRect = new XRect(logoRect.TopRight.X + 20, logoRect.Center.Y-fontTitle.Size/2, 150, 50);
                tf.DrawString("COMPROBANTE DE RETENCION IVA", fontTitle, XBrushes.Black, titleRect, XStringFormats.TopLeft);

                // Draw (fecha,periodo fiscal,nro. de comprobante) top-right rectangles
                // with 2 lines of string
                XRect fechaUpperRect = new XRect(titleRect.TopRight.X + 20, logoRect.Y, 120, fontSubtitle.Size + fontContent.Size + 5);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), fechaUpperRect);

                XRect fechaUpperTitleRect = new XRect(fechaUpperRect.X, fechaUpperRect.Y, fechaUpperRect.Width, fechaUpperRect.Height / 2);
                tf.DrawString("Fecha:", fontSubtitle, XBrushes.Black, fechaUpperTitleRect, XStringFormats.TopLeft);

                XRect fechaUpperContentRect = new XRect(fechaUpperRect.X, fechaUpperRect.Center.Y, fechaUpperRect.Width, fechaUpperRect.Height / 2);                
                tf.DrawString(voucher.postingDate.ToShortDateString(), fontContent, XBrushes.Black, fechaUpperContentRect, XStringFormats.TopLeft);

                // Draw the PAGE text
                gfx.DrawString("Page 1", fontPage, XBrushes.LightGray,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);

                // Save the document...
                const string filename = "Flowserve-IVA.pdf";
                document.Save(filename);
                // ...and start a viewer.
                Process.Start(filename);
            }
        }
    }
}
