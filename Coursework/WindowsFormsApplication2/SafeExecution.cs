using System;
using System.Windows.Forms;

namespace Browser
{
    public static class SafeExecution
    {
        public delegate string GetStringMethod();
        public delegate void UpdateGuiMethod();
        public delegate void DatabaseConnectionMethod();
        public delegate TDatabaseReturn DatabaseInteractionMethod<TDatabaseReturn>();

        public static void DisplayErrorAndExit(Exception e, string msg, string caption)
        {
            MessageBox.Show(
                msg,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Application.Exit();
        }

        public static void UpdateGui(UpdateGuiMethod update)
        {
            try
            {
                update();
            }
            catch (Exception e)
            {
                DisplayErrorAndExit(
                    e,
                    "There has been an issue displaying your web browser, please restart the application",
                    "Application Error"
                );
            }
        }

        public static void DatabaseConnection(DatabaseConnectionMethod connect)
        {
            try
            {
                connect();
            }
            catch (Exception e)
            {
                DisplayErrorAndExit(
                    e,
                    "There has been an issue connecting to the database, please restart the application",
                    "Database Connection error"
                );
            }
        }

        public static string GetString(GetStringMethod get)
        {
            try
            {
                return get();
            }
            catch (NullReferenceException e)
            {
                return "";
            }
        }

        public class HttpRequestException : Exception
        {
            public HttpRequestException(string msg) : 
                base(msg) {}
        }
        
        public class DatabseException : Exception
        {
            public DatabseException(string msg) : 
                base(msg) {}
        }
    }
}