using System;
using ClassLibrary1;

namespace ClassTest
{

    public abstract class MyBase
    {
        public virtual void DoSomething() 
            => Console.WriteLine("MyBase.DoSomething()");

        public virtual void DoSomething_2()
        {
            Console.WriteLine("MyBase.DoSomething_2()");
        }
    }

    internal class MyClass : MyBase
    {
        public new void DoSomething() 
            => Console.WriteLine("MyClass.DoSomething()");

        public override void DoSomething_2()
        {
            base.DoSomething_2();
        }
    }
    public interface IMyBaseInterface { }
    internal interface IMyBaseInterface2 { }
    internal interface IMyInterface : IMyBaseInterface, IMyBaseInterface2 { }
    internal sealed class MyComplexClass : MyClass, IMyInterface { }
    
    public class MyBaseClass
    {
        public MyBaseClass()
        {
            // default constructor
            Console.WriteLine("MyBaseClass()");
        }

        public MyBaseClass(int i)
        {
            Console.WriteLine("MyBaseClass(int i)");
        }
    }

    public class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass()
        {
            Console.WriteLine("MyDerivedClass()");
        }

//        public MyDerivedClass() : base(5)
//        {
//
//        }

        public MyDerivedClass(int i)
        {
            // MyDerivedClass myObj = new MyDerivedClass();
            // System, MyBaseClass(int i), MyDerivedClass()
            Console.WriteLine($"MyDerivedClass(int i), i = {i}");
        }

//        public MyDerivedClass(int i, int j)
//        {
//            // 调用 MyBaseClass()
//        }

//        public MyDerivedClass(int i, int j) : base(i)
//        {
//            // 调用 MyBaseClass(int i)
//        }

        public MyDerivedClass(int i, int j) : this(5)
        {
            // this关键字用于调用自身的构造函数
            Console.WriteLine($"MyDerivedClass(int i, int j) : this(5), i = {i}, j = {j}");
        }
    }

    class Program
    {

        private string _myString;

        // ReSharper disable once ConvertToAutoProperty
        public string MyString
        {
            get => _myString;
            set => _myString = value;
        }

        static void Main(string[] args)
        {
            //            MyComplexClass myObj = new MyComplexClass();
            //            Console.WriteLine(myObj.ToString());
            //
            //            Console.ReadKey();

            MyDerivedClass myObj = new MyDerivedClass(3, 4);
            MyExtenalClass myExtenal = new MyExtenalClass(); 
            MyExtenalClass myExtenal2 = new MyExtenalClass(15); // 15

            int constInt = MyExtenalClass.ConstInt;
            int readonlyInt = myExtenal.ReadonlyInt;


            Console.WriteLine(constInt);// 12
            Console.WriteLine(readonlyInt);// 13
            Console.WriteLine(myExtenal2.ReadonlyInt); // 15
            
            //Console.WriteLine(mexCla.ToString());

            Console.WriteLine("-------------------");

            MyBase myBase;
            MyClass myClass = new MyClass();

            myBase = myClass;

            // 调用的是 派生类的DoSomething()方法
            // 重写方法将替换基类中的实现方法
            myBase.DoSomething();
            myBase.DoSomething_2();

            PartialClassTest1.PartialClassTestPart1();
            PartialClassTest1.PartialClassTestPart2();


            Console.ReadKey();
        }
    }
}
