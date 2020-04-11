using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ConfigureAwait(true) - výchozí hodnota. Výnutí návrat po zpracování do UI vlákna.
        // Při pokusu nastavit jakoukoliv vlastnost kteréhokoliv controlu dojde k výjimce.
        private async void button1_Click(object sender, EventArgs e)
        {
            var c = new WebClient();
            var result = await c.DownloadStringTaskAsync(new Uri("http://www.idnes.cz"));
            textBox1.Text = result.Length.ToString();
        }

        // NEMUSÍ SE PODAŘIT ZHROUTIT POKAŽDÉ - ZÁKEŘNÁ CHYBA
        // ConfigureAwait(false) způsobí pravděpodobně návrat do jiného vlákna než UI vlákna.
        // Při pokusu nastavit jakoukoliv vlastnost kteréhokoliv controlu dojde k výjimce.
        private async void button2_Click(object sender, EventArgs e)
        {
            var c = new WebClient();
            var result = await c.DownloadStringTaskAsync(new Uri("http://www.idnes.cz")).ConfigureAwait(false);
            textBox1.Text = result.Length.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sc = SynchronizationContext.Current;
            var text = sc == null ? "ThreadPoolSynContext" : sc.ToString();
            textBox1.Text = text;

        }
    }
}
