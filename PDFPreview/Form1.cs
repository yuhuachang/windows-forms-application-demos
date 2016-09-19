using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

/// <summary>
/// 
/// http://www.pdfsharp.net/wiki/documentviewer-sample.ashx
/// 
/// add PDFShart.MigraDoc
/// </summary>
namespace PDFPreview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Create a new MigraDoc document
            PdfDocument document = CreateDocument();
            
        }

        internal PdfDocument CreateDocument()
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            return document;
        }
    }
}
