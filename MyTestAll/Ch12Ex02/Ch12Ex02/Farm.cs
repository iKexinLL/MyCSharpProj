using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex02
{
    public class Farm<T> : IEnumerable<T>
        where T : Animal
    {
        // private List<T> _animals = new List<T>();
        //
        // public List<T> Animals
        // {
        //     get => _animals;
        // }
        private List<T> _animals = new List<T>();

        public List<T> Animals => _animals;

        // 实现 IEnumerable<T> 中的两个方法
        public IEnumerator<T> GetEnumerator()
            => _animals.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _animals.GetEnumerator();

        public void MakeNoise()
        {
            foreach (var animal in _animals)
            {
                animal.MakeNoise();
            }
        }

        public void FeedTheAnimals()
        {
            foreach (var animal in _animals)
            {
                animal.Feed();
            }
        }

        // 特定类型的方法(非泛型)
        public Farm<Cow> GetCows()
        {
            Farm<Cow> cowFarm = new Farm<Cow>();
            
            foreach (var animal in _animals)
            {
                if (animal is Cow)
                {
                    cowFarm.Animals.Add(animal as Cow);
                }
            }

            return cowFarm;
        }

        // 泛型方法
        public Farm<U> GetSpecies<U>()
            where U : T
        {
            Farm<U> speciesFarm = new Farm<U>();

            foreach (var animal in _animals)
            {
                if (animal is U)
                {
                    speciesFarm.Animals.Add((animal as U));
                }
            }

            return speciesFarm;
        }
    }
}
