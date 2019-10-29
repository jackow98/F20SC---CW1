using System;
using System.Windows.Forms;
using Coursework.GUI;

namespace Browser
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TODO: Make generic
            Application.Run(new BrowserWindow<HTMLPage>());
        }
    }
}