using System;
using System.Diagnostics;
using System.Threading;

namespace MyTest
{
    public class TaskTest6
    {
        public static Stopwatch clock = new Stopwatch();

        public static void TestStart()
        {
            try
            {
                clock.Start();

                AppDomain.CurrentDomain.UnhandledException += 
                    (s, e) =>
                    {
                        Message("Event handler starting");
                        Delay(4000);
                    };
                Thread thread = new Thread( () => 
                {
                    Message("Throwing exception");
                    throw new Exception();
                });
                thread.Start();
                Delay(2000);
            }
            finally
            {
                Message("Finally block running");
            }
        }

        private static void Delay(int v)
        {
            Message(string.Format("Sleeping for {0} ms", v));
            Thread.Sleep(v);
            Message("Awake");
        }

        private static void Message(string v)
        {
            Console.WriteLine("{0}: {1:0000} : {2}",
                Thread.CurrentThread.ManagedThreadId,
                clock.ElapsedMilliseconds,
                v);
        }
    }
}