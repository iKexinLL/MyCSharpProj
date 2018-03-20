using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{

    public delegate bool ComparisonHandler(int standardTemp, int nowTemp);
    
    class HeaterCooler
    {
        // 设定一个标准温度
        // 如果高于标准温度,则执行cooler
        // 如果低于标准问题,则执行heater

        public static int StandardTemp { get; set; }
        public static int NowTemp { get; set; }

        public static void JudgeTemp(ComparisonHandler comparisonMethod)
        {
            Console.WriteLine($"设定水温为{StandardTemp}");
            Console.WriteLine($"目前水温为:{NowTemp}");

            Console.WriteLine(comparisonMethod(StandardTemp, NowTemp) ? "高于设定温度" : "低于设定温度");
        }

        public static bool HeaterThan(int standardTemp, int nowTemp)
        {
            return standardTemp < nowTemp;
        }

//        public static bool CoolerThan(int standardTemp, int nowTemp)
//        {
//            return standardTemp > nowTemp;
//        }
    }
}
