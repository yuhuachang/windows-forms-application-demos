using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Copy webcam source from: http://zxingnet.codeplex.com/SourceControl/latest#trunk/Clients/WindowsFormsDemo/WebCam.cs and add it to your project.
/// This demo shows the usage of AviCap (avicap32.dll).  It works for major USB webcams such as Microsoft LifeCam HD-3000.
/// Default resolution is 640 x 480, not adjustable.  Good for barcode scanning, but not very good for taking pictures.
/// </summary>
namespace WebCam
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
                button1.Text = "Stop WebCam";
            }
            else
            {
                timer1.Stop();
                wCam.Dispose();
                wCam = null;
                button1.Text = "Start WebCam";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wCam == null) return;

            var bitmap = wCam.GetCurrentImage();
            if (bitmap == null) return;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (wCam == null) return;
            var bitmap = wCam.GetCurrentImage();
            if (bitmap == null) return;
            label1.Text = bitmap.Width + " x " + bitmap.Height;
            pictureBox2.Image = bitmap;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
