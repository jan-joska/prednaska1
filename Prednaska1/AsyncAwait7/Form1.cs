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

        private void button1_Click(object sender, EventArgs e)
        {
            var task = DoAsyncWork();
            task.Wait(); // Též task.result
        }

        public static async Task DoAsyncWork()
        {
            // Deadlock jako fík.
            await Task.Delay(2000);

            // Lepší, ale blokuji UI vlákno, takže taky jakože napiču
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
