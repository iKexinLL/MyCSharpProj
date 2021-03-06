﻿using System;

namespace Ch12Ex02
{
    public abstract class Animal
    {
        protected string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Animal()
        {
            name = "The animal with no name";
        }

        public Animal(string newName)
        {
            name = newName;
        }

        public void Feed() => Console.WriteLine($"{name} has been fed.");

        public abstract void MakeNoise();
    }
}