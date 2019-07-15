

using System;
using System.Diagnostics;

namespace MyTest
{
    public class ReflectionTest
    {
        public static void TestStart()
        {
            var datetime = new DateTime();

            // GetType: Gets the System.Type of the current instance.
            // current instance 说明只能再实例上使用.
            var type = datetime.GetType();
            
            foreach (var property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            // 使用typeof()创建System.Type实例
            ThreadPriorityLevel priority = (ThreadPriorityLevel)Enum.Parse(
                typeof(ThreadPriorityLevel), "Idle"
            );

            foreach (var item in Enum.GetNames(typeof(ThreadPriorityLevel)))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"(int)ThreadPriorityLevel.Idle is {(int)ThreadPriorityLevel.Idle}");
            Console.WriteLine($"ThreadPriorityLevel.Idle is {priority}");
            Console.WriteLine($"ThreadPriorityLevel.Idle.ToString is {priority.ToString()}");
        }
    }
}