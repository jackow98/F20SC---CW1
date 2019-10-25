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
            LoadingState();
            //TODO: Handle exceptions
            HTMLPage searchedPage = currentTab.search_string(this.SearchBar.Text);
            UpdateHtmlPageGui(searchedPage);
        }

        private void CloseTabButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            LoadingState();
            HTMLPage reloadedPage = currentTab.reload_page();
            UpdateHtmlPageGui(reloadedPage);

        }
        
        //Browser GUI 
        private void HomeButton_Click(object sender, EventArgs e)
        {
            LoadingState();
            HTMLPage homePage = currentTab.search_string(Db.HomeURL);
            UpdateHtmlPageGui(homePage);
        }

        private void FavouritesButton_Click(object sender, EventArgs e)
        {
            LoadingState();
            int count = 0;
            foreach (var favourite in Db.FavouriteTable)
            {
                this.BrowserPageUrlDisplay.Items.Add(favourite.URL);
                this.BrowserPageDateDisplay.Items.Add(favourite.lastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(favourite.visits);
            }

            UpdateBrowserPageGui("Favourites");
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

        private void UpdateHtmlPageGui(HTMLPage newPage)
        {
            DisplayTypeDropdown.Visible = true;
            AddFavouriteButton.Visible = true;
            HtmlPageDisplay.Visible = true;
            
            BrowswerPageUrlLabel.Visible = false;
            BrowserPageUrlDisplay.Visible = false;
            BrowserPageDateDisplay.Visible = false;
            BrowserPageDateLabel.Visible = false;
            BrowserPageVisitsDisplay.Visible = false;
            BrowserPageVisitsLabel.Visible = false;
            
            HtmlPageDisplay.Text =  newPage.rawHTML;
            StatusCodeLabel.Text =  newPage.status;
            WebPageTitleLabel.Text =  newPage.title;
            
        }
        
        private void UpdateBrowserPageGui(string title)
        {
            BrowswerPageUrlLabel.Visible = true;
            BrowserPageUrlDisplay.Visible = true;
            BrowserPageDateDisplay.Visible = true;
            BrowserPageDateLabel.Visible = true;
            BrowserPageVisitsDisplay.Visible = true;
            BrowserPageVisitsLabel.Visible = true;
            
            DisplayTypeDropdown.Visible = false;
            AddFavouriteButton.Visible = false;
            HtmlPageDisplay.Visible = false;
            
            WebPageTitleLabel.Text =  title;
        }

        private void LoadingState()
        {;
            StatusCodeLabel.Text =  "";
            WebPageTitleLabel.Text =  "Loading...";
            BrowserPageUrlDisplay.Items.Clear();
            BrowserPageDateDisplay.Items.Clear();
            BrowserPageVisitsDisplay.Items.Clear();
        }

    }
}
