using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIResponsivness
{
    public partial class Form1 : Form
    {
        public delegate void WriteDelegate(object o);

        public Form1()
        {
            InitializeComponent();
        }

        private void Write(object o)
        {
            textBox1.Text += $"{o}{Environment.NewLine}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = new WebClient();
            var data = c.DownloadData(new Uri("http://www.idnes.cz"));
            Write($"IDNES.CZ HOMEPAGE {data.Length}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            Write("Complete");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new WriteDelegate(Write), "Invoked complete");
                }
                else
                {
                    Write("Completed without invoke");
                }
            });

            // Toto způsobí výjimku
            //Task.Run(() =>
            //{
            //    Thread.Sleep(5000);
            //    Write("Complete");
            //});
        }
    }
}