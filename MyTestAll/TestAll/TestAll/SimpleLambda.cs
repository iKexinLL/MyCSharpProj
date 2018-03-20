using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    delegate int CalculateMethod(int paramA, int paramB);
    
    class SimpleLambda
    {
        private static void Calculate(CalculateMethod delegateMethond, string methodInfo = null)
        {
            if (!string.IsNullOrWhiteSpace(methodInfo))
                Console.WriteLine(methodInfo);
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($"f({i},{j}) = {delegateMethond(i, j)};");
                    if (j == 5)
                        Console.WriteLine();
                    else
                        Console.Write(" ");
                }
            }
        }

        public static void TestAll()
        {
            // ((a, b) => a + b) 等于 Func<int, int, int>
            Calculate(((a, b) => a + b), "((a, b) => a + b");
            Calculate(((a, b) => a * b), methodInfo: "(a, b) => a * b)");
            
            int[] myInts = new int[] {1, 2, 3};
            Console.WriteLine(myInts.Aggregate((a, b) => a + b));

            string[] curries = {"pathia", "jalfrezi", "korma"};
            
            Console.WriteLine(curries.Aggregate(((s, s1) => s + " " + s1)));

            Console.WriteLine(curries.Aggregate<string, int>(0, ((i, s) => i + s.Length)));
            
            // 未懂....最后的表达式什么意思
            // 哦...最后的表达式作为处理返回结果的Lambda表达式
            Console.WriteLine(curries.Aggregate<string, string, string>
                ("Some curries: ",((s, s1) => s + " " + s1), s => s + "     abc"));

            Console.WriteLine(curries.Aggregate<string, string, int>
                ("Some Curries: ", ((s, s1) => s + s1), a => a.Length));

        }
    }
}
