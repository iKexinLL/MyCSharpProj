using System;
using System.Collections;


namespace Ch11Ex01
{
    // 利用System.Collections.CollectionBase创建自己的集合类
    class CollectionBaseAnimal : CollectionBase
    {
        public void Add(Animal newCollectionBaseAnimal)
        {
            List.Add(newCollectionBaseAnimal);
        }

        public void Remove(Animal newCollectionBaseAnimal)
        {
            List.Remove(newCollectionBaseAnimal);
        }
        
        public Animal this[int animalIndex]
        {
            get => (Animal) List[animalIndex];
            set => List[animalIndex] = value;
        }
    }
}
