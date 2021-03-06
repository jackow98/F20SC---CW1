﻿using System.Collections.Generic;
using Browser;

namespace WindowsFormsApplication2.Functionality
{
    /// <summary>
    ///     Class to handle any browser level operations that don't involve the GUI
    /// </summary>
    public class BrowserFunctionality
    {
        public TabFunctionality CurrentTab;
        public int CurrentTabIndex;
        public readonly List<TabFunctionality> Tabs = new List<TabFunctionality>();

        /// <summary>
        ///     Loads tabs into drop down and updates current tab to last tab in list
        /// </summary>
        /// <param name="db">The database associated with the browser</param>
        public void LoadTabs(DatabaseFunctionality db)
        {
            List<Tabs> tabs = db.GetTableAsList<Tabs>();

            if (tabs.Count > 0)
            {
                int count = 0;
                foreach (var tab in tabs)
                {
                    Tabs.Add(
                        new TabFunctionality(
                            ref db,
                            new HtmlPage(tab.Url, tab.Title, "", ""),
                            count
                        )
                    );
                    count++;
                }

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
        /// <param name="index">The unique index of the tab to be retrieved</param>
        /// <returns></returns>
        public TabFunctionality GetTabFromIndex(int index) { return Tabs[index]; }
    }
}