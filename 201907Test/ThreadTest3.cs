using System;
using System.Threading;


namespace MyTest
{
    public class ThreadTest3
    {
        private static void ThreadFuncOne()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "   i =  " + i);
            }

            Console.WriteLine(Thread.CurrentThread.Name + " has finished");
        }


        public static void TestStart()
        {
            Thread.CurrentThread.Name = "MainThread";

            Thread newThread = new Thread(new ThreadStart(ThreadTest3.ThreadFuncOne));
            newThread.Name = "NewThread";

            for (int j = 0; j < 20; j++)
            {
                if (j == 10)
                {
                    newThread.Start();
                    newThread.Join();
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "   j =  " + j);
                }
            }
            // Console.Read();
        }
    }
}