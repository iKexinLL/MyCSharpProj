using System;
using System.Timers;

namespace EventTest
{
    // Connection一个有事件的类
    // 而Display是一个订阅了Connection中的事件的类
    // 通过委托MessageHandler将这两个类联系起来

    // 定义了一个委托,传入的是string参数
    public delegate void MessageHandler(string messageText);

    public class Connection
    {
        // 创定义一个MessageHandler委托
        // 所以可以在下方传递一个"Hello kexin"的字符串
        // 并将"Hello kexin"赋给messageText
        // 然后委托给myDisplay.DisplayMessage
        public event MessageHandler MessageArrived;

        private readonly Timer _pollTimer;

        public Connection()
        {
            // 创建一个事件之间经过的时间为1000的timer
            _pollTimer = new Timer(100);
            // 添加一个事件
            _pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
        }

        public void Connect() => _pollTimer.Start();
        public void Disconnect() => _pollTimer.Stop();

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static Random _random = new Random();

        private void CheckForMessage(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Checking for new messages");
            // ReSharper disable once UseNullPropagation
            // 什么时候MessageArrived != null
            if ((_random.Next(9) == 0) && (MessageArrived != null))
            {
                MessageArrived("Hello kexin");
            }
        }
    }

    public class Display
    {
        public void DisplayMessage(string message)
            => Console.WriteLine($"Message arrived {message}");
    }

    class Program
    {
        public static void TestMessage(string message)
            => Console.WriteLine($"TestMessage {message}");
        
        private static void Main(string[] args)
        {
            // 这两个类通过事件,委托连接了起来
            Connection myConnection = new Connection();
            Display myDisplay = new Display();

            // MessageArrived为一个事件,由委托MessageHandler指定了参数为string.
            // 然后将
            myConnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
            // myConnection.MessageArrived("TestMessage");
            // myConnection.MessageArrived += new MessageHandler(TestMessage);
            
            myConnection.Connect();

            Console.ReadKey();
        }
    }
}