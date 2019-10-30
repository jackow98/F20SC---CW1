using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Browser;

namespace Coursework.Functionality
{
    /// <summary>
    ///     Class that handles HTTP requests for a given URL
    /// </summary>
    public class HttpFunctionality
    {
        private string _html;
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        private string _status;
        private readonly string _url;

        public HttpFunctionality(string url)
        {
            this._url = url;
        }

        /// <summary>
        ///     Makes a http request for URL associated with instantiation and returns a HTML Page
        /// </summary>
        /// <returns></returns>
        public HTMLPage MakeRequest()
        {
            try
            {
                // Get the response
                try
                {
                    _request = (HttpWebRequest) WebRequest.Create(_url);
                    _response = (HttpWebResponse) _request.GetResponse();
                    _status = (int) _response.StatusCode + "-" + _response.StatusCode;

                    // Get the stream containing content returned by the server. 
                    using (var dataStream = _response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.  
                        var reader = new StreamReader(dataStream);
                        // Read the content.  
                        _html = reader.ReadToEnd();
                        // Display the content
                    }

                    _response.Close();
                }
                //Catches any error codes and returns them alongside the error message
                catch (WebException exception)
                {
                    if (exception.Status == WebExceptionStatus.ProtocolError)
                    {
                        _response = (HttpWebResponse) exception.Response;
                        _status = (int) _response.StatusCode + "-" + _response.StatusCode;
                    }
                    else if (_response != null)
                    {
                        _status = (int) _response.StatusCode + "-" + _response.StatusCode;
                    }
                    else
                    {
                        //Throws exception if response is null
                        throw new SafeExecution.HttpRequestException(exception.Message);
                    }
                }
                finally
                {
                    if (_response != null) _response.Close();
                }

                //Safely gets title ensuring empty string returned if no title tag
                string title = SafeExecution.GetString(() => HelperMethods.GetTitleFromHtml(_html));
                return new HTMLPage(_url, title, _status, _html);
            }
            catch (SafeExecution.HttpRequestException e)
            {
                return new HTMLPage(_url, "", "", e.Message);
            }
        }
    }
}