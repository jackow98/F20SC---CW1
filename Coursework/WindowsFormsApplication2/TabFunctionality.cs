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

        public HTMLPage search_string(string url)
        {
            
            
            
            if (HelperMethods.checkUrl(url))
            {
                 http = new HttpFunctionality(url);
                 return http.MakeRequest();
            }
            else
            {
                //TODO: Handle exceptions
                return new HTMLPage("Enter URL", "", "", "");
            }
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