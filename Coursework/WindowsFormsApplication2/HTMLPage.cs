using System;
using System.Windows.Forms;

namespace Browser
{
    public class HTMLPage
    {
        public string rawHTML;
        public string status;
        public string title;
        public string url;
        public int visits;
        public DateTime accessDateTime;

        public HTMLPage(string url, string title, string status, string rawHtml)
        {
            this.url = url;
            this.title = title;
            this.status = status;
            rawHTML = rawHtml;
            visits = 0;
            accessDateTime = DateTime.Now;
        }
    }
}