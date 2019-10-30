using System;
using System.Windows.Forms;

namespace Browser
{
    public static class SafeExecution
    {
        public delegate string GetStringMethod();
        public delegate void UpdateGuiMethod();
        public delegate bool DatabaseConnectionMethod();
        public delegate TDatabaseReturn DatabaseInteractionMethod<TDatabaseReturn>();

        public static void DisplayErrorAndExit(Exception e, string msg, string caption, bool exit)
        {
            MessageBox.Show(
                msg,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            if (exit) Application.Exit();
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
                    "Application Error",
                    true
                );
            }
        }

        public static bool DatabaseConnection(DatabaseConnectionMethod connect)
        {
            try
            {
                return connect();
            }
            catch (Exception e)
            {
                DisplayErrorAndExit(
                    e,
                    "There has been an issue connecting to the database, please try again",
                    "Database Connection error",
                    false
                );
                return false;
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