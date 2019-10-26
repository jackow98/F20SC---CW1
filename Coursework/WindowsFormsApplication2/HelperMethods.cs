using System.Text.RegularExpressions;

namespace Browser
{
    public static class HelperMethods
    {
        /// <summary>
        /// Checks URL to ensure it is formatted correctly
        ///Regex code sourced from:
        ///     https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
        /// </summary>
        /// <param name="url">The url string to be checked</param>
        /// <returns>True if correctly formatted and false otherwise</returns>
        public static bool checkUrl(string url)
        {
            Match urlFormatted = Regex.Match(
                url, 
                @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)", 
                RegexOptions.IgnoreCase);
            
            return urlFormatted.Success;
        }
    }
}