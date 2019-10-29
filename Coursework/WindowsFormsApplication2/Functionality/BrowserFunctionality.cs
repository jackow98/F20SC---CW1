using System.Collections.Generic;
using System.Linq;
using Browser;

namespace WindowsFormsApplication2.Functionality
{
    public class BrowserFunctionality
    {
        public List<TabFunctionality<HTMLPage>> Tabs = new List<TabFunctionality<HTMLPage>>();
        public int CurrentTabIndex;
        public TabFunctionality<HTMLPage> CurrentTab;

        /// <summary>
        /// Loads tabs into 
        /// </summary>
        /// <param name="db"></param>
        public void LoadTabs(DatabaseFunctionality db)
        {
            foreach (var tab in db.getTableAsList<Tabs>())
            {    
                Tabs.Add(
                    new TabFunctionality<HTMLPage>(
                        ref db,
                        new HTMLPage(tab.Url, tab.Title, "", "")
                        )
                    );
            }
            
            CurrentTabIndex = db.getTableSize<Tabs>() - 1;
            CurrentTab = Tabs[CurrentTabIndex];
        }

        public void CloseTab(int tabToCloseIndex, int newTabIndex)
        {
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