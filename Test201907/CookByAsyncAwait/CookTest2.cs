using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
 
namespace Test201907.CookByAsyncAwait
{
    public class CookTest2 
    {
        public static async Task CookStartByTask()
        {
            // 鸡蛋
            // 咖啡
            // 面包
            // 有个方法,生成熟的食物
            Stopwatch sw = new Stopwatch();
            sw.Start();
 
            // Eggs egg = new Eggs("egg");
            // Bread bread = new Bread("bread");
            // Coffee coffee = new Coffee("coffee");
 
            var foods = new List<BaseFood>();
 
            foods.Add(new Eggs("egg"));
            foods.Add(new Bread("bread"));
            foods.Add(new Coffee("coffee"));
 
            List<Task> tasks = new List<Task>();
 
            // 如何"优雅"的添加?
            foreach (var i in foods)
            {
                tasks.Add(i.CookByTask());
            }


            // TODO: 无法将 lambda 表达式 转换为类型“IEnumerable<Task>”，原因是它不是委托类型 [MyTest]csharp(CS1660)
            // 需要 lambda表达式以及LINQ
            // tasks.AddRange(() => foods.Select(i => i.CookByTask()));
 
 
            // while (!egg.IsCookFinished || !bread.IsCookFinished || !coffee.IsCookFinished)
            // {
            //     Thread.Sleep(100);
            //     System.Console.Write(".");
            //     // await Task.WhenAll(tasks);
            // }
 
            while (tasks.Any())
            {
                // System.Console.Write(".......");
                Task finished = await Task.WhenAny(tasks);
                tasks.Remove(finished);
                // System.Console.WriteLine(finished.Id);
            }
 
            sw.Stop();

            Console.WriteLine("cook time is " + foods.Sum(x => x.Cooktime));
            Console.WriteLine("Programe time by task  is " + sw.ElapsedMilliseconds);
 
        }
    }
}
 
