using System;
using System.Threading.Tasks;

namespace MyTest
{
    // 处理任务的未处理异常
    // 1. 显示创建延续任务作为那个任务的"错误处理程序"
    // 检测到先驱任务引发未处理的异常,任务调度器会自动调度延续任务.
    // 但是,如果没有这种处理程序,同时在出错的任务上执行Wait()(或其他试图获取Result的动作)
    // 就会引发一个AggregateException
    public class TaskTest4
    {
        public static void TestStart()
        {
            Task task = Task.Run( () =>
                {
                    throw new InvalidOperationException();
                });
            
            try
            {
                task.Wait();
            }
            catch(AggregateException exception)
            {
                exception.Handle(eachException => 
                    {
                        Console.WriteLine("Error: {0}", eachException.Message);
                        return true;
                    });
            }
        }
    }
}