using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    static class SimpleSort
    {
        public static void BubbleSort(int[] items)
        {
            if (items == null)
                return;
            
            // 从小到大进行排序
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = i; j < items.Length; j++)
                {
                    if (items[i] > items[j])
                    {
                        int temp = items[j];
                        items[j] = items[i];
                        items[i] = temp;
                    }
                }
            }
//
//            foreach (var item in items)
//            {
//                Console.WriteLine(item);
//            }

        }
    }
}
