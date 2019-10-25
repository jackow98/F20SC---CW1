using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Browser
{
    
    public partial class BrowserWindow <T> where T : IWebpage
    {
        public DatabaseFunctionality Db;
        public TabFunctionality<T> currentTab;
        
        public BrowserWindow()
        {
            Db =  new DatabaseFunctionality();
            InitializeComponent();
            loadTabsToGui();
        }

        private void loadTabsToGui()
        {
            foreach (var tab in Db.TabTable)
            {
                TabsDropdown.Items.Add(tab.title);
                SearchBar.Text = tab.URL;
                WebPageTitleLabel.Text = tab.title;
            }

            TabsDropdown.SelectedIndex = 0;
            currentTab =  new TabFunctionality<T>(this, false);
            HTMLPage defaultTabPage = currentTab.search_string(this.SearchBar.Text);
            UpdateHtmlPageGui(defaultTabPage);
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
            //TODO: Can this be better handled
            SearchBar.Text = homePage.url;
            UpdateHtmlPageGui(homePage);
        }

        private void FavouritesButton_Click(object sender, EventArgs e)
        {
            LoadingState();
            int count = 0;
            foreach (var favourite in Db.FavouriteTable)
            {
                this.BrowserPageTitleDisplay.Items.Add(favourite.name);
                this.BrowserPageUrlDisplay.Items.Add(favourite.URL);
                this.BrowserPageDateDisplay.Items.Add(favourite.lastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(favourite.visits);
            }
            
            UpdateBrowserPageGui("Favourites");
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            LoadingState();
            int count = 0;
            foreach (var favourite in Db.HistoryTable)
            {
                this.BrowserPageUrlDisplay.Items.Add(favourite.URL);
                this.BrowserPageDateDisplay.Items.Add(favourite.lastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(favourite.visits);
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
            
            Db.AddFavourite(favourite.url, favourite.title);
            //TODO: Add some sort of feedback for user
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

        private void LoadingState()
        {;
            StatusCodeLabel.Text =  "";
            WebPageTitleLabel.Text =  "Loading...";
            BrowserPageTitleDisplay.Items.Clear();
            BrowserPageUrlDisplay.Items.Clear();
            BrowserPageDateDisplay.Items.Clear();
            BrowserPageVisitsDisplay.Items.Clear();
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
