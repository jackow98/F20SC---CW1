using System.Text.RegularExpressions;

namespace WindowsFormsApplication2
{
    public static class SanitiseInput
    {
        
        /// <summary>
        ///     Checks URL to ensure it is formatted correctly
        ///     Regex code sourced from:
        ///     https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
        /// </summary>
        /// <param name="url">The url string to be checked</param>
        /// <returns>Empty string if correctly formatted or instructions on how to format correctly otherwise</returns>
        public static string CheckUrl(string url)
        {
            return SafeExecution.CheckText(() =>
            {
                var urlFormatted = Regex.Match(
                    url,
                    @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)",
                    RegexOptions.IgnoreCase);

                return urlFormatted.Success?"":"A URL must be of the form HTTPS or HTTP followed by ://[Your domain]";
            });
        }

        /// <summary>
        ///     Checks title string to ensure it is formatted correctly
        /// </summary>
        /// <param name="title">The title string to be checked</param>
        /// <returns>Empty string if correctly formatted or instructions on how to format correctly otherwise</returns>
        public static string CheckTitle(string title)
        {
            return SafeExecution.CheckText(() =>
            {
                var titleFormatted = Regex.Match(
                    title,
                    @"[a-zA-Z\s0-9()]",
                    RegexOptions.IgnoreCase);

                return titleFormatted.Success ? "" : "A title may only contain letters, numbers spaces and parentheses";
            });
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