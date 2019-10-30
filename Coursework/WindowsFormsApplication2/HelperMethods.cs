using System.Text.RegularExpressions;

namespace Browser
{
    public static class HelperMethods
    {
        /// <summary>
        ///     Checks URL to ensure it is formatted correctly
        ///     Regex code sourced from:
        ///     https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
        /// </summary>
        /// <param name="url">The url string to be checked</param>
        /// <returns>True if correctly formatted and false otherwise</returns>
        public static bool checkUrl(string url)
        {
            //TODO: Formatting of url should be less strict
            var urlFormatted = Regex.Match(
                url,
                @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)",
                RegexOptions.IgnoreCase);

            return urlFormatted.Success;
        }

        /// <summary>
        ///     Uses regex to find title tag in HTML, returns null if no title found
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string GetTitleFromHtml(string html)
        {
            //Regex code sourced from https://stackoverflow.com/questions/329307/how-to-get-website-title-from-c-sharp
            if (html != null)
                return  Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                    RegexOptions.IgnoreCase).Groups["Title"].Value;
            return null;
        }
    }
}