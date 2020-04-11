using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{

    public static class TaskExtension
    {
        public static void SafeFireAndForget(this Task t, bool configureAwait, Action<Exception> onError)
        {
            try
            {
                t.ConfigureAwait(configureAwait).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                onError(e);
            }
        }
    }

    class Program
    {

        private static readonly Random Rnd = new Random();

        private static void Write(object text)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - {text}");
        }

        private static void DoWork()
        {
            Write("Work started");
            for (int i = 0; i < 5; i++)
            {
                Write(i.ToString());
                Thread.Sleep(Rnd.Next(250, 750));
            }
            Write("Work finished");
        }
        
        private static void DoWorkWithError()
        {
            Write("Work started");
            throw new Exception("An error occured");
            for (int i = 0; i < 5; i++)
            {
                Write(i.ToString());
                Thread.Sleep(Rnd.Next(250, 750));
            }
            Write("Work finished");
        }

        public static async Task<int> DoWorkAsync1()
        {
            var c = new WebClient(); 
            var t = await c.DownloadDataTaskAsync(new Uri("http://www.google.com"));
            return t.Length;
        }

        public static void DoWorkAsync()
        {
            var c = new WebClient();
            var c2 = new WebClient();
            var t1 = c.DownloadDataTaskAsync(new Uri("http://www.google.com"));
            var t2 = c2.DownloadDataTaskAsync(new Uri("http://www.idnes.cz"));
            Task.WaitAll(t1, t2);
            //await Task.WhenAll();
        }

        //public static Task DoWorkAsyncOld()
        //{
        //    WebClient c = new WebClient();

        //}

        public static Task<byte[]> Produce1Async(int input)
        {
            var a = input * 2;
            var c = new WebClient();
            return c.DownloadDataTaskAsync(new Uri("http://www.google.com"));
        }


        public static Task ExecuteTest()
        {
            Test();
        }

        public static async void Test() // Fire and forget
        {
            var c = new WebClient();
            throw new Exception("Error");
            c.DownloadDataTaskAsync(new Uri("http://www.google.com"));
        }

        public static async Task Main(string[] args)
        {

            try
            {
                Test().;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadLine();
        }
    }


    //public class Test2
    //{

    //    public Task<int> Pokus(int a, int b)
    //    {
    //        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.None);

    //        try
    //        {

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e);
    //            throw;
    //        }

    //        tcs.SetResult(5);
    //        return tcs.Task;
    //    }

    //}

    class ThreadTest
    {
        //static void Main()
        //{
        //    Thread t = new Thread(new ThreadStart(Go));

        //    t.Start();   // Run Go() on the new thread.
        //    Go();        // Simultaneously run Go() in the main thread.
        //}

        //static void Go()
        //{
        //    Console.WriteLine("hello!");
        //}
    }

}

