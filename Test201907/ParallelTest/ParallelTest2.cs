using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Reflection;

/// <summary>
/// Concurrent提供了线程安全的集合类
/// 普通集合类会在并行时报错
/// </summary>
namespace MyTest
{

    /// <summary>
    /// from https://www.cnblogs.com/woxpp/p/3925094.html
    /// </summary>
    public class ParallelTestClassTwo
    {
        private static Dictionary<string, string> dic = null;

        private static ConcurrentBag<string> cb = new ConcurrentBag<string>();
        private static ConcurrentDictionary<string, string> cd = 
            new ConcurrentDictionary<string, string>();

        private static List<string> lis = null;

        private ParallelTestClassTwo ins = new ParallelTestClassTwo();
        public static void TestStart()
        {

            dic = new Dictionary<string, string>();
            Thread.Sleep(3000);
            // 检测运行时间
            Stopwatch swTask = new Stopwatch();
            swTask.Start();
            Parallel.Invoke(() => SetPro(500,"SetPro500_1"), () => SetPro(500,"SetPro500_2"), () => SetPro(500,"SetPro500_3"), () => SetPro(500,"SetPro500_4"));
            swTask.Stop();
            Console.WriteLine("500条数据 并行编程所耗时间:" + swTask.ElapsedMilliseconds);

            // dic.Clear();
            Thread.Sleep(3000);/*防止并行操作 与 顺序操作冲突*/
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SetPro(500,"SetPro500_1");
            SetPro(500,"SetPro500_2");
            SetPro(500,"SetPro500_3");
            SetPro(500,"SetPro500_4");
            sw.Stop();
            Console.WriteLine("500条数据  顺序编程所耗时间:" + sw.ElapsedMilliseconds);

            // dic.Clear();
            Thread.Sleep(3000);
            swTask.Restart();
            /*执行并行操作*/
            Parallel.Invoke(() => SetPro(10000,"SetPro10000_1"), () => SetPro(10000,"SetPro10000_2"), () => SetPro(10000,"SetPro10000_3"), () => SetPro(10000,"SetPro10000_4"));
            swTask.Stop();
            Console.WriteLine("10000条数据 并行编程所耗时间:" + swTask.ElapsedMilliseconds);

            // dic.Clear();
            Thread.Sleep(3000);
            sw.Restart();
            SetPro(10000,"SetPro10000_1");
            SetPro(10000,"SetPro10000_2");
            SetPro(10000,"SetPro10000_3");
            SetPro(10000,"SetPro10000_4");
            sw.Stop();
            Console.WriteLine("10000条数据 顺序编程所耗时间:" + sw.ElapsedMilliseconds);
        }

        private static void SetPro(int count, string name)
        {
            Console.WriteLine(name + "开始执行 ");
            for (int i = 0; i < count; i++)
            {
                // dic.Add(name + count, count.ToString());
                // lis.Add(name + count + count.ToString());
                cb.Add(name + count + count.ToString());
            }
            // }
            Console.WriteLine(name + "执行完成 ");
        }
    }
}