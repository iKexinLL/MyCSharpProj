using System;
using System.Threading;

namespace Test201907.CookByAsyncAwait
{
    
    public class Bread : BaseFood
    {
        public Bread(string name, int cooktime=2) : base(name, cooktime)
        {
        }
    }
}