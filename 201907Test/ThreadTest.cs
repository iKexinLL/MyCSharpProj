using System;
using System.Threading;


namespace MyTest
{
    /// <summary>
    /// 使用System.Threading启动一个方法
    /// </summary>
    public class ThreadTest
    {
        public const int Repetitions = 100;

        /// <summary>
        /// 代码为了在不同线程的上下文中运行,
        /// 需要ThreadStart或者ParameterizedThreadStart类型的一个委托
        /// 来标识要执行的代码.
        /// 调用Thread.Start()是告诉操作系统开始并发的执行一个新的线程;
        /// 然后主线程中的控制立即返回,开始执行TestStart()方法中的for循环
        /// 两个线程现在独立运行,不会等待对方,直到调用Join()
        /// </summary>
        public static void TestStart()
        {
            ThreadStart threadStart = DoWork;
            Thread thread = new Thread(threadStart);
            thread.Start();
            

            for (int i = 0; i < Repetitions; i++)
            {
                Console.WriteLine(thread.ThreadState);
                Console.Write('-');
            }

            thread.Join();
        }

        public static void DoWork()
        {
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write('+');
            }
        }
    }
}