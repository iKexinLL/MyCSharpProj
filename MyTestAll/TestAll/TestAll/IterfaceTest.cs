using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    // C#本质论 7.接口
    
    // 7.5 接口继承
    interface IReadableSettingProvier
    {
        string GetSetting(string name, string defaultValue);
    }

    interface ISettingsProvider : IReadableSettingProvier
    {
        string SetSetting(string name, string value);
    }

    class FileSettingsProvider : ISettingsProvider
    {
        public string GetSetting(string name, string defaultValue)
        {
            return $"name is {name}, default value is {defaultValue}";
        }

        public string SetSetting(string name, string value)
        {
            string getSetting = GetSetting("Name", "Value");
            return "SetSetting: " + getSetting;
        }
    }
    // 7.5 end

    // 7.9 版本控制
    // 通过继承来添加新的方法
    // 而不能修改发布的接口
    // 通过实现IDistributedSettingProvider来给ISettingsProvider添加方法.
    // 然后根据需要来使用IDistributedSettingProvider或ISettingsProvider
    interface IDistributedSettingProvider : ISettingsProvider
    {
        string GetSetting(string machineName,
            string name, string defaultValue);

        string SetSetting(string machineName,
            string name, string value);
    }
    


    // 下面两个类,分别实现了这个接口
    // 但是 Headers() 并未方法接口中
    interface IListable
    {
        string[] ColumnValues { get; }
    }

    // 使用IPerson达到"多重继承"
    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public abstract class PdaItem
    {
        protected PdaItem(string name)
        {
            Name = name;
        }

        // 虚方法,详见DerivedTest
        public virtual string Name { get; set; }
    }

    // 新增实现IComparable接口
    class Contact : PdaItem, IListable, IComparable, IPerson
    {
        public const int ColumnSpacingContact = -20;

        private Person Person
        {
            get => _person;
            set => _person = value;
        }

        private Person _person;
        
        public Contact(string firstName, string lastName,
            string address, string phone) : base(null)
        {
            _person = new Person();
            
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
        }

        public string FirstName
        {
            get => _person.FirstName;
            set => _person.FirstName = value;
        }
        public string LastName
        {
            get=> _person.LastName;
            set => _person.LastName = value;
        }
        public string Address { get; set; }
        public string Phone { get; set; }

        // public string[] TStrings;

        // 用于实例对象
        public string[] ColumnValues
        {
            get => new string[]
            {
                FirstName,
                LastName,
                Phone,
                Address
            };

            // set => TStrings = value;
        }

        // 显示实现 IListable.ColumnValues
        // 用于接口
        string[] IListable.ColumnValues => new string[]
        {
            FirstName,
            LastName,
            Phone,
            Address
        };

        public static string[] Headers => new string[]
        {
            $"{"First Name",ColumnSpacingContact}",
            $"{"Last Name",ColumnSpacingContact}",
            $"{"Phone", ColumnSpacingContact}",
            // 这个貌似无法用ColumnSpacingContact代替
            String.Format("{0, 5}", "Address")
        };

        public int CompareTo(object obj)
        {
            int result;
            Contact contact = obj as Contact;
            
            if (obj == null)
            {
                result = 1;
            }
            else if (obj.GetType() != typeof(Contact))
            {
//                Console.WriteLine($"typeof(Contact) is {typeof(Contact)}");
//
//                if (obj is Contact)
//                {
//                    Console.WriteLine("yes");
//                    Console.WriteLine(obj);
//                    Console.WriteLine(typeof(Contact));
//                    var b = (Equals(obj, typeof(Contact)));
//                    Console.WriteLine(b);
//                }
//                else
//                {
//                    Console.WriteLine("no");
//                }
//                throw new ArgumentException("obj is not a Contact");
                result = 2;
            }
            else if (Contact.ReferenceEquals(this, obj))
            {
                result = 3;
            }
            else
            {
                result = String.Compare(LastName, contact.LastName, StringComparison.Ordinal);
                if (result == 0)
                {
                    result = String.Compare(FirstName, contact.FirstName, StringComparison.Ordinal) + 4;
                }
            }

            return result;
        }
    }

    public class Publication : IListable
    {
        public const int ColumnSpacingPublication = -40;

        public Publication(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }


        public string[] ColumnValues => new string[]
        {
            Title,
            Author,
            Year.ToString()
        };

        public static string[] Headers
        {
            get => new string[]
            {
                $"{"Title", ColumnSpacingPublication}",
                $"{"Author", ColumnSpacingPublication}",
                $"{"Year"}"
            };
        }
    }

    // 这个方法,利用了接口的多态性.
    // 无需关注内容具体形式,只根据其内容进行输出.
    static class ConsoleListControl
    {
        public static void List(string[] headers, IListable[] items, int columnSpacing)
        {
            int[] columnsWidths = DisplayHeaders(headers);

            foreach (var item in items)
            {
                string[] values = item.ColumnValues;

                DisplayItemRow(columnsWidths, values, columnSpacing);
            }
        }

        private static int[] DisplayHeaders(string[] heads)
        {
            int[] arr = new int[heads.Length];

            for (int i = 0; i < heads.Length; i++)
            {
                arr[i] = heads[i].Length;
                Console.Write(heads[i]);
            }
            Console.WriteLine();
            
            return arr;

//            List<int> list = new List<int>();
//            foreach (var head in heads)
//            {
//                list.Add(head.Length);
//            }
//
//            return list.ToArray();
        }

        private static void DisplayItemRow(
            int[] columnsWidths, string[] values, int columnSpacing)
        {
            for (int i = 0; i < columnsWidths.Length; i++)
            {
                Console.Write(i == columnsWidths.Length - 1 ? values[i] : values[i].PadRight(Math.Abs(columnSpacing)));
            }
            Console.WriteLine();
        }
    }

    // 接口的扩展方法
    static class Listable
    {
        public static void List(
            this IListable[] items, string[] headers)
        {
            int[] arr = new int[headers.Length];

            for (int i = 0; i < headers.Length; i++)
            {
                arr[i] = headers[i].Length;
                Console.Write(headers[i]);
            }
            Console.WriteLine();

        }
    }

    public static class IterfaceTest
    {
        public static void TestAll()
        {
            IListable[] contacts = new IListable[6];
            contacts[0] = new Contact("Dick", "Traci", "123 Main St., Spokane, WA 　 99037", "123-123-1234");
            contacts[1] = new Contact("Andrew", "Littman", "1417 Palmary St., Dallas, TX 55555", "555-123-4567");
            contacts[2] = new Contact("Mary", "Hartfelt", "1520 Thunder Way, Elizabethton, PA 44444",
                "444-123-4567");
            contacts[3] = new Contact("John", "Lindherst", "1 Aerial Way Dr., Monteray, NH 88888", "222-987-6543");
            contacts[4] = new Contact("Pat", "Wilson", "565 Irving Dr., Parksdale, FL 22222", "123-456-7890");
            contacts[5] = new Contact("Jane", "Doe", "123 Main St., Aurora, IL 66666", "333-345-6789");

            Contact ctOne = new Contact("Jane", "Doe", "123 Main St., Aurora, IL 66666", "333-345-6789");
            Contact ctTwo = new Contact("Jane", "Doe", "Haha St.    , Aurora, IL 66666", "333-345-6789");

            var ctThree = ctOne;

            Console.WriteLine("-----Contact.CompareTo-Start------");
            Console.WriteLine($"ctOne.CompareTo(null) is {ctOne.CompareTo(null)}");
            Console.WriteLine($"ctOne.CompareTo(\"123\") is {ctOne.CompareTo("123")}");
            Console.WriteLine($"ctOne.CompareTo(ctThree) is {ctOne.CompareTo(ctThree)}");
            Console.WriteLine($"ctOne.CompareTo(ctTwo) is {ctOne.CompareTo(ctTwo)}");
            Console.WriteLine("-----Contact.CompareTo-ENd------");
            Console.WriteLine();

            Console.WriteLine("实例,隐式");
            // Contact.ColumnValues
            foreach (var ctOneColumnValue in ctOne.ColumnValues)
            {
                Console.WriteLine(ctOneColumnValue);
            }

            Console.WriteLine("接口,显示");
            // IListable.ColumnValues
            var ctts = contacts[0];
            foreach (var ctt in ctts.ColumnValues)
            {
                Console.WriteLine(ctt);
            }

            Contact contact1 = new Contact("John", "Lindherst", "1 Aerial Way Dr., Monteray, NH 88888", "222-987-6543");
            Contact contact2 = new Contact("Pat", "Wilson", "565 Irving Dr., Parksdale, FL 22222", "123-456-7890");

            var values = ((IListable) contact2).ColumnValues;
            
            Console.WriteLine("--------End------------");
            


            // 两个ConsoleListControl.List利用了多态性
            // 使得可以处理两个不同的类
            ConsoleListControl.List(Contact.Headers, contacts, Contact.ColumnSpacingContact);

            Console.WriteLine();
            
            IListable[] publications = 
            {
                new Publication("Celebration of Discipline", "Richard Foster", 1978),
                new Publication("Orthodoxy", "G. K. Chesterton", 1908),
                new Publication("The Hitchhiker' s Guide to the Galaxy", "Douglas Adams", 1979)
            };
            
            ConsoleListControl.List(Publication.Headers, publications, Publication.ColumnSpacingPublication);

            Console.WriteLine("接口的扩展方法");
            contacts.List(Contact.Headers);
            publications.List(Publication.Headers);


            Console.WriteLine("------FileSettingsProvider-------");
            FileSettingsProvider fsp = new FileSettingsProvider();
            Console.WriteLine(fsp.GetSetting("Test", "Test"));

            ISettingsProvider isp = new FileSettingsProvider();
            Console.WriteLine(isp.SetSetting("Test", "Test"));

        }
    }
}