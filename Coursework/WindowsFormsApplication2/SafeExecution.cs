using System;
using System.Windows.Forms;

namespace Browser
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

        public static void DisplayError(Exception e, string msg, string caption, bool exit)
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
                DisplayError(
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
                DisplayError(
                    e,
                    "There has been an issue connecting to the database, please try again",
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
            catch (NullReferenceException e)
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
                else { throw new SafeExecution.MisformattedInput(valid); }
            }
            catch (SafeExecution.MisformattedInput e)
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
        
        public class DatabseException : Exception
        {
            public DatabseException(string msg) : 
                base(msg) {}
        }
        
        public class MisformattedInput : Exception
        {
            public MisformattedInput(string correctFormat) :
                base(correctFormat) { }
        }

        #endregion
    }
}