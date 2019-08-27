using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

using MyTest.Spider.Interfaces;
using MyTest.Spider.SpiderEvents;

namespace MyTest.Spider
{
    public class SpiderTest
    {
        public static void TestStart()
        {
            var crawlerTest = new SimpleCrawler();

            var testUri = "https://movie.douban.com/cinema/nowplaying/changchun/";

            crawlerTest.OnStart += (s, e) =>
            {
                Console.WriteLine("爬虫开始抓取地址：" + e.Uri.ToString());
            };

            crawlerTest.OnError += (s, e) =>
            {
                Console.WriteLine("爬虫抓取出现错误：" + e.Uri.ToString() 
                                + "，异常消息：" + e.Exception.Message);
            };

            crawlerTest.OnCompleted += (s, e) =>
            {
                // Console.WriteLine(e.PageSource);

                // HtmlWeb web = new HtmlWeb();
                // var htmlDoc = web.Load(html);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(e.PageSource);

                var file_path = @"e:\temp\douban.txt";
                using (StreamWriter sw = new StreamWriter(file_path, false, Encoding.UTF8))
                {
                    foreach(char str in e.PageSource)
                    {
                        sw.Write(str);
                    }
                }

                Console.WriteLine("===============================================");
                // Console.WriteLine("爬虫抓取任务完成！合计 " + links.Count + " 个城市。");
                Console.WriteLine("耗时：" + e.Milliseconds + "毫秒");
                Console.WriteLine("线程：" + e.ThreadId);
                Console.WriteLine("地址：" + e.Uri.ToString());
            };

            crawlerTest.Start(new Uri(testUri)).Wait();
        }
    }  
}