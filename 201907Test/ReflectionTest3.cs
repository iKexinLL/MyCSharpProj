using System;
using System.Collections.Generic;

namespace MyTest
{
    /// <summary>
    /// Generic method
    /// </summary>
    public class ReflectionTest3
    {
        public static void TestStart()
        {
            Type type;
            type = typeof(System.Nullable<>);
            Console.WriteLine($"System.Nullable<>.ContainsGenericParameters is {type.ContainsGenericParameters}");
            Console.WriteLine($"System.Nullable<>.IsGenericType is {type.IsGenericType}");

            type = typeof(System.Nullable<DateTime>);
            Console.WriteLine($"System.Nullable<DateTime>.ContainsGenericParameters is {type.ContainsGenericParameters}");
            Console.WriteLine($"System.Nullable<DateTime>.IsGenericType is {type.IsGenericType}");

            // 泛型类型反射
            Console.WriteLine("泛型类型反射测试");
            List<int> lt = new List<int>();
            type = lt.GetType();

            foreach( var i in type.GetGenericArguments())
            {
                Console.WriteLine("List<int> paramter is " + type.FullName);
            }
        }
    }
}