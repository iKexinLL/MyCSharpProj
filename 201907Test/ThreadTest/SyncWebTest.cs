using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;

namespace MyTest
{
    // 18.5.2 使用TPL调用高延迟操作
    // 18-14 异步的Web请求
    public class SyncWebTest
    {
        public static void TestStart()
        {
            const string url = @"https://code.visualstudio.com/docs/getstarted/keybindings";
            Console.WriteLine($"url is {url}");

           var task = WriteWebRequestSizeAsync(url);

            try
            {
                while (!task.Wait(100))
                {
                    Console.WriteLine(".");
                }
            }
            catch (AggregateException exception)
            {
                exception = exception.Flatten();
                try
                {
                    exception.Handle( innerException =>
                    {
                        // ExceptionDispath.Capture(exception.InnerException).Throw();
                        return true;
                    });
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
        }

        private static Task WriteWebRequestSizeAsync(string url)
        {
            StreamReader reader = null;

            WebRequest webRequest = WebRequest.Create(url);
            Task<WebResponse> task = webRequest.GetResponseAsync();
            task.ContinueWith( antecedent => 
            {
                WebResponse response = antecedent.Result;
                reader = new StreamReader(response.GetResponseStream());

                return reader.ReadToEndAsync();
            })
            .Unwrap()
            .ContinueWith( antecedent =>
            {
                if (reader != null)
                    reader.Dispose();
                string text = antecedent.Result;

                Console.WriteLine(SyncTest.FormatBytes(text.Length));
            });

            return task;
        }
    }
}