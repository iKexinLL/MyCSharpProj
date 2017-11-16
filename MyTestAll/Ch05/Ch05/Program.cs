using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05
{
    // 类似一个类.没有访问标识
    enum Orientation : byte // -> 指定类型
    {
        north = 1, // 如果不给定值,则默认为0,然后依次加一
        south = 2, // 允许多个枚举成员有相同的值。没有显示赋值的枚举成员的值，总是前一个枚举成员的值+1
        east, // 其实是3
        west = 4
    }

    enum Days { Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
    enum BoilingPoints { Celsius = 100, Fahrenheit = 212 };

    [FlagsAttribute] // https://docs.microsoft.com/zh-cn/dotnet/api/System.FlagsAttribute?view=netframework-4.7
    enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };

    //定义一个结构,注意结构里面的变量是有可访问性的.
    struct Route
    {

        public Orientation direction;
        public double distance;
    }

    class Program
    {
        // 不可以在方法里面定义
        // 这个是在方法外
        enum BoilingPoints { Celsius = 100, Fahrenheit = 212 };

        static void Main(string[] args)
        {
            //顺带测试一下 args
            Console.WriteLine($"{args.Length} command line arguments were specified");
            foreach (var s in args)
                Console.WriteLine(s);
            Console.WriteLine("args end");
            Console.WriteLine();

            byte b;
            short st = 233;
            b = checked((byte)st); // check 检查溢出, 大于255会报错
            Console.WriteLine(b);

            byte directionByte;
            string directionString;

            Orientation myDirection = Orientation.north;
            Console.WriteLine(myDirection);

            directionByte = (byte)myDirection;
            Console.WriteLine($"byte equivalent = {directionByte}");
            // 无法使用(string)转换
            // 等于 .ToString()
            directionString = Convert.ToString(myDirection);
            Console.WriteLine($"string equivalent = {directionString}");

            string myString = "north";
            //把string转化为枚举值
            //(enumerationType)Enum.Parse(typeof(enumerationType), enumerationValueString);
            Orientation myDirection2 = (Orientation)Enum.Parse(typeof(Orientation), myString);
            Console.WriteLine($"string to enumeration, string is {myString}, enumeration is {myDirection2}");

            Type typeOrientation = typeof(Orientation);
            Console.WriteLine("start foreach Orientation, type is d");

            foreach (string s in Enum.GetNames(typeOrientation))
                Console.WriteLine(Enum.Format(typeOrientation, Enum.Parse(typeOrientation, s), "d"));

            Console.WriteLine("start foreach Orientation, type is f");
            foreach (string s in Enum.GetNames(typeOrientation))
                Console.WriteLine(Enum.Format(typeOrientation, Enum.Parse(typeOrientation, s), "f"));

            // 强转方式
            Console.WriteLine("强转方式");
            byte tst = (byte)Enum.Parse(typeof(Orientation), myString);
            Console.WriteLine(tst);

            //以下为测试
            myDirection = (Orientation)st;
            Console.WriteLine(myDirection); // --> 直接显示233
            st = 3;
            myDirection = (Orientation)st;
            Console.WriteLine(myDirection); // --> 显示为east

            string codeHttp = "https://docs.microsoft.com/zh-cn/dotnet/api/System.Enum?view=netframework-4.7";
            Console.WriteLine("以下为 {0} 上的代码", codeHttp);

            Type weekdays = typeof(Days);
            Type boiling = typeof(BoilingPoints);

            Console.WriteLine("The days of the week, and their corresponding values in the Days Enum are:");

            foreach (string s in Enum.GetNames(weekdays))
                // Enum.Format说明: https://msdn.microsoft.com/zh-cn/library/system.enum.format(v=vs.110) --> 注意这个")",点击时要手动加上,否则访问不到
                // 这篇文章也不错 http://www.cnblogs.com/claspcn/p/5218520.html
                // 文章表现出可以当做"开关"控制
                // enum（C# 参考） https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/enum
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(weekdays, Enum.Parse(weekdays, s), "d"));

            Console.WriteLine();
            Console.WriteLine("Enums can also be created which have values that represent some meaningful amount.");
            Console.WriteLine("The BoilingPoints Enum defines the following items, and corresponding values:");

            foreach (string s in Enum.GetNames(boiling))
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(boiling, Enum.Parse(boiling, s), "d"));

            Colors myColors = Colors.Red | Colors.Blue | Colors.Yellow;
            Console.WriteLine();
            Console.WriteLine("myColors holds a combination of colors. Namely: {0}", myColors);

            Console.WriteLine("继续<入门经典>");
            Route myRoute;
            int newDirection = -1;
            double myDistance;
            Console.WriteLine("1) North\n2) South\n3) East\n4) West");

            do
            {
                Console.WriteLine("Select a direction");
                newDirection = Convert.ToInt32(Console.ReadLine());
            }
            while ((newDirection < 1) || (newDirection > 4));

            Console.WriteLine("Input a distance");
            myDistance = Convert.ToDouble(Console.ReadLine());

            myRoute.direction = (Orientation)newDirection;
            myRoute.distance = myDistance;

            Console.WriteLine($"myRoute specifies a direction of {myRoute.direction} " +
                $"and a distinct of {myRoute.distance}");

            string dire = Enum.GetName(typeOrientation, newDirection);
            myRoute.distance = myDistance;
            Console.WriteLine($"myRoute specifies a direction of {dire} " +
                $"and a distinct of {myRoute.distance}");

            Console.ReadKey();
        }
    }
}
