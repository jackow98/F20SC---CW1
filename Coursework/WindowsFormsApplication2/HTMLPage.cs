using System;

namespace WindowsFormsApplication2
{
    /// <summary>
    ///      The class representation of a HTML web page used throughout application
    /// </summary>
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
            Url = url;
            Title = title;
            Status = status;
            RawHtml = rawHtml;
            Visits = 0;
            AccessDateTime = DateTime.Now;
        }
    }
}