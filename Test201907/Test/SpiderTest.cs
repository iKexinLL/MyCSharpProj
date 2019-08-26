using System;

namespace MyTest
{
    public class SpiderTest
    {
        
    }

    public class SimpleCrawler
    {
        // 爬虫启动事件
        public event EventHandler<OnStartEventArgs> OnStart;

        // 爬虫完成事件
        public event EventHandler<OnCompletedEventArgs> OnCompleted;

        // 爬虫出错时间
        public event EventHandler<Exception> OnError;

        // 定义Cookie容器
        public CookieContainer CookiesContainer { get; set; }

        public SimpleCrawler() { }
    }

    public class OnStartEventArgs
    {
        public OnStartEventArgs(Uri uri)
        {
            Uri = uri;
        }

        // 爬虫地址
        public Uri Uri { get; set; } 
    }

    public class OnCompletedEventArgs
    {
        public OnCompletedEventArgs(Uri uri, int threadId, string pageSource, long milliseconds)
        {
            this.Uri = uri;
            this.ThreadId = threadId;
            this.PageSource = pageSource;
            this.Milliseconds = milliseconds;
        }

        public Uri Uri { get; private set; }

        public int ThreadId { get; private set; }

        public string PageSource { get; private set; }

        public long Milliseconds { get; private set; }

        
    }

    public class CookieContainer
    {

    }
}