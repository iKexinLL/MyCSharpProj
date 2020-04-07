using System;
using System.Threading;

namespace Test201907.CookByAsyncAwait
{
    
    public class Coffee : BaseFood
    {
        public Coffee(string name, int cooktime=3) : base(name, cooktime)
        {
        }
    }
}