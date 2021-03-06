using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

/// <summary>
/// 并行导致反射报错吗?
/// 
/// </summary>
namespace MyTest
{
    internal class Product
    {
        public string Category { get; internal set; }
        public string Name { get; internal set; }
        public int SellPrice { get; internal set; }
    }

    /// <summary>
    /// from https://www.cnblogs.com/woxpp/p/3925094.html
    /// </summary>
    public class ParallelTestClass
    {
        private static List<Product> ProductList = null;

        private static Dictionary<string, string> dic = null;

        private ParallelTestClass ins = new ParallelTestClass();
        public static void TestStart()
        {
            // ProductList = new List<Product>();
            

            dic = new Dictionary<string, string>();
            Thread.Sleep(3000);
            // 检测运行时间
            Stopwatch swTask = new Stopwatch();
            swTask.Start();
            // Parallel.Invoke(SetProduct1_500, SetProduct2_500, SetProduct3_500, SetProduct4_500);

            swTask.Stop();
            Console.WriteLine("500条数据 并行编程所耗时间:" + swTask.ElapsedMilliseconds);

            // ProductList = new List<Product>();
            dic.Clear();
            Thread.Sleep(3000);/*防止并行操作 与 顺序操作冲突*/
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SetProduct1_500();
            SetProduct2_500();
            SetProduct3_500();
            SetProduct4_500();
            sw.Stop();
            Console.WriteLine("500条数据  顺序编程所耗时间:" + sw.ElapsedMilliseconds);

            // ProductList = new List<Product>();
            dic.Clear();
            Thread.Sleep(3000);
            swTask.Restart();
            /*执行并行操作*/
            // Parallel.Invoke(() => SetProduct1_10000(), () => SetProduct2_10000(), () => SetProduct3_10000(), () => SetProduct4_10000());
            swTask.Stop();
            Console.WriteLine("10000条数据 并行编程所耗时间:" + swTask.ElapsedMilliseconds);

            // ProductList = new List<Product>();
            dic.Clear();
            Thread.Sleep(3000);
            sw.Restart();
            SetProduct1_10000();
            SetProduct2_10000();
            SetProduct3_10000();
            SetProduct4_10000();
            sw.Stop();
            Console.WriteLine("10000条数据 顺序编程所耗时间:" + sw.ElapsedMilliseconds);
        }

        private static void SetProduct1_500()
        {
            Console.Write("SetProduct1_500 开始执行 ");
            for (int index = 1; index < 500; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);
                dic.Add("SetProduct1_500" + index.ToString(), model.Category);
            }
            Console.WriteLine("SetProduct1_500 执行完成");
        }

        private static void SetProduct2_500()
        {
            Console.Write("SetProduct2_500 开始执行 ");
            for (int index = 500; index < 1000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);

                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);
            }
            Console.WriteLine("SetProduct2 执行完成");
        }

        private static void SetProduct3_500()
        {
            Console.Write("SetProduct3_500 开始执行 ");
            for (int index = 1000; index < 2000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // // ProductList.Add(model);
                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);
            }
            Console.WriteLine("SetProduct3 执行完成");
        }

        private static void SetProduct4_500()
        {
            Console.Write("SetProduct4_500 开始执行 ");
            for (int index = 2000; index < 3000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);
                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);                
            }
            Console.WriteLine("SetProduct4 执行完成");
        }

        private static void SetProduct1_10000()
        {
            Console.Write("SetProduct1_10000 开始执行 ");
            for (int index = 1; index < 20000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);
                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);                
            }
            Console.WriteLine("SetProduct1 执行完成");
        }

        private static void SetProduct2_10000()
        {
            Console.Write("SetProduct2_10000 开始执行 ");
            for (int index = 20000; index < 40000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);
                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);                
            }
            Console.WriteLine("SetProduct2 执行完成");
        }

        private static void SetProduct3_10000()
        {
            Console.Write("SetProduct3_10000 开始执行 ");
            for (int index = 40000; index < 60000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);
                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);                
            }
            Console.WriteLine("SetProduct3 执行完成");
        }

        private static void SetProduct4_10000()
        {
            Console.Write("SetProduct4_10000 开始执行 ");
            for (int index = 60000; index < 80000; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                // ProductList.Add(model);
                var b = MethodBase.GetCurrentMethod().Name;
                // Console.WriteLine($"b is {b}");
                dic.Add(b + index.ToString(), model.Category);                
            }
            Console.WriteLine("SetProduct4 执行完成");
        }
    }
}