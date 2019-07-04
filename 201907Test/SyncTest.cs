using System;
using System.IO;
using System.Net;
using System.Linq;

namespace MyTest
{

    // 使用同步的方式请求Web
    public class SyncTest
    {
        public static void TestStart()
        {
            string url = @"https://www.cnblogs.com/asminfo/p/3999412.html";
            try
            {
                Console.WriteLine($"Url is {url}");
                WebRequest webRequest = WebRequest.Create(url);

                WebResponse webResponse = webRequest.GetResponse();
                Console.WriteLine("download finished.......");

                using(StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine(FormatBytes(text.Length));
                }
            }
            catch (WebException)
            {

            }
            catch (IOException)
            {

            }
            catch(NotSupportedException)
            {

            }
        }

        public static string FormatBytes(long bytes)
        {
            // 定义单位
            string[] magnitudes = new string[] {"GB", "MB", "KB", "Bytes"};
            // string[] magnitudes = new string[] {"A", "B", "C", "D"};

            // 初始化单位最大符合的数值,如果大于此数值,则直接显示第一个单位
            long max = (long)Math.Pow(1024, magnitudes.Length);

            // 怎么从长度为4的集合中选取正确的单位?
            // public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
            // 传入一个委托,其返回第一个值为真的项目
            // 每次运行,max将减少1024(单位相差值)
            return string.Format("{1: ##.##} {0}",
                magnitudes.FirstOrDefault(
                    // 不断的较少单位最大符合的数值,直到bytes大于数值,这样相比后,能够得到一个合理的值
                    // 如果无符合条件的,使用??运算符返回0 Bytes
                    magnitude => bytes > (max /= 1024)) ?? "0 Bytes", 
                    (decimal)bytes / (decimal)max).Trim();
            /*
            # python:
            max = math.pow(1024, 4)
            for n, i in enumerate(magnitudes):
                if (bytes > max):
                    print((bytes / max), i)
                else:
                    max = max / 1024
            */
        }
    }
}