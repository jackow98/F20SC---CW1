using System;
using System.Text.RegularExpressions;

namespace Browser
{
    public class TabFunctionality<T> where T: IWebpage
    {
        public T currentPage;
        public Boolean pageHidden;
        public HttpFunctionality http;

        public TabFunctionality(BrowserWindow<T> browser, Boolean pageHidden)
        {
            //TODO: Implement functionality
            this.pageHidden = pageHidden;
        }
        
        public string load_home_page()
        {
            throw new System.NotImplementedException();
        }
        
        public HTMLPage reload_page()
        {
            return http.MakeRequest();
        }

        /// <summary>
        /// Makes HTTP request after checking format of URL passed in and returns a HTML page
        /// </summary>
        /// <param name="url"> The string of the URL to be searched </param>
        /// <returns> A blank HTML Page if URL is badly formatted otherwise a filled HTTML Page</returns>
        public HTMLPage search_string(string url)
        {
            if (HelperMethods.checkUrl(url)) { return new HttpFunctionality(url).MakeRequest();}
            
            //TODO: Handle exceptions
            return new HTMLPage("Enter URL", "", "", "");
        }

        public void close_tab()
        {
            
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}