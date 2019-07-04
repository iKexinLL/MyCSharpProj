using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class BubbleSort2
    {
        public enum SortType
        {
            Ascending,
            Descending
        }

        public static void BubbleSort(int[] items, SortType sortType)
        {
            if (items == null)
                return;

            // 从小到大进行排序
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = i; j < items.Length; j++)
                {
                    bool swap = false;
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            swap = items[i] > items[j];
                            break;
                        case SortType.Descending:
                            swap = items[i] < items[j];
                            break;
                    }
                    
                    if (swap)
                    {
                        int temp = items[j];
                        items[j] = items[i];
                        items[i] = temp;
                    }
                }
            }
        }
        
    }
}
