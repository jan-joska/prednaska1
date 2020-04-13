using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommonApi
{
    class Program
    {
        static async Task Main(string[] args)
        {

            
            var t1 = Task.Run(DoBlockingWork);
            var t2 = DoAsyncWork();

            await Task.WhenAll(t1, t2);
            Console.WriteLine("done");
            Console.ReadLine();

        }

        private static void DoBlockingWork()
        {
            Console.WriteLine("Performing blocking CPU work");
            Thread.Sleep(2000);
        }

        private static Task DoAsyncWork()
        {
            Console.WriteLine("Performing async operation - event based work");
            return Task.Delay(2000);
        }

    }
}
