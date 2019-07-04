

using System;
using System.Diagnostics;

namespace MyTest
{
    public class ReflectionTest
    {
        public static void TestStart()
        {
            DateTime dateTime = new DateTime();
            // GetType()只能用于对象实例
            Type type = dateTime.GetType();
            // Type type2 = Int64.GetType();

            foreach (System.Reflection.PropertyInfo property in 
                type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            // 使用typeof()创建System.Type实例
            ThreadPriorityLevel priority;
            priority = (ThreadPriorityLevel)Enum.Parse(
                typeof(ThreadPriorityLevel), "Idle"
            );

            Console.WriteLine(priority.ToString());
        }
    }
}