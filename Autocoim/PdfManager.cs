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
                page.Orientation = PageOrientation.Landscape;

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Set the text formatter
                XTextFormatter tf_center = new XTextFormatter(gfx);
                tf_center.Alignment = XParagraphAlignment.Center;

                XTextFormatter tf_left = new XTextFormatter(gfx);
                tf_left.Alignment = XParagraphAlignment.Left;

                // Create page fonts
                XFont fontPage = new XFont("Verdana", 25, XFontStyle.Bold);
                XFont fontTitle = new XFont("Calibri", 14, XFontStyle.Bold | XFontStyle.Underline);
                XFont fontSubtitle = new XFont("Calibri", 10, XFontStyle.Bold);
                XFont fontContent = new XFont("Calibri", 10);

                //Magins
                int borderMargin = 20;
                int innerMargin = 5;

                //Rects Sizes
                double fechaRectsWidth = page.Width/4;

                // Draw logo
                XRect logoRect = new XRect(borderMargin, borderMargin, fechaRectsWidth, 50);
                XImage image = XImage.FromFile("Images/flowserve.png");
                gfx.DrawImage(image, logoRect.X, logoRect.Y, logoRect.Width, logoRect.Height);

                // Draw (fecha,periodo fiscal,nro. de comprobante) top-right rectangles
                // with 2 lines of string

                    //Posting Date short -> Fecha                
                XRect fechaUpperRect = new XRect(page.Width - fechaRectsWidth - borderMargin, logoRect.Y, fechaRectsWidth, fontSubtitle.Size + fontContent.Size + innerMargin);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), fechaUpperRect);

                XRect fechaUpperTitleRect = new XRect(fechaUpperRect.X, fechaUpperRect.Y, fechaUpperRect.Width, fechaUpperRect.Height / 2);
                tf_center.DrawString("Fecha:", fontSubtitle, XBrushes.Black, fechaUpperTitleRect, XStringFormats.TopLeft);

                XRect fechaUpperContentRect = new XRect(fechaUpperRect.X, fechaUpperRect.Center.Y, fechaUpperRect.Width, fechaUpperRect.Height / 2);
                tf_center.DrawString(voucher.getFechaComprobante(), fontContent, XBrushes.Black, fechaUpperContentRect, XStringFormats.TopLeft);

                    //Posting Date Año+Mes -> Periodo Fiscal
                XRect periodoFiscalUpperRect = new XRect(fechaUpperRect.X, fechaUpperRect.BottomLeft.Y+innerMargin, fechaUpperRect.Width, fechaUpperRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), periodoFiscalUpperRect);

                XRect periodoFiscalUpperTitleRect = new XRect(periodoFiscalUpperRect.X, periodoFiscalUpperRect.Y, periodoFiscalUpperRect.Width, periodoFiscalUpperRect.Height / 2);
                tf_center.DrawString("Período Fiscal:", fontSubtitle, XBrushes.Black, periodoFiscalUpperTitleRect, XStringFormats.TopLeft);

                XRect periodoFiscalUpperContentRect = new XRect(periodoFiscalUpperRect.X, periodoFiscalUpperRect.Center.Y, periodoFiscalUpperRect.Width, periodoFiscalUpperRect.Height / 2);
                tf_center.DrawString(voucher.getPeriodoFiscal(), fontContent, XBrushes.Black, periodoFiscalUpperContentRect, XStringFormats.TopLeft);

                //Posting Date Año+Mes+X -> Número de comprobante
                XRect nroComprobanteUpperRect = new XRect(periodoFiscalUpperRect.X, periodoFiscalUpperRect.BottomLeft.Y + innerMargin, periodoFiscalUpperRect.Width, periodoFiscalUpperRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), nroComprobanteUpperRect);

                XRect nroComprobanteUpperTitleRect = new XRect(nroComprobanteUpperRect.X, nroComprobanteUpperRect.Y, nroComprobanteUpperRect.Width, nroComprobanteUpperRect.Height / 2);
                tf_center.DrawString("Nro. de Comprobante:", fontSubtitle, XBrushes.Black, nroComprobanteUpperTitleRect, XStringFormats.TopLeft);

                XRect nroComprobanteUpperContentRect = new XRect(nroComprobanteUpperRect.X, nroComprobanteUpperRect.Center.Y, nroComprobanteUpperRect.Width, nroComprobanteUpperRect.Height / 2);
                tf_center.DrawString(voucher.getNroComprobante(), fontContent, XBrushes.Black, nroComprobanteUpperContentRect, XStringFormats.TopLeft);

                // Draw title text
                XRect titleRect = new XRect(logoRect.TopRight.X + borderMargin, logoRect.Center.Y - fontTitle.Size / 2, page.Width-fechaUpperRect.Width-logoRect.Width-(borderMargin*4), 50);
                tf_center.DrawString("COMPROBANTE_DE_RETENCION_IVA", fontTitle, XBrushes.Black, titleRect, XStringFormats.TopLeft);

                //Middle top Rects

                    //Nombre o Razón Social del Agente de Retención
                XRect agenteNombreMiddleTopRect = new XRect(logoRect.X, nroComprobanteUpperRect.Bottom + innerMargin, page.Width / 2 - (borderMargin - innerMargin), nroComprobanteUpperRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), agenteNombreMiddleTopRect);

                XRect agenteNombreMiddleTopTitleRect = new XRect(agenteNombreMiddleTopRect.X, agenteNombreMiddleTopRect.Y, agenteNombreMiddleTopRect.Width, agenteNombreMiddleTopRect.Height / 2);
                tf_left.DrawString("Nombre o Razón Social del Agente de Retención", fontSubtitle, XBrushes.Black, agenteNombreMiddleTopTitleRect, XStringFormats.TopLeft);

                XRect agenteNombreMiddleTopContentRect = new XRect(agenteNombreMiddleTopRect.X, agenteNombreMiddleTopRect.Center.Y, agenteNombreMiddleTopRect.Width, agenteNombreMiddleTopRect.Height / 2);
                tf_left.DrawString(Voucher.RAZON_FS, fontContent, XBrushes.Black, agenteNombreMiddleTopContentRect, XStringFormats.TopLeft);

                    //Registro información Fiscal Agente de Retención
                XRect agenteRetencionMiddleTopRect = new XRect(agenteNombreMiddleTopRect.X + agenteNombreMiddleTopRect.Width + innerMargin, agenteNombreMiddleTopRect.Y, agenteNombreMiddleTopRect.Width - (borderMargin-innerMargin), agenteNombreMiddleTopRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), agenteRetencionMiddleTopRect);

                XRect agenteRetencionMiddleTopTitleRect = new XRect(agenteRetencionMiddleTopRect.X, agenteRetencionMiddleTopRect.Y, agenteRetencionMiddleTopRect.Width, agenteRetencionMiddleTopRect.Height / 2);
                tf_center.DrawString("Registro información Fiscal Agente de Retención", fontSubtitle, XBrushes.Black, agenteRetencionMiddleTopTitleRect, XStringFormats.TopLeft);

                XRect agenteRetencionMiddleTopContentRect = new XRect(agenteRetencionMiddleTopRect.X, agenteRetencionMiddleTopRect.Center.Y, agenteRetencionMiddleTopRect.Width, agenteRetencionMiddleTopRect.Height / 2);
                tf_center.DrawString(Voucher.RIF_FS, fontContent, XBrushes.Black, agenteRetencionMiddleTopContentRect, XStringFormats.TopLeft);

                    //Dirección Fiscal del Agente de Retención
                XRect agenteDireccionMiddleTopRect = new XRect(agenteNombreMiddleTopRect.X, agenteNombreMiddleTopRect.Bottom+innerMargin, page.Width-borderMargin*2, agenteNombreMiddleTopRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), agenteDireccionMiddleTopRect);

                XRect agenteDireccionMiddleTopTitleRect = new XRect(agenteDireccionMiddleTopRect.X, agenteDireccionMiddleTopRect.Y, agenteDireccionMiddleTopRect.Width, agenteDireccionMiddleTopRect.Height / 2);
                tf_left.DrawString("Dirección Fiscal del Agente de Retención", fontSubtitle, XBrushes.Black, agenteDireccionMiddleTopTitleRect, XStringFormats.TopLeft);

                XRect agenteDireccionMiddleTopContentRect = new XRect(agenteDireccionMiddleTopRect.X, agenteDireccionMiddleTopRect.Center.Y, agenteDireccionMiddleTopRect.Width, agenteDireccionMiddleTopRect.Height / 2);
                tf_left.DrawString(Voucher.DIR_FS, fontContent, XBrushes.Black, agenteDireccionMiddleTopContentRect, XStringFormats.TopLeft);

                    //Nombre o Razón Social del Sujeto Retenido:
                XRect SujetoNombreMiddleTopRect = new XRect(agenteDireccionMiddleTopRect.X, agenteDireccionMiddleTopRect.Bottom + innerMargin, agenteNombreMiddleTopRect.Width, agenteNombreMiddleTopRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), SujetoNombreMiddleTopRect);

                XRect SujetoNombreMiddleTopTitleRect = new XRect(SujetoNombreMiddleTopRect.X, SujetoNombreMiddleTopRect.Y, SujetoNombreMiddleTopRect.Width, SujetoNombreMiddleTopRect.Height / 2);
                tf_left.DrawString("Nombre o Razón Social del Sujeto Retenido", fontSubtitle, XBrushes.Black, SujetoNombreMiddleTopTitleRect, XStringFormats.TopLeft);

                XRect SujetoNombreMiddleTopContentRect = new XRect(SujetoNombreMiddleTopRect.X, SujetoNombreMiddleTopRect.Center.Y, SujetoNombreMiddleTopRect.Width, SujetoNombreMiddleTopRect.Height / 2);
                tf_left.DrawString(voucher.RazonSocial, fontContent, XBrushes.Black, SujetoNombreMiddleTopContentRect, XStringFormats.TopLeft);

                    //Registro información Fiscal del Sujeto Retenido
                XRect SujetoRetencionMiddleTopRect = new XRect(SujetoNombreMiddleTopRect.X + SujetoNombreMiddleTopRect.Width + innerMargin, SujetoNombreMiddleTopRect.Y, SujetoNombreMiddleTopRect.Width - (borderMargin - innerMargin), SujetoNombreMiddleTopRect.Height);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), SujetoRetencionMiddleTopRect);

                XRect SujetoRetencionMiddleTopTitleRect = new XRect(SujetoRetencionMiddleTopRect.X, SujetoRetencionMiddleTopRect.Y, SujetoRetencionMiddleTopRect.Width, SujetoRetencionMiddleTopRect.Height / 2);
                tf_center.DrawString("Registro información Fiscal del Sujeto Retenido", fontSubtitle, XBrushes.Black, SujetoRetencionMiddleTopTitleRect, XStringFormats.TopLeft);

                XRect SujetoRetencionMiddleTopContentRect = new XRect(SujetoRetencionMiddleTopRect.X, SujetoRetencionMiddleTopRect.Center.Y, SujetoRetencionMiddleTopRect.Width, SujetoRetencionMiddleTopRect.Height / 2);
                tf_center.DrawString("voucher.CustomerID", fontContent, XBrushes.Black, SujetoRetencionMiddleTopContentRect, XStringFormats.TopLeft);

                //Main table
                XRect MainTableRect = new XRect(SujetoNombreMiddleTopRect.X, SujetoNombreMiddleTopRect.Bottom + innerMargin * 2, agenteDireccionMiddleTopRect.Width, agenteDireccionMiddleTopRect.Height*2);

                //Main table Header
                XRect MainTableHeaderRect = new XRect(MainTableRect.X, MainTableRect.Y, MainTableRect.Width, MainTableRect.Height/2);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), MainTableHeaderRect);

                    //Main table Header Oper. Nro.
                XRect MainTableHeaderOperRect = new XRect(MainTableHeaderRect.X, MainTableHeaderRect.Y, MainTableHeaderRect.Width/10, MainTableHeaderRect.Height);
                tf_left.DrawString("Oper. Nro.", fontSubtitle, XBrushes.Black, MainTableHeaderOperRect, XStringFormats.TopLeft);

                    //Main table Header Fecha
                XRect MainTableHeaderFechaRect = new XRect(MainTableHeaderOperRect.TopRight.X, MainTableHeaderOperRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Fecha", fontSubtitle, XBrushes.Black, MainTableHeaderFechaRect, XStringFormats.TopLeft);

                    //Main table Header Nro. Factura
                XRect MainTableHeaderFacturaRect = new XRect(MainTableHeaderFechaRect.TopRight.X, MainTableHeaderFechaRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Nro. Factura", fontSubtitle, XBrushes.Black, MainTableHeaderFacturaRect, XStringFormats.TopLeft);

                    //Main table Header Nro. Control FC
                XRect MainTableHeaderControlFCRect = new XRect(MainTableHeaderFacturaRect.TopRight.X, MainTableHeaderFacturaRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Nro. Control FC", fontSubtitle, XBrushes.Black, MainTableHeaderControlFCRect, XStringFormats.TopLeft);

                    //Main table Header Nro. de ND
                XRect MainTableHeaderNDRect = new XRect(MainTableHeaderControlFCRect.TopRight.X, MainTableHeaderControlFCRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Nro. de ND", fontSubtitle, XBrushes.Black, MainTableHeaderNDRect, XStringFormats.TopLeft);

                    //Main table Header Nro. De NC
                XRect MainTableHeaderNCRect = new XRect(MainTableHeaderNDRect.TopRight.X, MainTableHeaderNDRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Nro. De NC", fontSubtitle, XBrushes.Black, MainTableHeaderNCRect, XStringFormats.TopLeft);

                    //Main table Header Base imponible
                XRect MainTableHeaderImponibleRect = new XRect(MainTableHeaderNCRect.TopRight.X, MainTableHeaderNCRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Base imponible", fontSubtitle, XBrushes.Black, MainTableHeaderImponibleRect, XStringFormats.TopLeft);

                    //Main table Header Alícuota
                XRect MainTableHeaderAlicuotaRect = new XRect(MainTableHeaderImponibleRect.TopRight.X, MainTableHeaderImponibleRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Alícuota", fontSubtitle, XBrushes.Black, MainTableHeaderAlicuotaRect, XStringFormats.TopLeft);

                    //Main table Header Impuesto
                XRect MainTableHeaderImpuestoRect = new XRect(MainTableHeaderAlicuotaRect.TopRight.X, MainTableHeaderAlicuotaRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("Impuesto", fontSubtitle, XBrushes.Black, MainTableHeaderImpuestoRect, XStringFormats.TopLeft);

                    //Main table Header IVA Ret.
                XRect MainTableHeaderIvaRetRect = new XRect(MainTableHeaderImpuestoRect.TopRight.X, MainTableHeaderImpuestoRect.TopRight.Y, MainTableHeaderOperRect.Width, MainTableHeaderRect.Height);
                tf_left.DrawString("IVA Ret.", fontSubtitle, XBrushes.Black, MainTableHeaderIvaRetRect, XStringFormats.TopLeft);

                //Main table Row
                XRect MainTableRowRect = new XRect(MainTableHeaderRect.X, MainTableHeaderRect.Bottom, MainTableHeaderRect.Width, MainTableHeaderRect.Height);

                    //Main table Row Oper. Nro.
                XRect MainTableRowOperRect = new XRect(MainTableRowRect.X, MainTableRowRect.Y, MainTableRowRect.Width / 10, MainTableRowRect.Height);
                tf_left.DrawString(voucher.DocNum, fontContent, XBrushes.Black, MainTableRowOperRect, XStringFormats.TopLeft);

                    //Main table Row Fecha
                XRect MainTableRowFechaRect = new XRect(MainTableRowOperRect.TopRight.X, MainTableRowOperRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.documentDate.ToShortDateString(), fontContent, XBrushes.Black, MainTableRowFechaRect, XStringFormats.TopLeft);

                    //Main table Row Nro. Factura
                XRect MainTableRowFacturaRect = new XRect(MainTableRowFechaRect.TopRight.X, MainTableRowFechaRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.VendorDocNum, fontContent, XBrushes.Black, MainTableRowFacturaRect, XStringFormats.TopLeft);

                    //Main table Row Nro. Control FC
                XRect MainTableRowControlFCRect = new XRect(MainTableRowFacturaRect.TopRight.X, MainTableRowFacturaRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.txtField, fontContent, XBrushes.Black, MainTableRowControlFCRect, XStringFormats.TopLeft);

                    //Main table Row Nro. de ND
                XRect MainTableRowNDRect = new XRect(MainTableRowControlFCRect.TopRight.X, MainTableRowControlFCRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.VendorDocNum, fontContent, XBrushes.Black, MainTableRowNDRect, XStringFormats.TopLeft);

                    //Main table Row Nro. De NC
                XRect MainTableRowNCRect = new XRect(MainTableRowNDRect.TopRight.X, MainTableRowNDRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.VendorDocNum, fontContent, XBrushes.Black, MainTableRowNCRect, XStringFormats.TopLeft);

                    //Main table Row Base imponible
                XRect MainTableRowImponibleRect = new XRect(MainTableRowNCRect.TopRight.X, MainTableRowNCRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.taxableAmount.ToString(), fontContent, XBrushes.Black, MainTableRowImponibleRect, XStringFormats.TopLeft);

                    //Main table Row Alícuota
                XRect MainTableRowAlicuotaRect = new XRect(MainTableRowImponibleRect.TopRight.X, MainTableRowImponibleRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.getTaxPercent(), fontContent, XBrushes.Black, MainTableRowAlicuotaRect, XStringFormats.TopLeft);

                    //Main table Row Impuesto
                XRect MainTableRowImpuestoRect = new XRect(MainTableRowAlicuotaRect.TopRight.X, MainTableRowAlicuotaRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.getTax(), fontContent, XBrushes.Black, MainTableRowImpuestoRect, XStringFormats.TopLeft);

                    //Main table Row IVA Ret.
                XRect MainTableRowIvaRetRect = new XRect(MainTableRowImpuestoRect.TopRight.X, MainTableRowImpuestoRect.TopRight.Y, MainTableRowOperRect.Width, MainTableRowRect.Height);
                tf_left.DrawString(voucher.taxAmount.ToString(), fontContent, XBrushes.Black, MainTableRowIvaRetRect, XStringFormats.TopLeft);

                //Footer note
                double footerHeight = (fontTitle.Size*2);
                XRect footerNoteRect = new XRect(borderMargin, page.Height - footerHeight - borderMargin, agenteDireccionMiddleTopRect.Width, footerHeight);
                gfx.DrawRectangle(new XPen(XColors.Black, 0.3), footerNoteRect);
                tf_left.DrawString(Voucher.NOTA, fontContent, XBrushes.Black, footerNoteRect, XStringFormats.TopLeft);

                //Footer Sign
                XRect footerSignRect = new XRect(footerNoteRect.X, footerNoteRect.Y - (borderMargin * 2), page.Width / 4, fontSubtitle.Size + innerMargin);
                tf_left.DrawString("Departamento de Impuestos", fontSubtitle, XBrushes.Black, footerSignRect, XStringFormats.TopLeft);

                XRect footerSignLineRect = new XRect(footerSignRect.X, footerSignRect.Y - borderMargin, footerSignRect.Width, fontContent.Size);
                tf_left.DrawString("______________________________", fontContent, XBrushes.Black, footerSignLineRect, XStringFormats.TopLeft);

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
