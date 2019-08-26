using System;

namespace MyTest.Spider.SpiderEvents
{
    public class OnErrorEventArgs
    {
        public Uri Uri { get; set; }

        public Exception Exception { get; set; }

        public OnErrorEventArgs(Uri uri, Exception exception) {
            this.Uri = uri;
            this.Exception = exception;
        }
    }
}