using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Browser;

namespace Coursework.Functionality
{
    public class HttpFunctionality
    {
        private string html;
        private HttpWebRequest request;
        private HttpWebResponse response;
        private string status;
        private readonly string url;

        public HttpFunctionality(string url)
        {
            this.url = url;
        }

        public HTMLPage MakeRequest()
        {
            request = (HttpWebRequest) WebRequest.Create(url);

            // Get the response
            try
            {
                response = (HttpWebResponse) request.GetResponse();

                status = (int) response.StatusCode + "-" + response.StatusCode;

                // Get the stream containing content returned by the server. 
                // The using block ensures the stream is automatically closed. 
                using (var dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    var reader = new StreamReader(dataStream);
                    // Read the content.  
                    html = reader.ReadToEnd();
                    // Display the content
                }

                response.Close();
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse) exception.Response;
                    status = (int) response.StatusCode + "-" + response.StatusCode;
                }
                else
                {
                    //TODO: Handle exception caused by hw.ac.uk
                    status = (int) response.StatusCode + "-" + response.StatusCode;
                }
            }
            finally
            {
                if (response != null) response.Close();
            }

            //Regex code sourced from https://stackoverflow.com/questions/329307/how-to-get-website-title-from-c-sharp
            var title = "";
            if (html != null)
                title = Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                    RegexOptions.IgnoreCase).Groups["Title"].Value;


            var returnPage = new HTMLPage(url, title, status, html);
            return returnPage;
        }
    }
}