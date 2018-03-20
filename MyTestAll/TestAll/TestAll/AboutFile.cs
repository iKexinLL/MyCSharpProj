using System;
using System.IO;

namespace TestAll
{
    class AboutFile
    {
        public static int CountFileMethod()
        {
            return 0;
        }

        public static int CountFileMethod(string directory, string extension = "*.cs")
        {
            int fileCount = 0;
            foreach (string file in Directory.GetFiles(directory,extension))
            {
                fileCount++;
            }

            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                fileCount += CountFileMethod(subDirectory, extension);
                // Console.WriteLine(subDirectory);
            }
            
            return fileCount;
        }
    }
}
