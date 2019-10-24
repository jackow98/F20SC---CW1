using System;
using System.Linq;
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
            //TODO: Handle exceptions
            HTMLPage searchedPage = currentTab.search_string(this.SearchBar.Text);
            updateHtmlGUI(searchedPage);
        }

        private void CloseTabButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            HTMLPage reloadedPage = currentTab.reload_page();
            updateHtmlGUI(reloadedPage);

        }
        
        //Browser GUI 

        private void HomeButton_Click(object sender, EventArgs e)
        {
            HTMLPage homePage = null;
            
            foreach (var home in Db.HomeTable)
            {
                var msg = MessageBox.Show(home.URL);
                homePage = currentTab.search_string(home.URL);
                break;
            }
            
            updateHtmlGUI(homePage);
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

        private void updateHtmlGUI(HTMLPage newPage)
        {
            HTMLPageDisplay.Text =  newPage.rawHTML;
            StatusCodeLabel.Text =  newPage.status;
            WebPageTitleLabel.Text =  newPage.title;
        }
    }
}
