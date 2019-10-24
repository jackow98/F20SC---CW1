using System;

namespace Browser
{
    public class TabFunctionality<T> where T: IWebpage
    {
        private T currentPage;
        private Boolean pageHidden;
        private HttpFunctionality http;

        public TabFunctionality(BrowserWindow<T> browser, Boolean pageHidden)
        {
            //TODO: Implement functionality
            this.pageHidden = pageHidden;
        }
        
        public string load_home_page()
        {
            throw new System.NotImplementedException();
        }
        
        public void reload_page()
        {
            currentPage.Reload();
        }

        public HTMLPage search_string(string url)
        {
            http = new HttpFunctionality(url);
            return http.MakeRequest();
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