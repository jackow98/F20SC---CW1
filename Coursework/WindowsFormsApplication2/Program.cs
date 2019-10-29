using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;
using Coursework.GUI;

namespace Browser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TODO: Make generic
            Application.Run(new BrowserWindow<HTMLPage>());
        }
    }
}
