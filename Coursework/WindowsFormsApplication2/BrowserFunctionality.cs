using System.Collections.Generic;
using System.Linq;

namespace Browser
{
    public class BrowserFunctionality
    {
        public readonly List<TabFunctionality<HTMLPage>> Tabs = new List<TabFunctionality<HTMLPage>>();
        public int CurrentTabIndex;
        public TabFunctionality<HTMLPage> CurrentTab;
        
        public void LoadTabs(DatabaseFunctionality db)
        {
            foreach (var tab in db.TabsTable)
            {    
                Tabs.Add(
                    new TabFunctionality<HTMLPage>(
                        new HTMLPage(tab.Url, tab.Title, "", "")
                        )
                    );
            }
            
            CurrentTabIndex = db.TabsTable.Count() - 1;
            CurrentTab = Tabs[CurrentTabIndex];
        }

        public TabFunctionality<HTMLPage> GetTabFromIndex(int index)
        {
            return Tabs[index];   
        }
    }
}