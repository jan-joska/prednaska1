using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace AsyncAwait4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public event EventHandler Completed;

        public void DoWork()
        {
            // Delegát
            Task.Run(async delegate { await Task.Delay(50); });
            // Lambda funkce
            Task.Run(async () => { await Task.Delay(50); });
            // volání metody
            Task.Run(AsyncMethodAsync);
            // Lokální funkce
            async Task Function()
            {
                await Task.Delay(50);
            }
            Task.Run(Function);
            // Událost
            Completed += async (sender, args) => { await Task.Delay(50); };


        }
        // Metoda
        private async Task AsyncMethodAsync()
        {
            await Task.Delay(50);
        }


    }
}
