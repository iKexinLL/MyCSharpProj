using System;
using System.Timers;

/// <summary>
/// 先定义一个委托MessageHandler
/// 然后自定义一个这个此委托类型的事件MessageArrived
/// 这样就有了一个自定义事件以及一个委托
/// 定义CheckForMessage()方法,其中,会调用MessageArrived事件.
/// 嗯...这个程序有两个事件,所以才会造成一些误解.
/// myConnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
/// MessageArrived订阅了myDisplay.DisplayMessage处理程序
/// _pollTimer.Start();会调用_pollTimer.Elapsed中的处理程序CheckForMessage
/// CheckForMessage会调用MessageArrived事件
/// 然后MessageArrived才会调用所添加的处理程序myDisplay.DisplayMessage
/// ---------------------
/// _pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
/// 这个命令在列表中添加一个处理程序,当引发Elapsed事件时,就会调用该处理程序.
/// 可给这个列表添加任意多个处理程序,只要他们满足指定的条件.
/// 当引发事件时,会依次调用每个处理程序.
/// </summary>
namespace EventTest
{
    // Connection一个有事件的类
    // 而Display是一个订阅了Connection中的事件的类
    // 通过委托MessageHandler将这两个类联系起来

    // 定义了一个委托,传入的是string参数
    public delegate void MessageHandler(string messageText);
    // public delegate void MessageHandler(int a);

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
            // 什么时候MessageArrived == null -> 暂且手动设置一下
            if (MessageArrived == null)
            {
                System.Console.WriteLine("Event is null;");
                Environment.Exit(1);
            }

            // if ((_random.Next(9) == 0) && (MessageArrived != null))
            if (_random.Next(9) == 0)
            {
                MessageArrived("Hello kexin");
                // MessageArrived = null;
            }
        }
    }

    public class Display
    {
        public void DisplayMessage(string message)
            => Console.WriteLine($"Message arrived {message}");
    }

    public class Display2
    {
        public void DisplayTestMessage(string testMessage)
            => Console.WriteLine($"This is a Test Message {testMessage}");
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
            Display2 myDisplay2 = new Display2();

            // MessageArrived为一个事件,由委托MessageHandler指定了参数为string.
            // 
            myConnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
            myConnection.MessageArrived += new MessageHandler(myDisplay2.DisplayTestMessage);
            // myConnection.MessageArrived("TestMessage");
            // myConnection.MessageArrived += new MessageHandler(TestMessage);
            
            myConnection.Connect();

            Console.Read();
        }
    }
}
