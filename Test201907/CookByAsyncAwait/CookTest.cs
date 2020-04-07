using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Test201907.CookByAsyncAwait
{
    public class CookTest
    {
        public static void CookStart()
        {
            // 鸡蛋
            // 咖啡
            // 面包
            // 有个方法,生成熟的食物
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Eggs egg = new Eggs("egg");
            // egg.CookNormal();
            Bread bread = new Bread("bread");
            // bread.CookNormal();
            Coffee coffee = new Coffee("coffee");
            // coffee.CookNormal();

            sw.Stop();
            Console.WriteLine("cook time is " + (egg.Cooktime + bread.Cooktime + coffee.Cooktime));
            Console.WriteLine("Programe time is " + sw.ElapsedMilliseconds / 1000);

            sw.Restart();

            List<Task> tasks = new List<Task>();
            tasks.Add(egg.CookByTask());
            tasks.Add(bread.CookByTask());
            tasks.Add(coffee.CookByTask());


            // Task.WhenAll(tasks);
            // while (tasks.Any())
            // {
            //     Task finished = Task.WhenAny(tasks);
            //     // System.Console.WriteLine(finished);
            //     tasks.RemoveAt(finished.Id);
            //     // System.Console.WriteLine(finished.Id);
            // }

            sw.Stop();

            Console.WriteLine("Programe time by task  is " + sw.ElapsedMilliseconds);

        }

        public static async Task CookStartByTask()
        {
            // 鸡蛋
            // 咖啡
            // 面包
            // 有个方法,生成熟的食物
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Eggs egg = new Eggs("egg");
            Bread bread = new Bread("bread");
            Coffee coffee = new Coffee("coffee");

            List<Task> tasks = new List<Task>();
            tasks.Add(egg.CookByTask());
            tasks.Add(bread.CookByTask());
            tasks.Add(coffee.CookByTask());


            while (!egg.IsCookFinished || !bread.IsCookFinished || !coffee.IsCookFinished)
            {
                Thread.Sleep(100);
                System.Console.Write(".");
                // await Task.WhenAll(tasks);
            }

            while (tasks.Any())
            {
                // System.Console.Write(".......");
                Task finished = await Task.WhenAny(tasks);
                tasks.Remove(finished);
                // System.Console.WriteLine(finished.Id);
            }


            sw.Stop();

            Console.WriteLine("Programe time by task  is " + sw.ElapsedMilliseconds);

        }
    }
}