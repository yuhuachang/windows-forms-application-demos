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
using ZXing.QrCode;

/// <summary>
/// 1. Copy webcam source from: http://zxingnet.codeplex.com/SourceControl/latest#trunk/Clients/WindowsFormsDemo/WebCam.cs
///    to enable webcam.
/// 2. Install zxing library: https://github.com/zxing/zxing
///     1. In Solution Exploer, right click References in the project and choose Management NuGet Packages...
///     2. Search zxing and install ZXing.Net
/// 3. using com.google.zxing.qrcode;
/// 
/// Note:
///     1. After test, QRCode scan is quick.  EAN13 or other 1D barcode is slow.
///     2. Can go to https://zxing.appspot.com/generator to generate QRCode for testing.
/// </summary>
namespace ScanBarcodeWithWebCam
{
    public partial class Form1 : Form
    {
        private WebCam wCam;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (wCam == null)
            {
                wCam = new WebCam { Container = pictureBox1 };
                wCam.OpenConnection();
                timer1.Start();
                button1.Text = "Stop Scan QR Code";
            }
            else
            {
                timer1.Stop();
                wCam.Dispose();
                wCam = null;
                button1.Text = "Start Scan QR Code";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wCam == null) return;

            var bitmap = wCam.GetCurrentImage();
            if (bitmap == null) return;

            var reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                Console.WriteLine(result.BarcodeFormat.ToString());
                Console.WriteLine(result.Text);
            }
        }
    }
}
