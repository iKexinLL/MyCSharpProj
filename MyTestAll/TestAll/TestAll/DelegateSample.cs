using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class DelegateSample
    {
        public delegate bool ComparisonHandler(int first, int second);

        public static void BubbleSort(int[] items, ComparisonHandler comparisonMethod)
        {
            if (comparisonMethod == null)
                throw new DelegateNullException();


            if (items == null)
                return;

            for (int i = 0; i < items.Length; i++)
            {
                for (int j = i; j < items.Length; j++)
                {
                    if (comparisonMethod(items[i], items[j]))
                    {
                        int temp = items[j];
                        items[j] = items[i];
                        items[i] = temp;
                    }
                }
            }
        }

        public static bool GreaterThan(int first, int second)
        {
            return first > second;
        }

        public static bool LessThan(int first, int second)
        {
            return first < second;
        }

        public static bool AlphaGreaterThan(int first, int second)
        {
            int comparison = 0;
            comparison = (String.Compare(first.ToString(), second.ToString(), StringComparison.Ordinal));

            return comparison > 0;
        }
    }

    
    public class DelegateNullException : Exception
    {
        public DelegateNullException() : base($"the methodName is null")
        {
            Console.WriteLine("a test exception");
        }
    }

}
// 253, 246, 227