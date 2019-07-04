using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest
{
    public partial class PartialClassTest1
    {
        public static void PartialClassTestPart1()
        {
            Console.WriteLine("this is PartialClassTestPart1");
        }

        partial void PartialMethod();
    }

    public partial class PartialClassTest1
    {
        partial void PartialMethod()
        {
            Console.WriteLine("this is PartialMethod");
        }
    }
}
