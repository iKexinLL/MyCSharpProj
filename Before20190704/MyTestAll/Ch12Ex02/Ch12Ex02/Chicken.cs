using System;

namespace Ch12Ex02
{
    public class Chicken : Animal
    {
        public void LayEgg() => Console.WriteLine($"{name} has laid an egg.");

        public Chicken(string newName) : base(newName)
        {
        }

        public override void MakeNoise()
        {
            Console.WriteLine($"{name} says 'cluck!'");
        }
    }
}