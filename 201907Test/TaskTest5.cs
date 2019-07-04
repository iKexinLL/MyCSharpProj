using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyTest
{
    public class TaskTest5
    {
        public static void TestStart()
        {
            bool parentTaskFaulted = false;

            Task task = new Task( () =>
                {
                    throw new InvalidOperationException();
                });
            
            Task continuationTask = task.ContinueWith(
                (antecedentTask) =>
                    {
                        parentTaskFaulted = antecedentTask.IsFaulted;
                        Console.WriteLine($"parentTaskFaulted is {parentTaskFaulted}");
                    }, TaskContinuationOptions.OnlyOnFaulted
            );
            task.Start();
            continuationTask.Wait();

            if (!task.IsFaulted)
            {
                task.Wait();
            }
            else
            {
                task.Exception.Handle(eachException =>
                    {
                        Console.WriteLine("Error: {0}", eachException.Message);
                        return true;
                    });
            }
        }
    }
}