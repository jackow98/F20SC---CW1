using System;

namespace WindowsFormsApplication2
{
    public class HtmlPage
    {
        public readonly string RawHtml;
        public readonly string Status;
        public readonly string Title;
        public readonly string Url;
        public int Visits;
        public DateTime AccessDateTime;

        public HtmlPage(string url, string title, string status, string rawHtml)
        {
            this.Url = url;
            this.Title = title;
            this.Status = status;
            RawHtml = rawHtml;
            Visits = 0;
            AccessDateTime = DateTime.Now;
        }
    }
}