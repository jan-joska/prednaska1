using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;

namespace AsyncAwait6
{

    public class TestClass
    {
        public event EventHandler<EventArgs> OperationInvoked;

        public void FireEvent()
        {
            OperationInvoked?.Invoke(this, new EventArgs());
        }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            //Sample 1 - NEMÁM CO AWAITOVAT, ZPRACOVÁVÁNÍ POJEDE HNED DÁL
            Console.WriteLine("Volám async funkionalitu");
            DoWorkAsync();
            Console.WriteLine("Ted uz by to melo byt stazene");
            Console.ReadLine();

            // Sample 2 - vyjimka ve vzduchu - NEMÁM CO AWAITOVAT, VÝJIMKA NENÍ PŘEHOZENA, ZPRACOVÁVÁNÍ
            // JEDE DÁL, NIC NECHYTIM
            Console.WriteLine("Volám async funkionalitu");
            try
            {
                DoWorkAsync2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Ted uz by to melo byt stazene");


            // Sample jak uzivat void - KOREKTNÍ UŽÍTÍ VOID - UDÁLOST
            var c = new TestClass();
            c.OperationInvoked += COnOperationInvoked;
            c.FireEvent();
            Console.ReadLine();
        }

        // UDÁLOST NEMÁ CO AWAITOVAT V POSTUPU VOLÁNÍ JE NA VRACHOLU
        private static async void COnOperationInvoked(object sender, EventArgs e)
        {
            await Task.Delay(500);
            Console.WriteLine("Asynchrone zkonzumovano");
        }


        public static async void DoWorkAsync()
        {
            var c = new WebClient();
            Console.WriteLine("Zahajuji stahovani");
            var content = await c.DownloadStringTaskAsync(new Uri("http://www.idnes.cz"));
            Console.WriteLine("Stahovani dokonceno");
        }

        public static async void DoWorkAsync2()
        {
            var c = new WebClient();
            Console.WriteLine("Zahajuji stahovani");
            var content = await c.DownloadStringTaskAsync(new Uri("http://www.idnes.cz"));
            throw new Exception("Neznama chyba");
        }

    }
}
