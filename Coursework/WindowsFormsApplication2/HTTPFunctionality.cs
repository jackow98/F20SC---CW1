﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Browser
{
    public class HttpFunctionality
    {
        private string url;
        private string html;
        string status;
        private HttpWebRequest request;
        private HttpWebResponse response;
        
        public HttpFunctionality(string url)
        {
            this.url = url;
        }

        public HTMLPage MakeRequest()
        {
            this.request = (HttpWebRequest) HttpWebRequest.Create(url);
            
            // Get the response
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                
                status = ((HttpWebResponse)response).StatusDescription;
                
                // Get the stream containing content returned by the server. 
                // The using block ensures the stream is automatically closed. 
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    this.html = reader.ReadToEnd();
                    // Display the content
                }

                response.Close();
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)exception.Response;
                    this.status = response.StatusDescription;
                }
                else
                {
                    //TODO: Handle exception caused by hw.ac.uk
                    this.status = response.StatusDescription;
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            
            //TODO: Implement title
            HTMLPage returnPage = new HTMLPage(this.url, "test", this.status, this.html);
            return returnPage;
        }
    }   
}