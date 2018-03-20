using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestAll
{
    // 模仿Connect
    public delegate void MessageHandler(string textMessage);

    class Connection
    {
        public event MessageHandler MessageArrived;

        private readonly Timer _pollTimer;

        private readonly Random _random;

        private List<char> _lt;

        public Connection()
        {
            _pollTimer = new Timer();
            _pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);

            _random = new Random();
            _lt = GetLetters();
        }

        private List<char> GetLetters()
        {
            List<char> lt = new List<char>();
            int cStart = 65;
            int cEnd = 90;

            while (cStart <= cEnd)
            {
                lt.Add((char)cStart);
                cStart++;
            }

            return lt;
        }

        private void CheckForMessage(object sender, ElapsedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < 6; i++)
            {
                int index = _random.Next(0, 25);
                sb.Append(_lt[index]);
            }

            MessageArrived?.Invoke(sb.ToString());
        }

        public static void TestAll()
        {
            Console.WriteLine("Message arrived");
            
            Connection connection = new Connection();
            Display display = new Display();
            
            
            
        }
    }


    public class Display
    {
        public void DisplayMessage(string message)
            => Console.WriteLine($"Message is {message}");
    }

}
