using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyTest.EntityFrameworkTest
{
    // 1. 安装 Entity Framework Core
    // dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    // 2. 安装 Microsoft.EntityFrameworkCore.Design -> Shared design-time components for Entity Framework Core tools.
    // dotnet add package Microsoft.EntityFrameworkCore.Design
    // 3. Run next commmand to apply the new migration to the database. This command creates the database before applying migrations.
    // dotnet ef migrations add InitialCreate
    // dotnet ef database update
    // 这样会在直接创建好
    public class Book
    {
        public string Title { get; set; }
        [Key] public int Code { get; set; }
    }

    // 添加DbContext类(数据库上下文)
    public class BookContent : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyTest.db");
        }
    }

    public class EFTest
    {
        public static void TestStart()
        {
            using (var db = new BookContent())
            {
                Book book1 = new Book { Title = "Test1" };

                Book book2 = new Book { Title = "Test2" };

                if (!db.Books.Any())
                {
                    db.Books.Add(book1);
                    db.Books.Add(book2);
                    db.SaveChanges();
                }

                var query = from b in db.Books
                            orderby b.Title
                            select b;

                foreach (var i in query)
                {
                    Console.WriteLine(i.Title, i.Code);
                }
            }
        }
    }
}