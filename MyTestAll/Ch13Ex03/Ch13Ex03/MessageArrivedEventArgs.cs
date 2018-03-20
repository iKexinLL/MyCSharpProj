using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex03
{
    class MessageArrivedEventArgs : EventArgs
    {
        public MessageArrivedEventArgs()
        {
            Message = "No message sent";
        }

        public MessageArrivedEventArgs(string newMessage)
        {
            Message = newMessage;
        }

        public string Message { get; }
    }
}