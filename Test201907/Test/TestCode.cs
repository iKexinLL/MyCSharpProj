using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static int TitleToNumber(string s) {
            /*
                最初的想法有些错误,自己没有明白计算方式.
                比如AA则包含了A-Z以及AA共计27个字符
                比如BA则包含了A-Z,AA-AZ以及BA共计53个字符
                比如CA则包含了A-Z,AA-AZ,BA-BZ以及CA共计(26 * 3 + 1)个字符
                ....
                比如ZA则包含了(26 * (26 + 0) + 1)个字符
                比如AAA则包含了(26 * (26 + 1) + 1)个字符
                那么AAAA包含了
                (26 * (length - 1)) 

                该题目的意思其实就是26进制转十进制，其中1~26分别用A~Z表示，其实就是个进制转化问题
             */
            var tmp = s.ToCharArray();
            int res = 0;
            int length = tmp.Length;
            foreach(var midChar in tmp.Select((i, n) => new {value = i, index = n}))
            {
                var midValue = midChar.value - 'A' + 1;
                res += (int)Math.Pow(26, --length) * midValue;
            }

            return res;
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

            Console.WriteLine(TitleToNumber("ZY"));

            // CallMethodInEvent(nums, target);
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