using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class Curry
    {
        public Curry()
        {
            Console.WriteLine("无参构造函数");
        }

        public Curry(string stringFirst, string stringSecond, string stringThird)
        {
            StringFirst = stringFirst;
            StringSecond = stringSecond;
            StringThird = stringThird;

            Console.WriteLine("有参构造函数");
        }

        public string StringThird { get; set; }

        public string StringSecond { get; set; }

        public string StringFirst { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 初始化器不会调用有参的构造函数
            Curry testCurry1 = new Curry
            {
                StringFirst = "A",
                StringSecond = "B",
                StringThird = "C"
            };

            Curry testCurry2 = new Curry("A", "B", "C");

            // 调用有参构造函数
            List<Curry> curriesOne = new List<Curry>();
            curriesOne.Add(new Curry("A", "B", "C"));
            curriesOne.Add(new Curry("A", "B", "C"));
            curriesOne.Add(new Curry("A", "B", "C"));

            // 调用无参构造函数
            List<Curry> curriesTwo = new List<Curry>
            {
                new Curry
                {
                    StringFirst = "A",
                    StringSecond = "B",
                    StringThird = "C"
                },
                new Curry
                {
                    StringFirst = "A",
                    StringSecond = "B",
                    StringThird = "C"
                },
                new Curry
                {
                    StringFirst = "A",
                    StringSecond = "B",
                    StringThird = "C"
                }
            };

            string b = "3";
            b.ToInt();

            VectorPos sv = new VectorPos(1, 2, 3);

            sv.SetVectorX(4);

            Console.WriteLine(sv.Position);


//            switch (Console.ReadLine())
//            {
//                case "a":
//                case "b":
//                    Console.WriteLine("a or b");
//                    break;
//            }

            string first = "a";
            string second = "b";

            Swap(ref first, ref second);

            Console.WriteLine($"{first}, {second}");

            Console.WriteLine("------------------------");

            int[] testArr = new int[5] {5, 14, 13, 2, 1};

//            SimpleSort.BubbleSort(testArr);

            foreach (int i in testArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("------------------------");

//            BubbleSort2.BubbleSort(testArr, BubbleSort2.SortType.Descending);

            foreach (int i in testArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------------------------");

            // DelegateSample.BubbleSort(testArr, DelegateSample.GreaterThan);

            foreach (int i in testArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------------------------");

            // DelegateSample.BubbleSort(testArr, DelegateSample.LessThan);

            foreach (int i in testArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------------------------");

            // DelegateSample.BubbleSort(testArr, DelegateSample.AlphaGreaterThan);
            
            DelegateSample.BubbleSort(testArr, (first1, second1) => first1 < second1);

            foreach (int i in testArr)
            {
                Console.WriteLine(i);
            }

            Func<string> getUserInput =
                () =>
            {
                string input;
                do
                {
                    input = Console.ReadLine();
                } while (input != null && input.Trim().Length == 0);
                return input;
            };

            // getUserInput();

            XieBianNiBian.Test();
            Console.WriteLine(XieBianNiBian.Func1Func("asd"));
            ;
            FuncDemo.FuncDemoTest();

            Console.WriteLine("========ExpressionTree==========");

            List<ExpressionTree.Person> persons = new List<ExpressionTree.Person>
            {
                new ExpressionTree.Person("Xu"),
                new ExpressionTree.Person("Zhang"),
                new ExpressionTree.Person("Lee"),
                new ExpressionTree.Person("Xu")
            };

            foreach (var person in persons.Where(person => person.Name.ToUpper() == "XU"))
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("========HeaterCooler==========");
            HeaterCooler.NowTemp = 50;
            HeaterCooler.StandardTemp = 140;
            HeaterCooler.JudgeTemp(HeaterCooler.HeaterThan);

            Console.WriteLine("============HeaterCoolerOther=========");
            HeaterCoolerOther hco = new HeaterCoolerOther();
            
            Heater heater = new Heater(60);
            Cooler cooler = new Cooler(80);

            hco.OnTemperatureChange += heater.OnTemperatureChanged;
            hco.OnTemperatureChange += cooler.OnTemperatureChanged;

            // hco.CurrentTemperature = 70;
            // 从事件包容者的外部触发事件
            // 这个导致CurrentTemperature为0
            hco.OnTemperatureChange(100);
            
            Console.WriteLine(hco.CurrentTemperature);

            Console.WriteLine("===========HeaterCoolerThree==========");
            HeaterCoolerThree hct = new HeaterCoolerThree();

            hct.OnTemperatureChange += heater.OnTemperatureChanged;
            hct.OnTemperatureChange += cooler.OnTemperatureChanged;

            // 使用事件则无需担心外部触发事件
            hct.CurrentTemperature = 170;

            // throw new MyException();


            Console.WriteLine("=========RuntimeBinder============");
            RunTimeBinderTest.TestAll();

            Console.WriteLine("=========WordProcesssor===========");
            WordProcesssor.TestAll();

            Console.WriteLine("=========TimerTest================");
            // TimerTest.TestAll();

            Console.WriteLine("=========SimpleLambda=============");
            SimpleLambda.TestAll();

            Console.WriteLine("=========AnonymousType============");
            AnonymousType.TestAll();

            Console.WriteLine("=========AttributeTest============");
            AttributeTest.TestAll();

            Console.WriteLine("=========AttributeFlags===========");
            MyTest();

            Console.WriteLine("=========IEnumeratorAndIEnumerable");
            IEnumeratorAndIEnumerable.TestAll();

            Console.WriteLine("=========IEnumeratorAndIEnumerableTwo");
            IEnumeratorAndIEnumerableTwo.TestAll();

            Console.WriteLine("=========IEnumeratorAndIEnumerableTwoT");
            IEnumeratorAndIEnumerableTwoT.TestAll();

            Console.WriteLine("=========IEnumerableSelect=========");
            IEnumerableSelect.TestAll();

            Console.WriteLine("=========DerivedTest===============");
            DerivedTest.TestAll();

            Console.WriteLine("=========IterfaceTest==============");
            IterfaceTest.TestAll();

            Console.WriteLine("=========other=====================");
            string s = @"aqwe b\c /d";
            char[] c = new char[4]{' ', '\\', '/', ' '};
            // char d = ' ';
            var ab = s.Split(c);
            foreach (var ww in ab)
            {
                Console.WriteLine(ww);
            }
            
            
            Console.WriteLine();
            
            Console.WriteLine("=========CollectionWhere==========");
            IEnumerableTest.TestAll();

            Console.WriteLine("=========IEnumerableTestTwo=======");
            IEnumerableTestTwo.TestAll();


            Console.ReadKey();
        }

        private static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        [Flags]
        private enum Permission
        {
            Create = 1,
            Read = 2,
            Update = 4,
            Delete = 8,
        }
        
        private static void MyTest()
        {
            Permission permission = Permission.Create | Permission.Read | Permission.Update | Permission.Delete;
            Console.WriteLine("1、枚举创建，并赋值……");
            Console.WriteLine(permission.ToString());
            Console.WriteLine((int)permission);
        }
    }
}

// 0001 => 1
// 0010 => 2
// ------
// 0011 => 3
// 0100 => 4
// ------
// 0111 => 7
//