using System;
using System.Threading;

namespace Test201907.CookByAsyncAwait
{
    
    public class Eggs : BaseFood
    {
        public Eggs(string name, int cooktime=1) : base(name, cooktime)
        {
        }
    }
}