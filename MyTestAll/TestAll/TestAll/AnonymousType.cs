using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    static class AnonymousType
    {
        public static void TestAll()
        {
            var parent1 =
                new
                {
                    Title = "Test",
                    YearOfPublication = 1987
                };

            // parent1.Title = "asd"; // 无法赋值,匿名类型是只读的

            // 编译器在生成匿名类型的代码时，重写了ToString()方法
            Console.WriteLine(parent1);

            var sevenWorldBlunders = new List<string>()
            {
                // Quotes from Ghandi 
                "Wealth without work",
                "Pleasure without conscience",
                "Knowledge without character",
                "Commerce without morality",
                "Science without humanity",
                "Worship without sacrifice",
                "Politics without principle"
            };
            
            Pair(sevenWorldBlunders);
            Console.WriteLine("-------------------");
            Cw(sevenWorldBlunders);
            Console.WriteLine("-------------------");

            // 初始化器,需要实现ICollection<T>中的方法
            // 或者自己创建一个Add方法
            DataStore<string> dst = new DataStore<string>()
            {
                "A",
                "B",
                "C"
            };
            
            Pair(dst);

            DataStoreString<string> dss = new DataStoreString<string>()
            {
                "A"
            };

        }

        private static void Pair<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void Cw(List<string> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    class DataStore<T> : IEnumerable<T>
    {
        private List<T> _listList = new List<T>();
       
        public List<T> ListList => _listList;

        public IEnumerator<T> GetEnumerator()
            => _listList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _listList.GetEnumerator();


        public void Add(T item)
        {
            _listList.Add(item);
        }
    }

    class DataStoreString<T> : IEnumerable<T>
    {
        private List<T> _listList = new List<T>();

        public List<T> ListList => _listList;

        public IEnumerator<T> GetEnumerator()
            => _listList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _listList.GetEnumerator();

        public void Add(T item)
        {
            
        }
    }
}