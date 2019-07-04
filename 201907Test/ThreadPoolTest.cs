using System;
using System.Threading;

namespace MyTest
{
    /*
        线程池尽量不处理长时间运行的作业
        或者处理需要与其他线程(包括主线程)同步的作业
     */
    public class ThreadPoolTest
    {
        public const int Repetitions = 100;

        public static void TestStart()
        {
            ThreadPool.QueueUserWorkItem(DoWork, '+');

            for (int i = 0; i < Repetitions; i++)
            {
                Console.WriteLine("-");
            }

            Thread.Sleep(1000);
        }


        private static void DoWork(object state)
        {
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write(state);
            }
        }
    }
}