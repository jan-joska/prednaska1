using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace ParalellProcessing
{
    internal class Program
    {
        public static BigInteger Factorial(int i)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Vstup musí být nezáporné celé číslo");
            }

            if (i == 0 || i == 1)
            {
                return 1;
            }

            BigInteger result = 1;
            for (var p = 1; p <= i; p++)
            {
                result *= p;
            }

            Thread.Sleep(1);
            return result;
        }

        private static void Main(string[] args)
        {
            var serialResult = Measure(CalculateSerial);
            var paralellResult = Measure(CalculateParalell);
            var percentage = paralellResult / (float) serialResult * 100f;

            Console.WriteLine($"Serial: {serialResult} ms, Parallel: {paralellResult} ms ({percentage} %)");

            Console.ReadLine();
        }

        private static long Measure(Action payload)
        {
            var sw = new Stopwatch();
            sw.Start();
            payload.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    private static void CalculateSerial()
        {
            Console.WriteLine("Calculating serial");
            for (var i = 0; i <= 2000; i++)
            {
                Factorial(i);
            }
        }

        private static void CalculateParalell()
        {
            Console.WriteLine("Calculating in paralell");
            Parallel.For(0, 2000, i => { Factorial(i); });
        }
    }
}