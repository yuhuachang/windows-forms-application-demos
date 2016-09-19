using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Height = 320;
            writer.Options.Width = 320;
            writer.Options.PureBarcode = false;
            pictureBox1.Image = writer.Write(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.UPC_A;
            writer.Options.Height = 120;
            writer.Options.Width = 320;
            writer.Options.PureBarcode = false;
            try
            {
                pictureBox1.Image = writer.Write(textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
