using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait2
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var content = await client.GetByteArrayAsync(new Uri("http://www.idnes.cz"));

            Console.ReadLine();
        }
    }
}