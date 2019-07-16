using System;
using System.Diagnostics;

namespace MyTest
{
    public class TestCode
    {

        public static event Func<int[],int,int[]> TestTwoSumHandler;
        public static int cnt = 0;

        public static int[] TwoSum(int[] nums, int target)
        {
            cnt += 1;
            Console.WriteLine($"cnt is {cnt}");
            // 暴力尝试
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // Console.WriteLine($"i is {i}, j is {j}");
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] {i, j};
                    }
                }
            }
            return new int[2];
        }

        public static void TestStart()
        {
            
            // var sw = new Stopwatch();
            // sw.Start();

            int[] nums = {2, 7, 11, 15};
            int target = 26;

            TestTwoSumHandler += TwoSum;
            TestTwoSumHandler += TwoSum;

            var res = TestTwoSumHandler(nums, target);
            Console.WriteLine(res[0] + ", " + res[1]);
            // sw.Stop();

            // Console.WriteLine($"run time is {sw.ElapsedMilliseconds}");

            // var ac = new Func<int[], int, int[]>(TwoSum);
            // res = ac(nums, target);
            // Console.WriteLine(res[0] + ", " + res[1]);
        }
    }
}