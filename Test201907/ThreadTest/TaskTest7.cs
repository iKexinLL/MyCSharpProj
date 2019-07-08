using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace MyTest
{
    /// <summary>
    /// 使用基于任务的异步模式来实现异步Web请求
    /// Task 和 Task<TResult> 是引用类型
    /// </summary>
    public class TaskTest7
    {
        private static async Task WriteWebRequestSizeAsync(string url)
        {
            try 
            {
                WebRequest webRequest = WebRequest.Create(url);
                ConsoleTaskTest7Info($"in WriteWebRequestSizeAsync before GetResponseAsync {Thread.CurrentThread.ManagedThreadId}");
                WebResponse response = await webRequest.GetResponseAsync();
                ConsoleTaskTest7Info("download finished.");
                ConsoleTaskTest7Info($"in WriteWebRequestSizeAsync after GetResponseAsync {Thread.CurrentThread.ManagedThreadId}");

                using(StreamReader reader = new StreamReader(
                    response.GetResponseStream()))
                {
                    ConsoleTaskTest7Info($"Now, Thread.CurrentThread.ManagedThreadId is {Thread.CurrentThread.ManagedThreadId}");
                    ConsoleTaskTest7Info("reading in using, and delay 5s");
                    ConsoleTaskTest7Info($"start time is {DateTime.Now.ToString()}");
                    await Task.Delay(5000);
                    ConsoleTaskTest7Info($"After await Task.Delay(5000), Thread.CurrentThread.ManagedThreadId is {Thread.CurrentThread.ManagedThreadId}");
                    ConsoleTaskTest7Info($"end time is {DateTime.Now.ToString()}");
                    string text = await reader.ReadToEndAsync();
                    ConsoleTaskTest7Info($"After await reader.ReadToEndAsync(), Thread.CurrentThread.ManagedThreadId is {Thread.CurrentThread.ManagedThreadId}");
                    ConsoleTaskTest7Info(SyncTest.FormatBytes(text.Length));
                }
            }
            catch (WebException)
            {
                throw new WebException();
            }
            catch (IOException)
            {
                throw new IOException();
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 当运行Task task = WriteWebRequestSizeAsync(url);时,在await之前,没有返回task
        /// 知道遇到了第一个await,然后task.wait生效,开始输出点
        /// 运行完毕第一个task后,会继续运行,直至代码段结束
        /// </summary>
        public static void TestStart()
        {
            string url = "https://github.com/Microsoft/TypeScript/issues/315";
            Task task = WriteWebRequestSizeAsync(url);
            while (!task.Wait(100))
            {
                Console.Write(".");
            }

            // Console.WriteLine("writeWebRequestSizeWithLambdaAsync start");
            Func<string, Task> writeWebRequestSizeWithLambdaAsync = 
                async (string webRequestUrl) =>
                {
                    WebRequest webRequest = WebRequest.Create(webRequestUrl);
                    ConsoleTaskTest7Info($"in writeWebRequestSizeWithLambdaAsync before GetResponseAsync {Thread.CurrentThread.ManagedThreadId}");
                    WebResponse response = await webRequest.GetResponseAsync();
                    ConsoleTaskTest7Info($"in writeWebRequestSizeWithLambdaAsync after GetResponseAsync {Thread.CurrentThread.ManagedThreadId}");
                    using(StreamReader reader = new StreamReader(
                        response.GetResponseStream()
                    ))
                    {
                        ConsoleTaskTest7Info($"Thread.CurrentThread.ManagedThreadId in Func<string, Task> is {Thread.CurrentThread.ManagedThreadId}");
                        string text = await reader.ReadToEndAsync();
                        ConsoleTaskTest7Info($"size is {SyncTest.FormatBytes(text.Length)}");
                    }
                };

            // Task taskWithLambda = writeWebRequestSizeWithLambdaAsync(url);
            // while (!taskWithLambda.Wait(100))
            // {
            //     Console.Write(".");
            // }            
        }

        public static void ConsoleTaskTest7Info<T> (T contents)
        {
            var tmp = GetACharacterFromCursorOnCSharp.ReadCharacterAt(Console.CursorLeft - 1, Console.CursorTop).GetValueOrDefault();
            if (tmp.Equals('.'))
                Console.Write("\n");
            Console.WriteLine(contents.ToString());
        }
    }
}