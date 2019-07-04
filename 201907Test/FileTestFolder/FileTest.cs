using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.IO.Compression;

namespace MyTest.FileTestFolder
{
    public class FileTest
    {
        const string path = @"E:\xkx\c_sharp";

        public static void TestStart()
        {
            // var mid_path = @"E:\xkx\c_sharp\MyTest";

            

            // DirectoryEnumerateDirectories();
            // PrintAdd(Directory.EnumerateDirectories, path, "EnumerateDirectories");
            // PrintAdd(Directory.EnumerateFileSystemEntries, path, "EnumerateFileSystemEntries");
            // PrintAdd(Directory.EnumerateFiles, path, "EnumerateFiles");
            
            
            
            // var tp = typeof(FileTest.DirectoryEnumerateDirectories);
        }

        private static void PrintAdd(Func<string, IEnumerable<string>> method, string path, string methodName)
        {
            Console.WriteLine($"{methodName} start");
            foreach (var i in method(path))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"{methodName} finish");
        }
    }
}