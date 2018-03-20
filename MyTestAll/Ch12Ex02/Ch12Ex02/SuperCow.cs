using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace Ch12Ex02
{
    class SuperCow : Cow
    {
        public SuperCow(string newName) : base(newName)
        {
        }

        public void Fly()
        {
            Console.WriteLine($"{name} is flying");
        }

        public override void MakeNoise()
        {
            Console.WriteLine($"{name} says 'here i come to save the day!");
        }
    }
}
