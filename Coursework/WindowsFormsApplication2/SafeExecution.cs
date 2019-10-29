using System;
using System.Windows.Forms;

namespace Browser
{
    public static class SafeExecution
    {
        public delegate void UpdateGuiMethod();

        public static void UpdateGui(UpdateGuiMethod update)
        {
            try
            {
                update();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(
                    "There has been an issue diplaying your web browser, please restart the application",
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                Application.Exit();
            }
        }
    }
}