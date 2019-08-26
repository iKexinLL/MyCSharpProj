using System;

namespace MyTest.Spider.SpiderEvents
{
    public class OnCompletedEventArgs
    {
        public OnCompletedEventArgs(Uri uri, int threadId, long milliseconds, string pageSource)
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
}