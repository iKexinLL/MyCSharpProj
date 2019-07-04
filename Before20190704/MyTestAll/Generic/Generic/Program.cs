using System;
using System.Collections.Generic;

namespace Generic
{
    internal interface IPair<T>
    {
        T First { get; set; }
        T Second { get; set; }
    }


    public struct Pair<T> : IPair<T>
    {
        // 注意这里,并未使用尖括号
        public Pair(T first, T second)
        {
            _first = first;
            _second = default(T);
        }
        
        public T First
        {
            get => _first;
            set => _first = value;
        }
        private T _first;

        public T Second
        {
            get => _second;
            set => _second = value;
        }
        private T _second;
    }

    interface IPair2<TFirst, TSecond>
    {
        TFirst First { get; set; }
        TSecond Second { get; set; }
    }

    public struct Pair2<TFirst, TSecond> : IPair2<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
    }

    public interface IContainer<T>
    {
        ICollection<T> Items { get; set; }
    }

//    public class Person : IContainer<Address>, IContainer<Phone>, IContainer<Email>
//    {
//        ICollection<Address> IContainer<Address>.Items { get; set; }
//        ICollection<Phone> IContainer<Phone>.Items { get; set; }
//        ICollection<Email> IContainer<Email>.Items { get; set; }
//    }

    // 静态方法
    public static class MathEx
    {
        public static T Max<T>(T first, params T[] values)
            where T : IComparable<T>
        {
            T maximum = first;
            foreach (T item in values)
            {
                if (item.CompareTo(maximum) > 0)
                {
                    maximum = item;
                }
            }

            return maximum;
        }
    }
    
    
    class MyGenricClass<T1, T2> 
        where T1 : new()
        where T2 : class
    
    {
        public MyGenricClass(T1 innerObject)
        {
            InnerObject = innerObject;
        }

        public T1 InnerObject { get; }

        public MyGenricClass()
        {
            // 如果不添加约束-- where T1 : new() -- 则无法初始化,
            // 因为编译器无法确定T1类是否有默认构造函数
            var obj = new T1();

            // 但是可以使用default进行默认赋值
            InnerObject = default(T1);
        }
    }

    class GeTest
    {
        public int? Count { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1.可空类型
            System.Nullable<int> nullableInt = null;

            // 这里使用.Value的话,必须保证nullableInt不为空
            // var a = nullableInt.Value;
            // Console.WriteLine($"nullableInt.Value is {nullableInt.Value}");

            // nullableInt = new System.Nullable<int>();
            int? op1 = new int?();
            int? op2 = 5;

            int? result = op1 * op2;

            Console.WriteLine($"result is {result}");

            result = op1 ?? op2; // --> op1 == null ? op2 : op1;
            Console.WriteLine(result);

            // 空接合运算符 --> ??
            result = op1 * 2 ?? 5;

            Console.WriteLine(result);

            Console.WriteLine("Dictionary<string, int>");

            Dictionary<string, int> thingsDictionary = new Dictionary<string, int>();
            thingsDictionary.Add(" Blue Things", 94);
            thingsDictionary.Add(" Yellow Things", 34);
            thingsDictionary.Add(" Red Things", 52);
            thingsDictionary.Add(" Brown Things", 27);
            
            foreach (KeyValuePair<string, int> keyValuePair in thingsDictionary)
            {
                Console.WriteLine(keyValuePair.Key, keyValuePair.Value);
            }


            int a = 5;
            int[] b = new int[]{ 1, 2, 3, 6, 7 };

            Console.WriteLine(MathEx.Max(a, b));

            Console.WriteLine(MathEx.Max(4,5));
            
            Console.ReadKey();

            var geTest = new GeTest();
            int? count = geTest?.Count ?? 0;
        }
    }
}

