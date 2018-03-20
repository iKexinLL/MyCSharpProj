using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    // 注意 声明和实例的区别
    // 如：飞禽 bird = new 麻雀();
    // 那么飞禽就是申明类，麻雀是实例类。
namespace TestAll
{
    // 无法使用base调用static方法
    // 使用new可以隐藏基类的普通实例方法
    // 如果基类方法没有virtual,abstract或者override则无法使用override
    // virtual用在非抽象类
    // abstract用在抽象类
    
    abstract class MyAbstractClass
    {
        public abstract void MyAbstractClassMethod();

        public abstract void NotAbstractMethod();
    }

    class MyBaseClass
    {
        public static void BaseClassStaticMethod() { }
        
        public virtual void BaseClassMethod() { }
    }
    
    class DerivedTest : MyBaseClass
    {
        public new static void BaseClassStaticMethod() { }

        public override void BaseClassMethod()
        {
            base.BaseClassMethod();
        }

        public static void TestAll()
        {
            A a;         // 定义一个a这个A类的对象.这个A就是a的申明类
            A b;         // 定义一个b这个A类的对象.这个A就是b的申明类
            A c;         // 定义一个c这个A类的对象.这个A就是c的申明类
            A d;         // 定义一个d这个A类的对象.这个A就是d的申明类

            a = new A(); // 实例化a对象,A是a的实例类
            b = new B(); // 实例化b对象,B是b的实例类
            c = new C(); // 实例化c对象,C是c的实例类
            d = new D(); // 实例化d对象,D是d的实例类

            // 执行a.Func：
            // 1.先检查申明类A 
            // 2.检查到是虚拟方法 
            // 3.转去检查实例类A，就为本身 
            // 4.执行实例类A中的方法 
            // 5.输出结果 Func In A
            a.Func();

            // 执行b.Func：
            // 1.先检查申明类A 
            // 2.检查到是虚拟方法 
            // 3.转去检查实例类B，有重载的 
            // 4.执行实例类B中的方法 
            // 5.输出结果 Func In B
            b.Func();
            
            // 执行c.Func：
            // 1.先检查申明类A 
            // 2.检查到是虚拟方法 
            // 3.转去检查实例类C，无重载的 
            // 4.转去检查类C的父类B，有重载的 
            // 5.执行父类B中的Func方法 
            // 6.输出结果 Func In B
            c.Func();

            // 执行d.Func：
            // 1.先检查申明类A 
            // 2.检查到是虚拟方法 
            // 3.转去检查实例类D，无重载的（这个地方要注意了，虽然D里有实现Func()，但没有使用override关键字，所以不会被认为是重载） 
            // 4.转去检查类D的父类A，就为本身 
            // 5.执行父类A中的Func方法 
            // 6.输出结果 Func In A
            d.Func();
            
            D d1 = new D();
            // 执行D类里的Func()，输出结果 Func In D
            d1.Func(); 
            
            /*
                Func in A
                Func in B
                Func in B
                Func in A
                Func in D
            */
        }
    }

    class A
    {
        // 注意virtual
        public virtual void Func()
        {
            Console.WriteLine("Func in A");
        }
    }

    class B : A
    {
        // 注意,继承于A,使用override
        public override void Func()
        {
            Console.WriteLine("Func in B");
        }
    }
    
    // 继承于B,未实现方法
    class C : B
    { }

    // 继承于A,使用了new
    class D : A
    {
        public new void Func()
        {
            Console.WriteLine("Func in D");
        }
    }
    
    
}
