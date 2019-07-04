using System;
using System.Threading.Tasks;

namespace MyTest
{
    public class TaskTest3
    {
        public static void TestStart()
        {
            Console.WriteLine("Before");

            Task taskA = Task.Run( () => 
                    Console.WriteLine("Starting...."))
                .ContinueWith(antecedent => 
                    Console.WriteLine("Continuing A...."));
            
            // 先驱任务完成时,两个延续任务将异步执行
            Task taskB = taskA.ContinueWith( antecedent => 
                    Console.WriteLine("Continuing B...."));

            Task taskC = taskA.ContinueWith( antecedent => 
                    Console.WriteLine("Continuing C...."));
            
            // Task.WaitAll()的调用阻塞了控制流,
            // 直到taskB,taskC都完成才能继续.
            Task.WaitAll(taskB, taskC);
            Console.WriteLine("Finished");
            
        }
    }
}