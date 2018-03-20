using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://blog.csdn.net/xiaouncle/article/details/52573769

namespace TestAll
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class VersionAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public void Show()
        {
            Console.WriteLine("名称：{0} 日期：{1} 描述：{2}", Name, Date, Description);
        }
    }

    // VersionAttribute 将Attribute剔除后为特性的名字
    [Version(Name = "版本检测", Date = "2016-9-18", Description = "刚会用来一发")]
    class MyClass
    {
        
    }

    public static class AttributeTest
    {
        public static void TestAll()
        {
            Type tp = typeof(MyClass);
            VersionAttribute version = (VersionAttribute)Attribute.GetCustomAttribute(tp, typeof(VersionAttribute));
            Console.WriteLine("Name=" + version.Name);
            Console.WriteLine("Date=" + version.Date);
            Console.WriteLine("Description=" + version.Description);
            version.Show();
        }
    }
}
