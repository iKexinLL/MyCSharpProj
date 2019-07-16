using System;
using System.Collections.Generic;
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

        public static int[] TwoSum2(int[] nums, int target)
        {
            cnt += 1;
            Console.WriteLine($"cnt is {cnt}");
            // 反过来使用,由于知道了结果,那么用结果结果减去当前值,然后判断结果是否在nums中即可.
            for (int i = 0; i < nums.Length; i++)
            {
                var temp = target - nums[i];
                var res = Array.IndexOf(nums, temp);
                if (res != -1)
                {
                    return new int[] {i, res};
                }
            }
            return new int[2];
        }

        public static int[] TwoSum3(int[] nums, int target)
        {
            cnt += 1;
            Console.WriteLine($"cnt is {cnt}");
            // 反过来使用,由于知道了结果,那么用结果结果减去当前值,然后判断结果是否在nums中即可.
            // 但是array查找效率有些低,那么使用其他方式
            // 最佳答案里面用的是Dictionary
            Dictionary<int, int> intStore = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (intStore.ContainsKey(target - nums[i]))
                {
                    return new int[] {intStore[target -nums[i]], i};
                }
                intStore[nums[i]] = i;
            }
            return new int[2];
        }

        public static void TestStart()
        {
            
            // var sw = new Stopwatch();
            // sw.Start();

            int[] nums = {2, 7, 11, 15};
            int target = 17;

            TestTwoSumHandler += TwoSum;
            TestTwoSumHandler += TwoSum2;
            TestTwoSumHandler += TwoSum3;

            CallMethodInEvent(nums, target);
            // var res = TestTwoSumHandler(nums, target);
            // Console.WriteLine(res[0] + ", " + res[1]);
            // sw.Stop();

            // Console.WriteLine($"run time is {sw.ElapsedMilliseconds}");

            // var ac = new Func<int[], int, int[]>(TwoSum);
            // res = ac(nums, target);
            // Console.WriteLine(res[0] + ", " + res[1]);
        }

        public static void CallMethodInEvent(int[] nums, int target)
        {
            var delegateArray = TestTwoSumHandler.GetInvocationList();
            foreach (var i in delegateArray)
            {
                var midMethod = (Func<int[],int,int[]>)i;
                var res = midMethod(nums, target);
                Console.WriteLine(res[0] + ", " + res[1]);
            }
        }
    }
}