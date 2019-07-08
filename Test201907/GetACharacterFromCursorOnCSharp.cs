using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MyTest
{
    public class GetACharacterFromCursorOnCSharp
    {
        public static void TestStart()
        {
            Console.Clear ();

            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            Console.Write("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            
            var lastChar = (Console.CursorLeft == 0 ? "" : "\n")  + 
                        "last char is " + 
                        ReadCharacterAt(Console.CursorLeft - 1, Console.CursorTop);

            Console.WriteLine($"{lastChar}");

            // char? first = ReadCharacterAt (10, 1);
            // char? second = ReadCharacterAt (20, 1);
            // Console.Write(".................");
            // Console.WriteLine($"Console.CursorLeft is {Console.CursorLeft}, Console.CursorTop is {Console.CursorTop}");
            // Console.WriteLine($"first is {first}, second is {second}");
        }

        public static char? ReadCharacterAt(int v1, int v2)
        {
            IntPtr consoleHandle = GetStdHandle (-11);
            if (consoleHandle == IntPtr.Zero)
                return null;
            
            Coord position = new Coord {
                X = (short) v1,
                Y = (short) v2
            };

            StringBuilder result = new StringBuilder (1);
            uint read = 0;
            if (ReadConsoleOutputCharacter (consoleHandle, result, 1, position, out read))
                return result [0];
            else 
                return null;
        }
    
        [DllImport("kernel32.dll", SetLastError=true)]
        private static extern IntPtr GetStdHandle(int v);

        [DllImport ("kernel32.dll", SetLastError = true)]
        private static extern bool ReadConsoleOutputCharacter (IntPtr hConsoleOutput, [Out] StringBuilder lpCharacter, uint length, Coord bufferCoord, out uint lpNumberOfCharactersRead);

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Coord 
    {
      public short X;
      public short Y;
    }
}