using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public static class SafeExecution
    {
        #region Delegates

        public delegate string GetStringMethod();
        public delegate void UpdateGuiMethod();
        public delegate bool DatabaseConnectionMethod();
        public delegate string CheckTextMethod();

        #endregion
        
        #region Safe Execution Methods

        private static void DisplayError(string msg, string caption, bool exit)
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
            catch (Exception)
            {
                DisplayError("There has been an issue displaying your web browser, please restart the application",
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
            catch (Exception)
            {
                DisplayError("There has been an issue connecting to the database, please try again",
                    "Database Connection error",
                    false
                );
                return false;
            }
        }

        public static string GetText(GetStringMethod get)
        {
            try
            {
                return get();
            }
            catch (NullReferenceException)
            {
                return "";
            }
        }
        
        public static string CheckText(CheckTextMethod check)
        {
            try
            {
                string valid = check();
                if (valid == "") { return valid; }
                else { throw new BadlyFormattedInput(valid); }
            }
            catch (BadlyFormattedInput e)
            {
                return e.Message;
            }
        }

        #endregion

        #region Exceptions

        public class HttpRequestException : Exception
        {
            public HttpRequestException(string msg) : 
                base(msg) {}
        }
        
        public class DatabaseException : Exception
        {
            public DatabaseException(string msg) : 
                base(msg) {}
        }

        private class BadlyFormattedInput : Exception
        {
            public BadlyFormattedInput(string correctFormat) :
                base(correctFormat) { }
        }

        #endregion
    }
}