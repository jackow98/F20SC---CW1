using System;
using System.Collections.Generic;
using Browser;

namespace Coursework.Functionality
{
    /// <summary>
    ///     Class that tracks the information associated with a tab
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TabFunctionality
    {
        private LinkedListNode<HTMLPage> currentNode;
        public HTMLPage CurrentPage;
        public DatabaseFunctionality db;
        public HttpFunctionality Http;
        public LinkedList<HTMLPage> RecentHistPages;

        public TabFunctionality(ref DatabaseFunctionality db, HTMLPage page)
        {
            this.db = db;
            CurrentPage = page;
            RecentHistPages = new LinkedList<HTMLPage>();
            currentNode = RecentHistPages.Last;
        }

        /// <summary>
        ///     Makes HTTP request for the page currently associated with the tab
        /// </summary>
        /// <returns>The HTML Page retrieved after making the request</returns>
        public HTMLPage load_page(bool navigateHistory)
        {
            //TODO: Exception handler same as search string
            //TODO: should update tab table
            var loadedPage = Http.MakeRequest();
            RecentHistPages.AddLast(loadedPage);
            if (!navigateHistory) currentNode = RecentHistPages.Last;
            db.AddWebPage<History>(loadedPage.url, loadedPage.title);
            return loadedPage;
        }

        /// <summary>
        ///     Loads page after checking format of URL passed in and returns a HTML page
        /// </summary>
        /// <param name="url"> The string of the URL to be searched </param>
        /// <returns> A blank HTML Page if URL is badly formatted otherwise a filled HTTML Page</returns>
        public HTMLPage search_string(string url, bool navigateHistory)
        {
            //TODO: Exception handler returns blank web page with error searching
            if (HelperMethods.checkUrl(url))
            {
                
                Http = new HttpFunctionality(url);
                CurrentPage = load_page(navigateHistory);
                return CurrentPage;
            }
            
            return new HTMLPage("Enter URL", "", "", "");
        }

        public HTMLPage moveThroughHistory(bool moveBack)
        {
            if (moveBack)
                currentNode = currentNode.Previous;
            else
            //TODO: Fix next cretaing new pages
                currentNode = currentNode.Next;

            CurrentPage = currentNode.Value;
            search_string(CurrentPage.url, true);
            return currentNode.Value;
        }
    }
}