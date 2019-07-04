using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex01
{
    public abstract class Animal
    {
        public string Name { get; set; }

        protected Animal()
        {
            Name = "The animal with no name.";
        }

        protected Animal(string newName)
        {
            Name = newName;
        }

        public void Feed()
            => Console.WriteLine($"{Name} has been fed");
    }
}
