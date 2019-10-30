using System.Collections.Generic;
using Browser;

namespace WindowsFormsApplication2.Functionality
{
    /// <summary>
    ///     Class to handle any tab level operations that don't involve the GUI
    /// </summary>
    public class TabFunctionality
    {
        private LinkedListNode<HtmlPage> _currentNode;
        public HtmlPage CurrentPage;
        private readonly DatabaseFunctionality _db;
        private HttpFunctionality _http;
        private readonly LinkedList<HtmlPage> _recentHistPages;
        private readonly int _tabIndex;

        /// <summary>
        ///      Constructor initialises all values associated with the tab
        /// </summary>
        /// <param name="db">The database connection that the tab uses</param>
        /// <param name="page">The HTML page to be associated with the tab</param>
        /// <param name="tabIndex">The index of the current tab</param>
        public TabFunctionality(ref DatabaseFunctionality db, HtmlPage page, int tabIndex)
        {
            this._db = db;
            CurrentPage = page;
            _recentHistPages = new LinkedList<HtmlPage>();
            _currentNode = _recentHistPages.Last;
            _tabIndex = tabIndex;
        }

        /// <summary>
        ///     Makes HTTP request for the page currently associated with the tab
        /// </summary>
        /// <returns>The HTML Page retrieved after making the request</returns>
        public HtmlPage load_page(bool navigateHistory)
        {
            //TODO: Exception handler same as search string
            if (_http != null)
            {
                var loadedPage = _http.MakeRequest();
                _recentHistPages.AddLast(loadedPage);
                if (!navigateHistory) _currentNode = _recentHistPages.Last;
                _db.AddWebPage<History>(loadedPage.Url, loadedPage.Title);
                return loadedPage;
            }
            else
            {
                return new HtmlPage("", "", "", "");
            }
        }

        /// <summary>
        ///     Loads page after checking format of URL passed in and returns a HTML page
        /// </summary>
        /// <param name="url"> The string of the URL to be searched </param>
        /// <param name="navigateHistory">A boolean to determine if search is navigating through history pages </param>
        /// <returns> A blank HTML Page if URL is badly formatted otherwise a filled HTML Page</returns>
        public HtmlPage search_string(string url, bool navigateHistory)
        {
            //TODO: Exception handler returns blank web page with error searching
            string valid = SanitiseInput.CheckUrl(url);
            if (SanitiseInput.CheckUrl(url) == "")
            {
                
                _http = new HttpFunctionality(url);
                CurrentPage = load_page(navigateHistory);
                _db.UpdateTable<Tabs>(_tabIndex,url,CurrentPage.Title);
                return CurrentPage;
            }
            else
            {
                return new HtmlPage(url, "", "", valid);
            }
            
        }

       /// <summary>
       ///     Navigates backwards and forwards through doubly linked list representing tabs history
       /// </summary>
       /// <param name="moveBack">Boolean that is true if moving backwards and false if moving forward</param>
       /// <returns>The HTML page next up in navigation, blank if no node</returns>
        public HtmlPage MoveThroughHistory(bool moveBack)
        {
            _currentNode = moveBack ? _currentNode.Previous : _currentNode.Next;

            if (_currentNode != null)
            {
                CurrentPage = _currentNode.Value;
                search_string(CurrentPage.Url, true);
                return _currentNode.Value;
            }

            return new HtmlPage("", "", "", "");
        }
    }
}