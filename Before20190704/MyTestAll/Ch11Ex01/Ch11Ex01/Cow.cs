using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex01
{
    internal class Cow : Animal
    {
        public void Milk()
            => Console.WriteLine($"{Name} has been milk");

        public Cow(string newName): base(newName) { }
    }
}
