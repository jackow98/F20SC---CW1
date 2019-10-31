using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    /// <summary>
    ///     Class that defines all exceptions and methods to ensure no exception is left unhandled
    /// </summary>
    public static class SafeExecution
    {
        //Delegate methods that are used within safe execution methods
        #region Delegates

        public delegate string GetStringMethod();
        public delegate void UpdateGuiMethod();
        public delegate bool DatabaseConnectionMethod();
        public delegate string CheckTextMethod();

        #endregion
        
        #region Safe Execution Methods

        /// <summary>
        ///     General method to display a message box with an error message
        /// </summary>
        /// <param name="msg">The error message to be displayed to the user</param>
        /// <param name="caption">The title of the message box to be displayed to the user</param>
        /// <param name="exit">Boolean that determines whether application exits after showing error</param>
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

        /// <summary>
        ///     Method used by functions displaying information to users to ensure any exceptions are handled
        /// </summary>
        /// <param name="update">A function to update the GUI that is to be executed</param>
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

        /// <summary>
        ///     Method used by functions connecting to the database
        /// </summary>
        /// <param name="connect">A function to connect with the database that is to be executed</param>
        /// <returns>Returns true if connected and false if connection fails</returns>
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

        /// <summary>
        ///     Method used by functions returning strings to ensure any exceptions are handled
        /// </summary>
        /// <param name="get">A function to return a string that is to be execute</param>
        /// <returns>Returns string from method or the empty string if there is an exception</returns>
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
        
        /// <summary>
        ///     Method used by functions that are sanitising a string to ensure any exceptions are handled
        /// </summary>
        /// <param name="check">>A function to check a string that is to be execute</param>
        /// <returns>Returns "" if correctly formatted or an error message otherwise</returns>
        /// <exception cref="BadlyFormattedInput">The exception raised if string check fails</exception>
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

        /// <summary>
        ///     Exception for HTTP requests
        /// </summary>
        public class HttpRequestException : Exception
        {
            public HttpRequestException(string msg) : 
                base(msg) {}
        }
        
        /// <summary>
        ///     Exceptions for any interaction with the database
        /// </summary>
        public class DatabaseException : Exception
        {
            public DatabaseException(string msg) : 
                base(msg) {}
        }

        /// <summary>
        ///     Exception for a malformed string
        /// </summary>
        private class BadlyFormattedInput : Exception
        {
            public BadlyFormattedInput(string correctFormat) :
                base(correctFormat) { }
        }

        #endregion
    }
}