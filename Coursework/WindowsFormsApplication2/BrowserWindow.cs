using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>
    /// Class to handle changes to the GUI split into Tab and Browser interactions 
    /// </summary>
    /// <typeparam name="TWebPage">The generic that implements a Web Page</typeparam>
    //TODO: Handle GUI exception cases in this class
    public partial class BrowserWindow <TWebPage> where TWebPage : IWebpage
    {
        private readonly DatabaseFunctionality _db;
        private BrowserFunctionality _browser = new BrowserFunctionality();

        public BrowserWindow()
        {
            _db =  new DatabaseFunctionality();
            InitializeComponent();
            LoadTabsToGui();
        }

        //Tab GUI 
        
        /// <summary>
        /// When user clicks search button, searches URL in search bar using current tab and loads web page
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab .search_string(this.SearchBar.Text));
        }
        
        /// <summary>
        /// When user clicks reload button, reloads page using current tab and displays newly retrieved web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab.load_page());
        }


        //TODO: Implement
        private void CloseTabButton_Click(object sender, EventArgs e)
        {
            _db.DeleteTab(TabsDropdown.Text);
            LoadTabsToGui();
        }

        //Browser GUI 
        
        //TODO: Refactor this accordingly
        private void LoadTabsToGui()
        {
            TabsDropdown.Items.Clear();

            //todo: Better error handling
            if (!_db.TabsTable.Any())
            {
                AddBlankTabToGui();
            }
            else
            {
                _browser.LoadTabs(_db);
                foreach (var tab in _browser.Tabs)
                {
                    TabsDropdown.Items.Add(tab.CurrentPage.title);
                }
                TabsDropdown.SelectedIndex = _browser.CurrentTabIndex;
                SearchBar.Text = _browser.CurrentTab.CurrentPage.url;
                WebPageTitleLabel.Text = _browser.CurrentTab.CurrentPage.title;
            }
        }
        
        private void HomeButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            HTMLPage homePage = _browser.CurrentTab.search_string(_db.HomeUrl);
            //TODO: Can this be better handled
            SearchBar.Text = homePage.url;
            UpdateHtmlPageGui(homePage);
        }

        private void FavouritesButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            int count = 0;
            foreach (var favourite in _db.FavouritesTable)
            {
                this.BrowserPageTitleDisplay.Items.Add(favourite.Title);
                this.BrowserPageUrlDisplay.Items.Add(favourite.Url);
                this.BrowserPageDateDisplay.Items.Add(favourite.LastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(favourite.Visits);
            }
            
            UpdateBrowserPageGui("Favourites");
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            int count = 0;
            foreach (var favourite in _db.HistoryTable)
            {
                this.BrowserPageUrlDisplay.Items.Add(favourite.Url);
                this.BrowserPageDateDisplay.Items.Add(favourite.LastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(favourite.Visits);
            }

            UpdateBrowserPageGui("History");
        }

        private void AddFavouriteButton_Click(object sender, EventArgs e)
        {
            //TODO: Handle cases for no HTML, need to load page, 404 etc.
            HTMLPage favourite = AddFavouritePopUp.ShowDialog(
                "Add Favourite", 
                WebPageTitleLabel.Text, 
                SearchBar.Text
                );
            
            _db.AddFavourite(favourite.url, favourite.title);
            //TODO: Add some sort of feedback for user
        }
        
        private void AddTabButton_Click(object sender, EventArgs e)
        {
            AddBlankTabToGui();
        }

        private void AddBlankTabToGui()
        {
            _db.AddTab();
            SearchBar.Text = "";
            DisplayLoadingState();
            UpdateHtmlPageGui(new HTMLPage("","","",""));
            LoadTabsToGui();
        }
        
        private void UpdateHtmlPageGui(HTMLPage newPage)
        {
            DisplayTypeDropdown.Visible = true;
            AddFavouriteButton.Visible = true;
            HtmlPageDisplay.Visible = true;

            BrowserPageTitleDisplay.Visible = false;
            BrowserPageTitleDisplay.Visible = false;
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
            BrowserPageTitleDisplay.Visible = true;
            BrowserPageTitleDisplay.Visible = true;
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

        private void DisplayLoadingState()
        {;
            StatusCodeLabel.Text =  "";
            WebPageTitleLabel.Text =  "Loading...";
            BrowserPageTitleDisplay.Items.Clear();
            BrowserPageUrlDisplay.Items.Clear();
            BrowserPageDateDisplay.Items.Clear();
            BrowserPageVisitsDisplay.Items.Clear();
        }

        private void TabsDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabFunctionality<HTMLPage> tab = _browser.GetTabFromIndex(TabsDropdown.SelectedIndex);
            SearchBar.Text = tab.CurrentPage.url;
            
            HTMLPage defaultTabPage = _browser.CurrentTab.search_string(this.SearchBar.Text);
            UpdateHtmlPageGui(defaultTabPage);
        }
    }
    
    public static class AddFavouritePopUp
    {
        public static HTMLPage ShowDialog(string caption, string nameDisplayText="", string urlDisplayText="")
        {
            Form sddFavouritePopUp = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label nameLabel = new Label() { Left = 50, Top=50, Text="Name: " , Width=50};
            Label urlLabel = new Label() { Left = 50, Top=80, Text="URL: ", Width=50};
            TextBox nameTextBox = new TextBox() { Left = 110, Top=50, Width=350, Text = nameDisplayText};
            TextBox urlTextBox = new TextBox() { Left = 110, Top=80, Width=350, Text = urlDisplayText};
            Button confirmation = new Button() { Text = "Add", Left=350, Width=100, Top=130, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { sddFavouritePopUp.Close(); };
            sddFavouritePopUp.Controls.Add(nameLabel);
            sddFavouritePopUp.Controls.Add(urlLabel);
            sddFavouritePopUp.Controls.Add(confirmation);
            sddFavouritePopUp.Controls.Add(nameTextBox);
            sddFavouritePopUp.Controls.Add(urlTextBox);
            sddFavouritePopUp.AcceptButton = confirmation;

            return sddFavouritePopUp.ShowDialog() == DialogResult.OK ? 
                new HTMLPage(urlTextBox.Text, nameTextBox.Text,"","")
                : null;
        }
    }
}
