using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncAwait2
{
    internal class Program
    {
        // DEMONSTRACE ČEKÁNÍ NA AWAITABLE

        public static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var content = await client.GetByteArrayAsync(new Uri("http://www.idnes.cz"));

            var freak = new Freak(); 

            await freak; // <---------- 

            await 15; // <---------- 

            Console.ReadLine();
        }
    }

    public class Freak
    {
        public TaskAwaiter GetAwaiter()
        {
            throw new NotImplementedException();
        }
    }

    public static class IntExtensions
    {
        public static TaskAwaiter GetAwaiter(this int input)
        {
            return new TaskAwaiter();
        }
    }
}