using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    static class IEnumerableTest
    {
        public static void TestAll()
        {
            IEnumerable<Patent> patents = PatentData.Patents;

            // 输出新的IEnumerable<Patent>
            // 从概念上说，应该认为Where()方法只是描述了集合中应该出现什么，
            // 而没有描述具体应该如何遍历数据项并生成一个可能包含更少数据项的新集合。
            // 只有在需要遍历集合中的项时，才会真正对表达式进行求值。
            var patentsIn1800 = patents.Where(
                patent =>
                {
                    Console.WriteLine("调用了一次Lambda patentsIn1800");
                    return patent.YearOfPublication.StartsWith("18");
                });

            var patentsIn1800Two = patents.Where(
                patent =>
                {
                    Console.WriteLine("调用了一次Lambda patentsIn1800Two");
                    return patent.YearOfPublication.StartsWith("18");
                });
            
            // Select 投射到匿名类型 

            Console.WriteLine("---Select---");
            var patentsIn1800List = patentsIn1800 as IList<Patent> ?? patentsIn1800.ToList();
            
            var patentsIn1800ListSelect = patentsIn1800List.Select(
                patent => patent.ToString());

            Print(patentsIn1800ListSelect);
            Console.WriteLine("---Select---");

            IEnumerable<Inventor> inventors = PatentData.Inventors;
            Print(inventors);

            string rootDirectory = @"e:\code\mycsharpproj\mytestall\testall\testall";
            // string searchPattern = "*.cs";

            // IEnumerable<string> fileLists = Directory.GetFiles(rootDirectory, searchPattern);

            IEnumerable<string> fileLists = Directory.GetFiles(rootDirectory);
            Print(fileLists);

            // 使用select进行投射
            var itemFiles = fileLists.Select(
                file =>
                {
                    FileInfo fileInfo = new FileInfo(file);
                    return new
                    {
                        FileName = fileInfo.Name,
                        Size = fileInfo.Length
                    };
                });
            
            Print(itemFiles);

            // 使用AsParallel()进行并行查询
            // 之后在了解
            var itemFilesParallel = fileLists.AsParallel().Select(
                file =>
                {
                    FileInfo fileInfo = new FileInfo(file);
                    return new
                    {
                        FileName = fileInfo.Name,
                        Size = fileInfo.Length
                    };
                });

            Console.WriteLine($"patents count is {patents.Count()}");

            // 如果使用patentsIn1800Two.Count()以及patentsIn1800Two.Any()
            // 则会有一个警告
            // Possible multiple enumeration of IEnumerable
            // 因为正则表达式在调用的时候才会运行,且没次调用都会运行
            // 这就导致了每次调用patentsIn1800Two的Linq方法时,
            // 都会重新生成一遍patentsIn1800Two
            // 所以使用
            // var enumerable = patentsIn1800 as IList<Patent> ?? patentsIn1800.ToList();
            // 来固定结果,只调用一次Lambda方法

            foreach (var patent in patentsIn1800Two)
            {
                Console.WriteLine(patent);
            }
            
            Console.WriteLine($"patents count in 1800s is " +
                              $"{patentsIn1800Two.Count(patent => patent.YearOfPublication.StartsWith("18"))}");
            
            // 判断是否有值使用 Any
            Console.WriteLine(patentsIn1800Two.Any(patent => patent.YearOfPublication.StartsWith("18")));

            // 使用OrderBy以及ThenBy
            Console.WriteLine("----OrderBy&ThenBy------");
            IEnumerable<Patent> itemOrderBy = patents.OrderBy(
                patent => patent.YearOfPublication).ThenBy(
                patent => patent.Title);

            Print(itemOrderBy);

            Console.WriteLine("--------OrderByDescending-----");
            
            IEnumerable<Patent> itemOrderByDescending = patents.OrderByDescending(
                patent => patent.YearOfPublication).ThenByDescending(
                patent => patent.Title);

            Print(itemOrderByDescending);


        }

        private static void Print<T>(IEnumerable<T> items)
        {
            StringBuilder sb = new StringBuilder("------------------");
            Console.WriteLine(sb.ToString());
            
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class Patent
    {
        public string Title { get; set; }

        public string YearOfPublication { get; set; }

        public string ApplicationNumber { get; set; }

        public long[] InventorIds { get; set; }

        public override string ToString()
        {
            return $"{Title} ({YearOfPublication})";
        }
    }

    class Inventor
    {
        public long Id { private get; set; }
        public string Name { private get; set; }
        public string City { private get; set; }
        public string State { private get; set; }
        public string Country { private get; set; }

        public override string ToString()
        {
            return $"{Name}({Country}, {City}, {State}, {Id})";
        }
    }

    static class PatentData
    {
        public static readonly Inventor[] Inventors = new Inventor[]
        {
            new Inventor()
            {
                Name = "Benjamin Franklin",
                City = "Philadelphia",
                State = "PA",
                Country = "USA",
                Id = 1
            },
            new Inventor() {Name = "Orville Wright", City = "Kitty Hawk", State = "NC", Country = "USA", Id = 2},
            new Inventor() {Name = "Wilbur Wright", City = "Kitty Hawk", State = "NC", Country = "USA", Id = 3},
            new Inventor() {Name = "Samuel Morse", City = "New York", State = "NY", Country = "USA", Id = 4},
            new Inventor()
            {
                Name = "George Stephenson",
                City = "Wylam",
                State = "Northumberland",
                Country = "UK",
                Id = 5
            },
            new Inventor() {Name = "John Michaelis", City = "Chicago", State = "IL", Country = "USA", Id = 6},
            new Inventor() {Name = "Mary Phelps Jacob", City = "New York", State = "NY", Country = "USA", Id = 7},
        };

        public static readonly Patent[] Patents = new Patent[]
        {
            new Patent() {Title = "Bifocals", YearOfPublication = "1784", InventorIds = new long[] {1}},
            new Patent() {Title = "Phonograph", YearOfPublication = "1877", InventorIds = new long[] {1}},
            new Patent() {Title = "Kinetoscope", YearOfPublication = "1888", InventorIds = new long[] {1}},
            new Patent() {Title = "Electrical Telegraph", YearOfPublication = "1837", InventorIds = new long[] {4}},
            new Patent() {Title = "Flying machine", YearOfPublication = "1903", InventorIds = new long[] {2, 3}},
            new Patent() {Title = "Steam Locomotive", YearOfPublication = "1815", InventorIds = new long[] {5}},
            new Patent()
            {
                Title = "Droplet deposition apparatus",
                YearOfPublication = "1989",
                InventorIds = new long[] {6}
            },
            new Patent() {Title = "Backless Brassiere", YearOfPublication = "1914", InventorIds = new long[] {7}},
        };
    }
}