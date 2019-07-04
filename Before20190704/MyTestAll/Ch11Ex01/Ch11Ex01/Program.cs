using System;
using System.Collections;


// 是否需要考虑拆箱装箱的消耗?
namespace Ch11Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            int testInt = 3;
            object testObj = testInt;
            int testInt2 = (int) testObj;
            
            
            Console.WriteLine("Create an Array type collection of Animal " + 
                              "objects and use it:");

            Animal[] animalArray = new Animal[2];

            Cow myCow1 = new Cow("Lea");

            animalArray[0] = myCow1;
            animalArray[1] = new Chicken("Noa");

            foreach (var animal in animalArray)
            {
                Console.WriteLine($"New {animal.ToString()} object added to Array" + 
                                  $" collection, Name = {animal.Name}");
            }

            Console.WriteLine($"Array collection contains {animalArray.Length} objects");
            
            animalArray[0].Feed();
            ((Chicken)animalArray[1]).LayEgg();
//            animalArray[1].LayEgg();

            Console.WriteLine();
            Console.WriteLine("Create an ArrayList type collection of Animal " +
                              "objects and use it");

            // 无需初始化大小
            ArrayList animaList = new ArrayList
            {
                new Cow("Rual"),
                new Chicken("Andrea")
            };


            // 这里,如果使用var进行循环的话, 直接使用animal.Name会提示错误
            // 因为 使用var,animal会是object格式
            // 所以这里我添加了强转
            // ArrayList实现了IEnumerable接口
            foreach (var animal in animaList)
            {
                Console.WriteLine($"new {animal.ToString()} object added to ArrayList " + 
                                  $"collection, Name = {((Animal)animal).Name}");
            }

            // Count-->ICollection接口
            Console.WriteLine($"ArrayList collection contains {animaList.Count}" + 
                              "objects");

            // ArrayList集合是System.Object对象的集合(通过多态性赋给Animal对象),所以必须对所有的项进行数据类型转换
            ((Animal)animaList[0]).Feed();
            ((Chicken)animaList[1]).LayEgg();

            Console.WriteLine();
            Console.WriteLine("Additional manipulation of ArrayList:");

            animaList.RemoveAt(0);
            ((Animal)animaList[0]).Feed();
            animaList.AddRange(animalArray);

            ((Chicken)animaList[2]).LayEgg();
            Console.WriteLine($"The animal called {myCow1.Name} is at " +
                              $"index {animaList.IndexOf(myCow1)}.");
            myCow1.Name = "Mary";
            Console.WriteLine("The animal is now " +
                      $"called {((Animal)animaList[1]).Name}.");

            Console.WriteLine("--------------CollectionBaseAnimal------------------");

            CollectionBaseAnimal cbAnimal = new CollectionBaseAnimal();
            cbAnimal.Add(new Cow("Donna"));
            cbAnimal.Add(new Chicken("Kevin"));
            
            foreach (Animal al in cbAnimal)
            {
                al.Feed();
            }

            // 定义了public Animal this[int animalIndex]这个方法之后
            // 才可以使用 cbAnimal[0]这种索引方式
            Console.WriteLine(cbAnimal[0].ToString());
            
            Console.ReadKey();
        }
    }
}
