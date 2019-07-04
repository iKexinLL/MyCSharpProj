using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class MySomeTest
    {
        public static void TestAllOne()
        {
            List<string> list = new List<string>();

            IList<string> ilist = new List<string>();

            list.Sort();

            Console.WriteLine(list);
        }

        private delegate void BuyBook();

        public static void TestAllTwo()
        {
            BuyBook buyBook = new BuyBook(BookShop);
            buyBook();

            Action<string> bookActions = new Action<string>(BookShop);
            bookActions("程序");

            Action<string, string> bookActionsTwo = new Action<string, string>(BookShop);
            bookActionsTwo("程序", "长春");

            Func<string, string> func = new Func<string, string>(FuncBook);
            Console.WriteLine(func("程序"));


            // string FuncValue(string s) => $"{s} got";
            Func<string, string> funcValue = s => $"{s} got";
            Console.WriteLine(funcValue("程序"));
        }

        private static string FuncBook(string arg)
        {
            return arg;
        }

        private static void BookShop()
        {
            Console.WriteLine("provide books");
        }

        private static void BookShop(string bookName)
        {
            Console.WriteLine($"provide {bookName}");
        }

        private static void BookShop(string bookName, string shopName)
        {
            Console.WriteLine($"provide {bookName} in {shopName}");
        }
    }
}