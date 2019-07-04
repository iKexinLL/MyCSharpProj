using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04Ex03_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("box sizes:1=small, 5=medium, 10=large");
            Console.WriteLine("请选择");
            string s = Console.ReadLine();
            //string s;
            //s = Console.ReadLine();
            int i = int.Parse(s);
            int ct = 0;
            switch (i)
            {
                case 1:
                    ct += 1;
                    break;
                case 5:
                    ct += 5;
                    goto case 1;     //重要,可以使用goto语句进行控制,输入5的话,结果为6
                case 10:
                    ct += 10;
                    goto case 1;

                case 50:
                case 100:
                case 150: // 或者使用两个case直接相连,否则,每个case后面必须终止, break, goto, return(如需返回值的话)
                default:
                    Console.WriteLine("无效的输入。请选择1,5，or 10");
                    break;
            }
            Console.WriteLine("谢谢！您的花费 = {0}", ct);
            
            while (i < 10)
            {
                Console.WriteLine($"{i++} year{(i == 1 ? "" : "s")}");
            }

            bool numOK = false;

            int var1 = 0; // 代码1
            int var2 = 0;
            //int var1; // 代码2
            //int var2;

            while (!numOK) // 
            {
                Console.WriteLine("Enter var1");
                var1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter var2");
                var2 = Convert.ToInt32(Console.ReadLine());

                if ((var1 > 10) || (var2 > 10))
                    Console.WriteLine("Only one number can be greater than 10");
                else
                    numOK = true;

                //Console.WriteLine($"you enterd {var1} and {var2}."); //或者写在这里
            }

            //如果没有初始化的话(调用代码2), 放在这里会报错
            //因为在while判断中 !numOK是无法访问的,导致这里的var1和var2没有初始化,导致报错
            //如果while条件为 1==1,则没有问题.因为下面总会访问到
            //所以尽量初始化
            Console.WriteLine($"you enterd {var1} and {var2}.");
            while (1 == 1)
            {
                var1 = Convert.ToInt32(Console.ReadLine());
                var2 = Convert.ToInt32(Console.ReadLine());
                break;
            }
            Console.WriteLine($"you enterd {var1} and {var2}.");
            Console.ReadKey();
        }
    }
}
