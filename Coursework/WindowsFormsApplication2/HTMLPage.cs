using System;
using System.Windows.Forms;

namespace Browser
{
    public class HTMLPage : IWebpage
    {
        public string url;
        public string title;
        public string status;
        public string rawHTML;
        public int visits;
        public DateTime accessDateTime;

        public HTMLPage(string url, string title, string status, string rawHtml)
        {
            this.url = url;
            this.title = title;
            this.status = status;
            this.rawHTML = rawHtml;
            this.visits = 0;
            this.accessDateTime = DateTime.Now;
        }

        public GroupBox DisplayElement()
        {
            throw new System.NotImplementedException();
        }
    }
}