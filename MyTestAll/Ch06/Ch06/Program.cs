using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06
{
    class Program
    {

//        委托测试,模拟Console.ReadLine
        delegate string ProcessReadline();

//        必须使用static或者const来修饰全局变量
        private static string myString;

        struct CustomerName
        {
            private string firstName;
            private string lastName;

            public string FirstName { get => firstName; set => firstName = value; }
            public string LastName { get => lastName; set => lastName = value; }

            public string Name()
                => firstName + " " + lastName;
        }

        static void Write()
        {
            Console.WriteLine("Console.Write");
        }

        static int SumVals(params int[] vals)
        {
            int sum = 0;
            foreach( var i in vals)
            {
                sum += i;
            }

            return sum;
        }

        // lambda箭头 => 
        static double Multiply(double val1, double val2)
            => val1 * val2;

        // ref & out
        static int TestAssignmentOut(int val1, out int val2)
        {
            val2 = val1;
            return val2;
        }

        static int TestAssignmentRef(int val1, ref int val2)
        {
            val2 = val1;
            return val2;
        }

        static void Main(string[] args)
        {
            Write();
            Console.WriteLine(Multiply(3,4));

            int sum = SumVals(1, 5, 2, 9, 8);
            Console.WriteLine($"SumVals is {sum}");

            Console.WriteLine("TestAssignmentOut");
            Console.WriteLine($"TestAssignmentOut(3, out int val); is " +
                $"{TestAssignmentOut(3, out int val2)}");

            Console.WriteLine("TestAssignmentRef");
            int valRef = 0; // --> ref 需要初始化
            Console.WriteLine($"TestAssignmentRef(3, ref valRef)(3, out int val) is " +
                $"{TestAssignmentRef(3, ref valRef)}");

//            Program.myString 为全局变量
            Program.myString = "Program.myString";

            string myString = "String in main()";

            Console.WriteLine(Program.myString);
            Console.WriteLine(myString);

            Console.WriteLine("------------------");

            string text = "";
            for (int i = 0; i < 10; i++)
            {
//                test不断被赋值,开辟新的内存
                text = "Line " ;
                text += Convert.ToString(i);
                Console.WriteLine(text);
            }
//            循环结束,最后开辟的内存未被回收
//            由于这一步,所以text必须要初始化
            Console.WriteLine($"Last loop is {text}");

            Console.WriteLine("CustomerName");

            CustomerName cn = new CustomerName();
            cn.FirstName = "Xu";
            cn.LastName = "Kexin";
            Console.WriteLine(cn.Name());

            Console.WriteLine("input something");
            ProcessReadline readline = new ProcessReadline(Console.ReadLine);
            string userInput = readline();
            Console.WriteLine($"user input is {userInput}");


            Console.ReadKey();
        }
    }
}
