using System;
using System.IO;
using System.Threading;
using System.Linq;

/*
C# 理解Thread.Join()方法
https://www.cnblogs.com/nzbbody/archive/2012/03/06/2381524.html
MSDN的解释：阻塞调用线程，直到某个线程终止时为止。首先明确几个问题：
1、一个进程由一个或者多个线程组成，线程之间有可能会存在一定的先后关系和互斥关系。
    多线程编程，首先就是要想办法划分线程，减少线程之间的先后关系和互斥关系，
    这样才能保证线程之间的独立性，各自工作，不受影响。
    Google的MapReduce核心思想就是尽量减少线程之间的先后关系和互斥关系。
2、无论如何地想办法，线程之间还是会存在一定的先后关系和互斥关系，这时候可以使用Thread.Join方法。
3、一个线程在执行的过程中，可能调用另一个线程，前者可以称为调用线程，后者成为被调用线程。
4、Thread.Join方法的使用场景：调用线程挂起，等待被调用线程执行完毕后，继续执行。
5、被调用线程执行Join方法，告诉调用线程，你先暂停，我执行完了，你再执行。从而保证了先后关系。
6、考虑一种有意思的情况：在当前线程内调用Thread.CurrentThread.Join() 会出现什么情况？
    分析：假设当前线程为A，此时调用线程为A，被调用线程也为A，由于调用线程A暂停，
    被调用线程A（也就是调用线程A）永远不会执行完毕，造成死锁。
*/

namespace MyTest
{
    public class ThreadTest2
    {
        public static bool isEnd = false;

        // 多线程
        // 线程1 -> 读取一个文件,然后输出"读取完毕"
        // 线程2 -> 一直打印"*"
        public static void TestStart()
        {
            // 进程就是一个team
            // 线程就是team中的人
            // 干活的是team中的人(线程)而不是team(进程)
            /*
                程序从Program中的Main()开始,开启了一个进程,其中包含了一个线程MainThread
                然后在ThreadTest2.TestStart()中,声明了一个Thread,称作NewThread.
                当调用NewThread.Start()的时候,那么就开始调用NewThread
             */

            // string path = @"E:\temp\test.txt";
            ThreadStart threadStart = ReadFile; // 为什么ThreadStart不能带参数?
            Thread thread = new Thread(threadStart);
            // Thread thread2 = new Thread( () => Console.WriteLine());
            // ConsoleChar();

            foreach (var i in Enumerable.Range(1, 10))
            {
                if (i == 5)
                {
                    thread.Start();
                    // 这里很明显 thread阻断了主进程
                    thread.Join();
                }
                else
                {
                    Console.WriteLine($"i is {i}");
                }
            }
            
            // Console.WriteLine("开始调用thread.Start()");
            // thread.Start();
            // Console.WriteLine("结束调用thread.Start()");
            // thread.Join();

            // ConsoleChar();
            
        }

        private static void ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"E:\temp\test.txt"))
                {
                    string line;
                    while ( (line = sr.ReadLine()) != null)
                    {
                        // Thread.Sleep(100);
                        Console.WriteLine($"{line}||");
                    }

                    isEnd = true;
                }
            }
            catch (Exception e)
            {
                Console.Write($"exception is {e.ToString()}");
            }
            
        }

        private static void ConsoleChar()
        {
            while (!isEnd)
                Console.Write("*");
        }
    }
}