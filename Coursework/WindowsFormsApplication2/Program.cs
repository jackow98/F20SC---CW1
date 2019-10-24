using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;

namespace Browser
{
    static class Program<T> where T : IWebpage
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BrowserWindow<T>());
        }
    }
}
