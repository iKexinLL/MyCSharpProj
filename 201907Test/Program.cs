﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyTest.FileTestFolder;
using MyTest.EntityFrameworkTest;
using MyTest.AttributeTest;
using System.IO;
using System.Diagnostics;
// using MyTest;

namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {

            ReflectionTest3.TestStart();
            // AttributeTestOne.TestStart();

            // Obsolete特性测试
            // SearchPics(@"C:\Users\Administrator\Desktop");

            // TestThis.TestStart();

            
            // EFTest.TestStart();
            // FileTest.TestStart();
            // SyncTest.TestStart();
            // TaskTest6.TestStart();
            // TaskTest5.TestStart();
            // ThreadPoolTest.TestStart();
            // ThreadTest2.TestStart();
            // ReflectionTest.TestStart();
            // ReflectionTest2.TestStart(new string[] {"/help", "/out"});
            // Task.Delay(100);   
            // ThreadTest.TestStart();
            // Console.WriteLine(Test("xukexin", 3));
            // Console.WriteLine(Test(null, 3));
            // Console.WriteLine(null, 3);
            
            Console.WriteLine("End");
            Console.ReadKey();
        }

        public static string Test(string value, int length)
        {
            return value?.Substring(0, Math.Min(value.Length, length)) ?? "4";
        }

        [Obsolete("特性测试: Don't use OldMethod, use NewMethod instead", false)]
        [Conditional("Debug")]
        public static void SearchPics(string path)
        {
            var files = Directory.EnumerateFileSystemEntries(path, "*.*", SearchOption.TopDirectoryOnly);
            var res = from r in files
                    where r.EndsWith("png")
                    select r;

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }
    }
}
