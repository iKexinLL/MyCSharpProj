using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class MyException : Exception
    {
        public MyException()
            : base("My exception")
        {
            Console.WriteLine("exception");
        }
    }
}
