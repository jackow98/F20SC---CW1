using Browser;

namespace WindowsFormsApplication2.Functionality
{
    /// <summary>
    /// Class that tracks the information associated with a tab 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TabFunctionality<T> where T: IWebpage
    {
        public HTMLPage CurrentPage;
        public HttpFunctionality Http;
        public DatabaseFunctionality db;

        public TabFunctionality(ref DatabaseFunctionality db, HTMLPage page)
        {
            this.db = db;
            CurrentPage = page;
        }
        
        public string load_home_page()
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// Makes HTTP request for the page currently associated with the tab 
        /// </summary>
        /// <returns>The HTML Page retrieved after making the request</returns>
        public HTMLPage load_page()
        {
            HTMLPage loadedPage = Http.MakeRequest();
            db.AddHistory(loadedPage.url, loadedPage.title);
            return loadedPage;
        }

        /// <summary>
        /// Loads page after checking format of URL passed in and returns a HTML page
        /// </summary>
        /// <param name="url"> The string of the URL to be searched </param>
        /// <returns> A blank HTML Page if URL is badly formatted otherwise a filled HTTML Page</returns>
        public HTMLPage search_string(string url)
        {
            if (HelperMethods.checkUrl(url))
            {
                //TODO: should add to history and update tab table and favourites visits
                Http = new HttpFunctionality(url);
                CurrentPage = load_page();
                return CurrentPage;
            }

            //TODO: Handle exceptions
            return new HTMLPage("Enter URL", "", "", "");
        }
    }
}