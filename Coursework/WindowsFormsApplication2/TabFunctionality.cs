using System;

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
            //TODO: Handle checking of URL format better
            if (url != "")
            {
                 http = new HttpFunctionality(url);
                 return http.MakeRequest();
            }
            else
            {
                return new HTMLPage("", "", "", "");
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