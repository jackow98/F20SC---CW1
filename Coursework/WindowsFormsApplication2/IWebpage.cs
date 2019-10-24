using System;
using System.Windows.Forms;

namespace Browser
{
    public interface IWebpage
    {
        void Reload();
        GroupBox DisplayElement();
    }
}