using System;


namespace MyTest
{
    public static class TestThis
    {
        public static void thisTest(this Action<Person> action)
        {
            Person opt = new Person();
            action(opt);
        }

        public static void TestStart()
        {
            TestThis.thisTest(opt =>
                {
                    opt.Id = 1;
                    opt.Name = "Xu";
                    opt.Print();
                    Console.WriteLine(123);
                }); 
        }
    }

    public class Person
    {
        private int _id;
        private string name;

        private int age;

        public Person()
        {
            _id = 3;
            name = "Test";
            age = 4;
        }

        public void Print()
        {
            Console.WriteLine($"id is {_id}, name is {name}, age is {age}");
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
