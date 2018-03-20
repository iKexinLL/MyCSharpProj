using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ch13Ex03
{
    class Connection
    {
        public event EventHandler<MessageArrivedEventArgs> MessageArrived;
        
        public string Name { get; set; }

        private readonly Timer _pollTimer;

        public Connection()
        {
            // 创建一个事件之间经过的时间为1000的timer
            _pollTimer = new Timer(1000);
            // 添加一个事件
            _pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
        }

        public void Connect() => _pollTimer.Start();
        public void Disconnect() => _pollTimer.Stop();

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static Random _random = new Random();
        
        private void CheckForMessage(object source, EventArgs e)
        {
            Console.WriteLine("Checking for new messages");

            if ((_random.Next(3) == 0) && (MessageArrived != null))
            {
                MessageArrived(this , new MessageArrivedEventArgs("Hello Kexin"));
            }
        }
    }
}
