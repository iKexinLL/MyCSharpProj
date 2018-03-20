using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestAll
{
    static class IEnumerableSelect
    {
        public static void TestAll()
        {
            string[] fruits =
            {
                "apple", "banana", "mango", "orange",
                "passionfruit", "grape"
            };

            // index会自己增长吗? 为什么?
            // 看了源码之后,是自己增长
            // 为什么Func<TSource, int, TResult> selector要传递一个int?

            var query =
                fruits.Select((fruit, index) =>
                    new {index, str = fruit.Substring(0, index)});

            Print(query, "query");

            // 这个应该调用的其他重载
            var queryTwo =
                fruits.Select(SelectTest);

            Print(queryTwo, "queryTwo");

            var queryThree =
                fruits.SelectEx((fruit =>
                    new {str = fruit}));

            Print(queryThree, "queryThree");

            // 这个index传递给了Func<TSource, int, TResult> selector
            // 所以类型才是int?
            var queryFour = 
                fruits.SelectExTwo((fruit, index) =>
                    new {index, str = fruit.Substring(0, index)});

            // Console.WriteLine(queryFour.GetType());
            Print(queryFour, "queryFour");

            var queryFive =
                fruits.SelectExThree((fruit, index) =>
                    new {index, str = fruit + " haha"});

            Print(queryFive, "queryFive");            
        }

        private static void Print<T>(IEnumerable<T> obj, string name)
        {
            Console.WriteLine($"--------{name}----------");

            foreach (var o in obj)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine($"--------{name} end----");
        }

        private static int _index = -1;

        private static object SelectTest(string fruit)
        {
            _index++;
            return new {index = _index, str = fruit.Substring(0, _index)};
        }
    }

    public static class SelectExClass
    {
        public static IEnumerable<TResult> SelectEx<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return SelectIterator<TSource, TResult>(source, selector);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>
            (IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            // int index = -1;
            foreach (TSource source1 in source)
            {
                // selector无法添加其他值
                yield return selector(source1);
            }
        }

        public static IEnumerable<TResult> SelectExTwo<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
//            // typeof(TSource) is System.String
//            Console.WriteLine($"typeof(TSource) is {typeof(TSource)}");
//
//            // <>f__AnonymousType1`2[System.Int32,System.String]
//            Console.WriteLine($"typeof(TResult) is {typeof(TResult)}");
            
            return SelectIterator<TSource, TResult>(source, selector);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>
            (IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            // typeof(TSource) is System.String
            Console.WriteLine($"typeof(TSource) is {typeof(TSource)}");

            // 由于方法返回的是匿名类型
            // new {index, str = fruit.Substring(0, index)}
            // 所以下面才为 System.Int32,System.String
            // 对应 index和str的位置
            // <>f__AnonymousType1`2[System.Int32,System.String]
            Console.WriteLine($"typeof(TResult) is {typeof(TResult)}" );

            int index = -1;
            foreach (TSource source1 in source)
            {
                checked
                {
                    ++index;
                }

                yield return selector(source1, index);
            }
        }
        
        public static IEnumerable<TResult> SelectExThree<TSource, TResult>
            (this IEnumerable<TSource> source, Func<string, int, TResult> selector)
        {
            //            // typeof(TSource) is System.String
            //            Console.WriteLine($"typeof(TSource) is {typeof(TSource)}");
            //
            //            // <>f__AnonymousType1`2[System.Int32,System.String]
            //            Console.WriteLine($"typeof(TResult) is {typeof(TResult)}");

            return SelectIterator<TSource, TResult>(source, selector);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>
            (IEnumerable<TSource> source, Func<string, int, TResult> selector)
        {
            // typeof(TSource) is System.String
            Console.WriteLine($"typeof(TSource) is {typeof(TSource)}");

            Console.WriteLine($"typeof(TResult) is {typeof(TResult)}");
            string s = "this is Func<string, int, TResult> selector";
            int index = 2;

            yield return selector(s, index);
        }

        class GenericList<T>
        {
            // CS0693
            void SampleMethod<T>()
            {
            }
        }

        class GenericList2<T>
        {
            //No warning
            void SampleMethod<U>()
            {
            }
        }
    }
}