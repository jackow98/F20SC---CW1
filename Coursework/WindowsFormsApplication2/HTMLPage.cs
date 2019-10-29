using System;
using System.Windows.Forms;

namespace Browser
{
    public class HTMLPage : IWebpage
    {
        public DateTime accessDateTime;
        public string rawHTML;
        public string status;
        public string title;
        public string url;
        public int visits;

        public HTMLPage(string url, string title, string status, string rawHtml)
        {
            this.url = url;
            this.title = title;
            this.status = status;
            rawHTML = rawHtml;
            visits = 0;
            accessDateTime = DateTime.Now;
        }

        public GroupBox DisplayElement()
        {
            throw new NotImplementedException();
        }
    }
}