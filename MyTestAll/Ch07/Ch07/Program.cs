using System;
using System.Diagnostics;

namespace Ch07
{
    class Program
    {
        // Visual Studio 调试模式
        /* 
         * 
         * 
         * 
         */
        static void Main()
        {
            int[] testArray = new int[] {4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9};
            var maxima = Maxima(testArray, out _);

            Console.WriteLine($"maxima is {maxima}.");
            Console.ReadKey();
        }

        private static int Maxima(int[] integers, out int[] indices)
        {
            Debug.WriteLine("Maximum value search started.");
            indices = new[]{0};
            int maxVal = integers[0];
            int count = 1;
            Debug.WriteLine(string.Format($"Maximum value initialized to {maxVal}, at element index 0."));
            for (int i = 0; i < integers.Length; i++)
            {
                //Debug.Assert(i == 2, "now, i is 2", "Connect Xu");

                Debug.WriteLine(string.Format($"Now looking at element at {i}"));
                if (integers[i] > maxVal)
                {
                    maxVal = integers[i];
                    count = 1;
                    indices = new int[1];
                    indices[0] = i;
                    Debug.WriteLine(string.Format($"New maximum found. New value is {maxVal}, at element index {i}."));
                }
                else
                {
                    if (integers[i] == maxVal)
                    {
                        count++;
                        int[] oldIndices = indices;
                        indices = new int[count];
                        oldIndices.CopyTo(indices, 0);
                        indices[count - 1] = 0;
                        Debug.WriteLine(string.Format($"Duplicate maximum found at element index {i}."));
                    }
                }

            }
//
//            Console.WriteLine("int[] integers is:");
//            foreach (var variable in integers)
//            {
//                Console.WriteLine($"value in integers is {variable}");
//            }
//
//            Console.WriteLine("out int[] indices is:");
//            foreach (var variable in integers)
//            {
//                Console.WriteLine($"value in indices is {variable}");
//            }

            Trace.WriteLine(string.Format(
                $"Maximum value {maxVal} found, with {count} occurrences."));
            Debug.WriteLine("Maximum value search completed.");
            return maxVal;

        }
    }
}
