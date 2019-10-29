using System.Collections.Generic;
using Browser;

namespace Coursework.Functionality
{
    public class BrowserFunctionality
    {
        //TODO: All need default values
        public TabFunctionality<HTMLPage> CurrentTab;
        public int CurrentTabIndex;
        public List<TabFunctionality<HTMLPage>> Tabs = new List<TabFunctionality<HTMLPage>>();

        /// <summary>
        ///     Loads tabs into
        /// </summary>
        /// <param name="db"></param>
        public void LoadTabs(DatabaseFunctionality db)
        {
            foreach (var tab in db.getTableAsList<Tabs>())
                Tabs.Add(
                    new TabFunctionality<HTMLPage>(
                        ref db,
                        new HTMLPage(tab.Url, tab.Title, "", "")
                    )
                );


            CurrentTabIndex = db.getTableSize<Tabs>() - 1;
            CurrentTab = Tabs[CurrentTabIndex];
        }

        public void CloseTab(int tabToCloseIndex, int newTabIndex)
        {
            //TODO: Exception for functionality returning void
            CurrentTabIndex = newTabIndex;
            CurrentTab = Tabs[newTabIndex];
            Tabs.RemoveAt(tabToCloseIndex);
        }

        public TabFunctionality<HTMLPage> GetTabFromIndex(int index)
        {
            return Tabs[index];
        }
    }
}