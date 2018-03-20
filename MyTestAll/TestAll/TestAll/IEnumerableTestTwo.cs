using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAll
{
    public class Department
    {
        public long DepartmentsId { get; set; }
        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return $"{DepartmentName}";
        }
    }

    public class Employee
    {
        // public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public int DepartmentId { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Title);
        }
    }

    public static class CorporateData
    {
        public static readonly Department[] Departments = new Department[]
        {
            new Department() {DepartmentName = "Corporate", DepartmentsId = 0},
            new Department() {DepartmentName = "Finance", DepartmentsId = 1},
            new Department() {DepartmentName = "Engineering", DepartmentsId = 2},
            new Department() {DepartmentName = "Information Technology", DepartmentsId = 3},
            new Department() {DepartmentName = "Research", DepartmentsId = 4},
            new Department() {DepartmentName = "Marketing", DepartmentsId = 5},
        };

        public static readonly Employee[] Employees = new Employee[]
        {
            new Employee() {Name = "Mark Michaelis", Title = "Chief Computer Nerd", DepartmentId = 0},
            new Employee() {Name = "Michael Stokesbary", Title = "Senior Computer Wizard", DepartmentId = 2},
            new Employee() {Name = "Brian Jones", Title = "Enterprise Integration Guru", DepartmentId = 2},
            new Employee() {Name = "Jewel Floch", Title = "Bookkeeper Extraordinaire", DepartmentId = 1},
            new Employee() {Name = "Robert Stokesbary", Title = "Expert Mainframe Engineer", DepartmentId = 3},
            new Employee() {Name = "Paul R. Bramsman", Title = "Programmer Extraordinaire", DepartmentId = 2},
            new Employee() {Name = "Thomas Heavey", Title = "Software Architect", DepartmentId = 2},
            new Employee() {Name = "John Michaelis", Title = "Inventor", DepartmentId = 4}
        };
    }


    // ReSharper disable once InconsistentNaming
    static class IEnumerableTestTwo
    {
        public static void TestAll()
        {
            IEnumerable<Department> departments = CorporateData.Departments;
            Print(departments);

            Console.WriteLine();

            IEnumerable<Employee> employees = CorporateData.Employees;
            Print(employees);

            // 开始使用join
            // departments指定了employees要联接
            var items = employees.Join(
                departments,
                employee => employee.DepartmentId,
                department => department.DepartmentsId,
                (employee, department) => new
                {
                    employee.Name,
                    employee.Title,
                    department.DepartmentName,
                });

            foreach (var item in items)
            {
                Console.WriteLine("{0} ({1})", item.Name, item.Title);
                Console.WriteLine("\t" + item.DepartmentName);
            }

            IEnumerable<Employee> employeesG = CorporateData.Employees;

            // ... 这个 string才是返回类型
            // employee.Name.Substring(0,1) 的类型对应 IGrouping<string, Employee>中的string
            IEnumerable<IGrouping<string, Employee>> groupedEmployee =
                employeesG.GroupBy((employee) => employee.Name.Substring(0, 1));

            foreach (IGrouping<string, Employee> grouping in groupedEmployee)
            {
                Console.WriteLine();
                foreach (var g in grouping)
                {
                    Console.WriteLine("\t" + g);
                }
                Console.WriteLine("\tCount: " + grouping.Count());
            }

            Department[] departmentsTwo = CorporateData.Departments;
            Employee[] employeesTwo = CorporateData.Employees;

            Console.WriteLine("-------------GroupJoin---------");
            
            var itemsTwo = departmentsTwo.GroupJoin(
                employeesTwo,
                department => department.DepartmentsId,
                employee => employee.DepartmentId,
                (department, employee) => new
                {
                    department.DepartmentsId,
                    department.DepartmentName,
                    Employee = employee
                });

            foreach (var item in itemsTwo)
            {
                Console.WriteLine(item.DepartmentName);

                foreach (var employee in item.Employee)
                {
                    Console.WriteLine("\t" + employee);
                }
            }

            Console.WriteLine("-------------GroupJoin end-------");

            Console.WriteLine("-------------实现外联---------");

            var itemsThree = departments.GroupJoin(
                employees,
                department => department.DepartmentsId,
                employee => employee.DepartmentId,
                (department, departmentEmployee) => new
                {
                    department.DepartmentsId,
                    department.DepartmentName,
                    Employees = departmentEmployee
                }).SelectMany(
                departmentRecord => departmentRecord.Employees.DefaultIfEmpty(),
                (deparmentRecord, employee) => new
                {
                    deparmentRecord.DepartmentsId,
                    deparmentRecord.DepartmentName,
                    Employees = deparmentRecord.Employees
                }).Distinct();

            Console.WriteLine("----------实现外联  end---------");

            foreach (var item in itemsThree)
            {
                Console.WriteLine(item.DepartmentName);

                foreach (var g in item.Employees)
                {
                    Console.WriteLine("\t" + g);
                }
            }

            // Console.WriteLine("--------Select&SelectMany-----");

            string[] text = {"Zhou Jing", "walking in", "the sideway"};
            var tokens = text.Select(s => s.Split(' '));
            foreach (string[] line in tokens)
                foreach (string token in line)
                    Console.Write("{0}-", token);

            Console.WriteLine();
            var tokensT = text.SelectMany(s => s.Split(' '));
            foreach (var s in tokensT)
            {
                Console.Write($"{s}-");
            }

            // Console.WriteLine("--------Select&SelectMany end-----");
        }

        private static void Print<T>(IEnumerable<T> items, string methodName = null)
        {
            Console.WriteLine($"----IEnumerableTestTwo.{methodName}----------");

            foreach (T item in items)
            {
                Console.WriteLine(item);
            }

            var tempSign = methodName is null ? null : "." + methodName;

            Console.WriteLine($"----IEnumerableTestTwo{tempSign} end-------");
        }
    }
}