
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTest
{
    // 利用Task写入时间
    // 
    public class TaskTest2
    {
        const int Repetitions = 100;
        static Task task1;
        static Task task2;
        public static void TestStart()
        {
            // public int i = 0;
            task1 = Task.Run(() => Write_1());
            task2 = Task.Run(() => Write_2());

            // var path = @"e:\xkx\test\Write2.txt";

            // using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            // {
            //     for (int i = 0; i < Repetitions; i++)
            //     {
            //         sw.WriteLine($"Time is {DateTime.Now.TimeOfDay.TotalMilliseconds}, Thread.CurrentThread.Name is {Thread.CurrentThread.Name}, " + 
            //                 $"i is Two_{i}");
            //     }
            // }

            task1.Wait();
            task2.Wait();

            Console.WriteLine("END");
        }

        public static void Write_1()
        {
            var path = @"e:\xkx\test\Write1.txt";

            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < Repetitions; i++)
                {
                    sw.WriteLine($"Time is {DateTime.Now.TimeOfDay.TotalMilliseconds}, task.Id is {task1.Id}, i is One_{i}");
                }
            }
        }
        public static void Write_2()
        {
            var path = @"e:\xkx\test\Write2.txt";

            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < Repetitions; i++)
                {
                    sw.WriteLine($"Time is {DateTime.Now.TimeOfDay.TotalMilliseconds}, task.Id is {task2.Id}, i is Two_{i}");
                }
            }
        }        
    }
}