using System;
using System.Windows.Forms;

namespace Browser
{
    
    public partial class BrowserWindow <T> where T : IWebpage
    {
        //TODO: Refactor so only used DatabaseFunctionality
        //private WebPages<T> history; 
        //private WebPages<T> favourites; 
        //private WebPages<T> tabs;
        //private HTMLPage Home;
        public DatabaseFunctionality Db;
        public TabFunctionality<T> currentTab;
        
        public BrowserWindow()
        {
            Db =  new DatabaseFunctionality();
            currentTab =  new TabFunctionality<T>(this, true);
            InitializeComponent();
        }
        
        //Tab GUI 
        private void SearchButton_Click(object sender, EventArgs e)
        {
            HTMLPage page = currentTab.search_string(this.SearchBar.Text);
            HTMLPageDisplay.Text =  page.rawHTML;
        }

        private void CloseTabButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        //Browser GUI 

        private void HomeButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void FavouritesButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AddTabButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DisplayTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
