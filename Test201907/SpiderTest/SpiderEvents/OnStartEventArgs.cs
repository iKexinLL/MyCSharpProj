using System;

namespace MyTest.Spider.SpiderEvents
{
    public class OnStartEventArgs
    {
        public OnStartEventArgs(Uri uri)
        {
            Uri = uri;
        }

        // 爬虫地址
        public Uri Uri { get; set; } 
    }
}