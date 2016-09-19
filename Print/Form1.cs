using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize the dialog's PrinterSettings property to hold user
            // defined printer settings.
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();

            // Initialize dialog's PrinterSettings property to hold user
            // set printer settings.
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog1.ShowNetwork = true;

            pageSetupDialog1.AllowMargins = true;
            pageSetupDialog1.AllowOrientation = true;
            pageSetupDialog1.AllowPaper = true;
            pageSetupDialog1.AllowPrinter = true;
            //pageSetupDialog1.Reset();
            pageSetupDialog1.EnableMetric = true;
            pageSetupDialog1.Document = printDocument1;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();

            // If the result is OK, display selected settings in
            // ListBox1. These values can be used when printing the
            // document.
            if (result == DialogResult.OK)
            {
                Console.WriteLine("Margins:");
                Console.WriteLine(pageSetupDialog1.PageSettings.Margins);
                Console.WriteLine("PaperSize:");
                Console.WriteLine(pageSetupDialog1.PageSettings.PaperSize);
                Console.WriteLine("Landscape:");
                Console.WriteLine(pageSetupDialog1.PageSettings.Landscape);
                Console.WriteLine("PrinterName:");
                Console.WriteLine(pageSetupDialog1.PrinterSettings.PrinterName);
                Console.WriteLine("PrintRange:");
                Console.WriteLine(pageSetupDialog1.PrinterSettings.PrintRange);

                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;

                printPreviewControl1.InvalidatePreview();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.AllowCurrentPage = true;
            printDialog1.AllowPrintToFile = true;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {            
            Font font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);

            // text
            e.Graphics.DrawString("My Demo Company", font, Brushes.Black, 5, 5);

            // line
            e.Graphics.DrawLine(Pens.Black, 5, 5, 350, 5);

            e.HasMorePages = false;
        }
    }
}
