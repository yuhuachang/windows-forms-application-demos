using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 
/// NuGet install Newtonsoft.Json
/// 
/// </summary>
namespace WebClientDemo
{
    class Customer
    {
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string contact { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            request();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                request();
            }
        }

        private void request()
        {
            // Create web client simulating IE6.
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                "(compatible; MSIE 6.0; Windows NT 5.1; " +
                ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                try
                {
                    // Make request to URL and get response in byte[].
                    byte[] response = client.DownloadData(textBox1.Text);

                    // Convert response byte[] to string
                    string s = System.Text.Encoding.UTF8.GetString(response);
                    textBox2.Text = s;

                    // Optionally convert response JSON to object.
                    try
                    {
                        Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(s);
                        textBox2.Text = "";
                        foreach (Customer c in customers)
                        {
                            textBox2.Text += c.customer_id + " - " + c.customer_name + Environment.NewLine;
                        }
                    }
                    catch (Exception jsonError)
                    {
                        Console.WriteLine("not a json message: " + jsonError.Message);
                    }
                }
                catch (Exception ex)
                {
                    // HTTP error.
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
