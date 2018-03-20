using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    // 协变逆变
    class XieBianNiBian
    {
        internal static readonly Action<object> BraodAction = (object data) 
            => { Console.WriteLine(data); };

        //static readonly Action<object> BraodAction = Console.WriteLine;

        internal static readonly Action<string> NarrowAction = BraodAction;

        internal static readonly Func<string> NarrowFunc = Console.ReadLine;

        internal static Func<object> BroadFunc = NarrowFunc;

        internal static Func<object, string> Func1Func = ReturnString;

        private static string ReturnString(object data)
        {
            return data.ToString();
        }
        
        public static void Test()
        {
            BraodAction("object");
            NarrowAction("string");
        }
    }
}
