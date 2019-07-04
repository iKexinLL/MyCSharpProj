using System;
using System.Timers;

namespace TestAll
{
    class TimerTest
    {
        // 确定一个字符串
        // 每次调用输出一个字母
        // 利用取余进行输出

        private static sbyte _counter = 0;
        private const string DisplayString = "This is a test display!";

        public static void TestAll()
        {
            Timer myTimer = new Timer(100);
            // myTimer.Elapsed += ShowChar;

            // Elapsed为一个事件
            // ShowChar为一个处理程序
            // += 表示将处理程序(ShowChar)与事件关联起来----即订阅它
            // 当引发Elapsed事件时,就会调用ShowChar这个处理程序.

            // 匿名方法
            // 使用delegate关键字定义内联的匿名方法
            myTimer.Elapsed += delegate(object source, ElapsedEventArgs e)
            {
                // Console.WriteLine($"Event handler called after {(source as Timer)?.Interval*100} milliseconds");
                Console.Write(" ");
            };
            
            // 简单的Lambda表达式
            myTimer.Elapsed += (object source, ElapsedEventArgs e)
                => Console.Write(" ");
            
            myTimer.Elapsed += new ElapsedEventHandler(ShowChar);
            

            myTimer.Start();

            Console.ReadKey();

        }

        private static void ShowChar(object source, ElapsedEventArgs e)
        {
            // var newInt = _counter++;
            //            Console.Write(_displayString[_counter++ % _displayString.Length]);
            //            Console.Write(_counter == _displayString.Length ? "\n" : "");

            // 注意运算符的优先级...要不会错误
            Console.Write((DisplayString[_counter++ % DisplayString.Length])
                          + (_counter % DisplayString.Length == 0 ? "\n" : ""));
            // Console.WriteLine(newInt == _displayString.Length ? "Q" : "Y");
        }
    }
}
