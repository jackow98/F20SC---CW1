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
        ///     Loads tabs into
        /// </summary>
        /// <param name="db"></param>
        public void LoadTabs(DatabaseFunctionality db)
        {
            foreach (var tab in db.GetTableAsList<Tabs>())
                Tabs.Add(
                    new TabFunctionality(
                        ref db,
                        new HTMLPage(tab.Url, tab.Title, "", "")
                    )
                );


            CurrentTabIndex = db.GetTableSize<Tabs>() - 1;
            CurrentTab = Tabs[CurrentTabIndex];
        }

        public void CloseTab(int tabToCloseIndex, int newTabIndex)
        {
            //TODO: Exception for functionality returning void
            CurrentTabIndex = newTabIndex;
            CurrentTab = Tabs[newTabIndex];
            Tabs.RemoveAt(tabToCloseIndex);
        }

        public TabFunctionality GetTabFromIndex(int index)
        {
            return Tabs[index];
        }
    }
}