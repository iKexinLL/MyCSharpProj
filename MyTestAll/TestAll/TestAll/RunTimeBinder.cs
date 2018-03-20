using System;
using Microsoft.CSharp.RuntimeBinder;


namespace TestAll
{
    class MyClass1
    {
        public int Add(int var1, int var2)
            => var1 + var2;
    }
    
    class MyClass2 { }

    class RunTimeBinderTest
    {
        static int _callCount = 0;

        // 动态查找
        static dynamic GetValue()
        {
            if (_callCount++ == 0)
                return new MyClass1();

            return new MyClass2();
        }
        
        public static void TestAll()
        {
            try
            {
                dynamic firstResult = GetValue();
                dynamic secondResult = GetValue();

                Console.WriteLine($"firstResult is {firstResult.ToString()}");
                Console.WriteLine($"secondResult is {secondResult.ToString()}");
                Console.WriteLine($"firstResult call is {firstResult.Add(2, 3)}");
                Console.WriteLine($"secondResult call is {secondResult.Add(2, 3)}");
            }
            catch (RuntimeBinderException e)
            {
                Console.WriteLine(e);
//                throw;
            }
        
        }
    }
}
