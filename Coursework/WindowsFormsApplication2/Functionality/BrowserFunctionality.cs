using System;
using System.Collections.Generic;
using Browser;

namespace Coursework.Functionality
{
    public class BrowserFunctionality
    {
        //TODO: All need default values
        public TabFunctionality CurrentTab;
        public int CurrentTabIndex;
        public List<TabFunctionality> Tabs = new List<TabFunctionality>();

        /// <summary>
        ///     Loads tabs into drop down and updates current tab to last tab in list
        /// </summary>
        /// <param name="db">The database associated with the browser</param>
        public void LoadTabs(DatabaseFunctionality db)
        {
            List<Tabs> tabs = db.GetTableAsList<Tabs>();

            if (tabs.Count > 0)
            {
                foreach (var tab in tabs)
                    Tabs.Add(
                        new TabFunctionality(
                            ref db,
                            new HTMLPage(tab.Url, tab.Title, "", "")
                        )
                    );
                
                CurrentTabIndex = db.GetTableSize<Tabs>() - 1;
                CurrentTab = Tabs[CurrentTabIndex];
            }
        }

        /// <summary>
        ///     Closes a tab and calls removes from database
        /// </summary>
        /// <param name="tabToCloseIndex">The unique index of the tab to be closed</param>
        /// <param name="newTabIndex">The index of the new tab to be selected</param>
        public void CloseTab(int tabToCloseIndex, int newTabIndex)
        {
            CurrentTabIndex = newTabIndex;
            CurrentTab = Tabs[newTabIndex];
            Tabs.RemoveAt(tabToCloseIndex);
        }

        /// <summary>
        ///     Return tab stored at provided index
        /// </summary>
        /// <param name="index">The unique index of the tab to be retrived</param>
        /// <returns></returns>
        public TabFunctionality GetTabFromIndex(int index) { return Tabs[index]; }
    }
}