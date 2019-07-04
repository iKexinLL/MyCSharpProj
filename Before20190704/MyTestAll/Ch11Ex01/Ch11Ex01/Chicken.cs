using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex01
{
    internal class Chicken : Animal
    {
        public void LayEgg()
            => Console.WriteLine($"{Name} has laid an egg");

        public Chicken(string newName) : base(newName) { }
    }
}
