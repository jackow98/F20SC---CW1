using System;
using System.Windows.Forms;

namespace Browser
{
    public class HTMLPage : IWebpage
    {
        private string URL;
        private string title;
        private int status;
        private string rawHTML;
        private int visits;
        private DateTime accessDateTime;

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public GroupBox DisplayElement()
        {
            throw new System.NotImplementedException();
        }
    }
}