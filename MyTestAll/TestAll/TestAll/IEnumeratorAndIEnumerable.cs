using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    // ReSharper disable once InconsistentNaming
    static class IEnumeratorAndIEnumerable
    {
        public static void TestAll()
        {
            Garage garage = new Garage();
            GarageTwo garageTwo = new GarageTwo();
            GarageThree<Car> garageThree = new GarageThree<Car>();

            // 无法直接在garage中直接使用foreach
            // 由于garageTwo实现了IEnumerable.GetEnumerator()
            // 所以可以直接使用foreach了
            foreach (var car in garageTwo)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine("---garageTwo---");
            IEnumerator ier = garageTwo.GetEnumerator();
            while (ier.MoveNext())
            {
                Car myCar = (Car) ier.Current;
                Console.WriteLine(myCar);
            }
            
            Console.WriteLine("---garageThree---");
            foreach (var car in garageThree)
            {
                Console.WriteLine(car);
            }
            
        }
        
    }

    public class Garage
    {
        //在Garage中定义一个Car类型的数组carArray,其实carArray在这里的本质是一个数组字段
        public readonly Car[] CarArray = new Car[4];  

        //启动时填充一些Car对象
        public Garage()
        {
            //为数组字段赋值
            CarArray[0] = new Car("Rusty", 30);
            CarArray[1] = new Car("Clunker", 50);
            CarArray[2] = new Car("Zippy", 30);
            CarArray[3] = new Car("Fred", 45);
        }
    }

    public class GarageTwo : IEnumerable
    {
        // 在Garage中定义一个Car类型的数组carArray,其实carArray在这里的本质是一个数组字段
        public readonly Car[] CarArray = new Car[4];

        //启动时填充一些Car对象
        public GarageTwo()
        {
            //为数组字段赋值
            CarArray[0] = new Car("Rusty", 30);
            CarArray[1] = new Car("Clunker", 50);
            CarArray[2] = new Car("Zippy", 30);
            CarArray[3] = new Car("Fred", 45);
        }

        public IEnumerator GetEnumerator()
        {
            // throw new NotImplementedException();
            return this.CarArray.GetEnumerator();
        }
    }

    public class GarageThree<T> : IEnumerable<T>
        where T : Car
    {
        //在Garage中定义一个Car类型的数组carArray,其实carArray在这里的本质是一个数组字段
        private readonly Car[] _carArray = new Car[4];

        private readonly List<T> _carList = new List<T>();

        //启动时填充一些Car对象
        public GarageThree()
        {
            //为数组字段赋值
            _carArray[0] = new Car("Rusty", 30);
            _carArray[1] = new Car("Clunker", 50);
            _carArray[2] = new Car("Zippy", 30);
            _carArray[3] = new Car("Fred", 45);

            foreach (var car in _carArray)
            {
                _carList.Add(car as T);
            }

        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this._carList.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this._carList.GetEnumerator();
        }
    }

    public class Car
    {
        private string Name { get; set; }
        private int Id { get; set; }

        public Car(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"Name is {Name}, Id is {Id}.";
        }
    }

}
