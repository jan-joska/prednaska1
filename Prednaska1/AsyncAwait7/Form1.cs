using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            
            // AWAIT zde není - toto se zavolá a asynchroní operace započne
            // na nice nečekám a zatím co hardware dělá práci, pokračuji dále
            var task = DoAsyncWork();
            
            // Zde zaseknu toto vlákno a čekám na událost o zpracování
            // Az operace skončí, díky synchronizačnmu kontextu se pokusí spustit na blokovaném UI vláknu
            // Z této situace se nezotaví
            task.Wait(); // Též task.result
        }

        public static async Task DoAsyncWork()
        {
            // Deadlock jako fík.
            await Task.Delay(2000);

            // Lepší, ale blokuji UI vlákno, pamatujme, nepřítomné Await znamená nepřítomný stavový stroj 
            //await Task.Delay(2000).ConfigureAwait(false);
        }

        private void DoCpuWork()
        {
            Thread.Sleep(5000);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(DoCpuWork);
        }
    }
}
