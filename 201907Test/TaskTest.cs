using System;
using System.Threading.Tasks;

namespace MyTest
{
    public class TaskTest
    {
        const int Repetitions = 1000;

        public static void TestStart()
        {
            // 调用Task.Run()之后,作为参数的Action几乎like开始执行
            // 这称之为"热"任务,即已触发并开始执行.
            // "冷"任务则相反,它需要在显示触发之后才开始异步工作
            //-------------
            // 注意,在调用Run()之后,"热"任务的确切状态是不确定的.
            // 这个状态由操作系统来确定.
            Task task = Task.Run( () => 
                {
                    Console.WriteLine("Task Start");
                    for (int i = 0; i < Repetitions; i++)
                    {
                        Console.WriteLine("-");
                    }
                });
            
            for (int i = 0; i < Repetitions; i++)
            {
                Console.WriteLine(i);
            }

            task.Wait();
        }

        
    }
}