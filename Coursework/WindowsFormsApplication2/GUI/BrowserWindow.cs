using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication2.Functionality;
using Browser;
using System.Drawing;

namespace WindowsFormsApplication2.GUI
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
            UpdateHtmlPageGui(_browser.CurrentTab .search_string(this.SearchBar.Text, false));
        }
        
        /// <summary>
        /// When user clicks reload button, reloads page using current tab and displays newly retrieved web page
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab.load_page(false));
        }


        /// <summary>
        /// When user clicks close tab button, removes current tab from database and GUI 
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void CloseTabButton_Click(object sender, EventArgs e)
        {
            int tabToCloseIndex = TabsDropdown.SelectedIndex;
            
            if (tabToCloseIndex == 0 && TabsDropdown.Items.Count > 1)
            {
                TabsDropdown.SelectedIndex = 1;
            }else if (tabToCloseIndex == 0 && TabsDropdown.Items.Count == 1)
            {
                AddBlankTab();
            }
            else
            {
                TabsDropdown.SelectedIndex = tabToCloseIndex - 1;    
            }
            
            TabsDropdown.Items.RemoveAt(tabToCloseIndex);
            
            _browser.CloseTab(tabToCloseIndex, TabsDropdown.SelectedIndex);
            _db.CloseTab(tabToCloseIndex);
            DisplayLoadingState();
            _browser.CurrentTab.search_string(_browser.CurrentTab.CurrentPage.url, false);
        }

        //Browser GUI 
        
        /// <summary>
        /// Load the tabs associated with the browser to the dropdown, loads blank if no tabs associated to browser
        /// </summary>
        private void LoadTabsToGui()
        {
            TabsDropdown.Items.Clear();

            //todo: Better error handling
            if (_db.getTableSize<Tabs>() == 0)
            {
                AddBlankTab();
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
        
        /// <summary>
        /// When user clicks home button, loads home page associated with browser
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void HomeButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(_db.LoadHome(), false));
        }

        /// <summary>
        /// When user clicks favourite button, loads favourites and details associated with them
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void FavouritesButton_Click(object sender, EventArgs e)
        {
            DisplayFavourites();
        }

        private void DisplayFavourites()
        {
            DisplayLoadingState();
            foreach (var favourite in _db.getTableAsList<Favourites>())
            {
                this.BrowserPageTitleDisplay.Items.Add(favourite.Title);
                this.BrowserPageUrlDisplay.Items.Add(favourite.Url);
                this.BrowserPageDateDisplay.Items.Add(favourite.LastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(favourite.Visits);
            }
            UpdateBrowserPageGui("Favourites");
        }
        
        private void DisplayHistory()
        {
            DisplayLoadingState();
            foreach (var history in _db.getTableAsList<History>())
            {
                this.BrowserPageTitleDisplay.Items.Add(history.Title);
                this.BrowserPageUrlDisplay.Items.Add(history.Url);
                this.BrowserPageDateDisplay.Items.Add(history.LastLoad);
                this.BrowserPageVisitsDisplay.Items.Add(history.Visits);
            }
            UpdateBrowserPageGui("History");
        }
        /// <summary>
        /// When user clicks history button, loads history and details associated with them
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void HistoryButton_Click(object sender, EventArgs e)
        {
            DisplayHistory();
        }
        
        /// <summary>
        /// Loads a pop up prompting user to make any changes to favourite before adding to database
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void AddFavouriteButton_Click(object sender, EventArgs e)
        {
            //TODO: Handle cases for no HTML, need to load page, 404 etc.
            HTMLPage favourite = EditFavouritePopUp.ShowDialog(
                "Add Favourite", 
                WebPageTitleLabel.Text, 
                SearchBar.Text
                );
            
            _db.AddFavourite(favourite.url, favourite.title);
            //TODO: Add some sort of feedback for user
        }
        
        /// <summary>
        /// When user clicks add tab button, adds a blank tab
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void AddTabButton_Click(object sender, EventArgs e)
        {
            AddBlankTab();
        }
        
        /// <summary>
        /// On change of tab, get tab and load the associated HTML page
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void TabsDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabFunctionality<HTMLPage> tab = _browser.GetTabFromIndex(TabsDropdown.SelectedIndex);
            SearchBar.Text = tab.CurrentPage.url;
            
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(this.SearchBar.Text, false));
        }

        /// <summary>
        /// Updates browser GUI to and adds tab to database
        /// </summary>
        private void AddBlankTab()
        {
            _db.AddTab();
            SearchBar.Text = "";
            DisplayLoadingState();
            UpdateHtmlPageGui(new HTMLPage("","","",""));
            LoadTabsToGui();
        }
        
        /// <summary>
        /// Updates the GUI to display a HTML page and its associated information
        /// </summary>
        /// <param name="newPage"> The HTML page to display</param>
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
            SearchBar.Text = newPage.url;
        }
        
        /// <summary>
        /// Updates the GUI to display information data from a Web page table
        /// </summary>
        /// <param name="title">The title of the table </param>
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

        /// <summary>
        /// Updates the GUI to clear elements and display loading to user
        /// </summary>
        private void DisplayLoadingState()
        {;
            StatusCodeLabel.Text =  "";
            WebPageTitleLabel.Text =  "Loading...";
            BrowserPageTitleDisplay.Items.Clear();
            BrowserPageUrlDisplay.Items.Clear();
            BrowserPageDateDisplay.Items.Clear();
            BrowserPageVisitsDisplay.Items.Clear();
        }
        
        private void BrowserPageUrlDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.BrowserPageUrlDisplay.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                UpdateHtmlPageGui(_browser.CurrentTab.search_string(BrowserPageUrlDisplay.Items[index].ToString(), false));
            }
        }

        private void BrowserPageUrlDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.BrowserPageUrlDisplay.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                FavouriteHandlerStrip.Show(BrowserPageUrlDisplay, new Point(0, 0));    
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = BrowserPageUrlDisplay.SelectedIndex;
            
            HTMLPage favourite = EditFavouritePopUp.ShowDialog(
                "Edit Favourite", 
                BrowserPageTitleDisplay.Items[index].ToString(), 
                BrowserPageUrlDisplay.Items[index].ToString()
            );
            
            _db.UpdateFavourite(index, favourite.url, favourite.title);
            DisplayFavourites();
        }
        
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = BrowserPageUrlDisplay.SelectedIndex;
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(BrowserPageUrlDisplay.Items[index].ToString(),false));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            UpdateHtmlPageGui(_browser.CurrentTab.moveThroughHistory(true));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            
            UpdateHtmlPageGui(_browser.CurrentTab.moveThroughHistory(false));
        }

        private void HomeButton_Hover(object sender, EventArgs e)
        {
            //TODO: Implement correct functionality
            //FavouriteHandlerStrip.Show(HomeButton, new Point(0, HomeButton.Height));
            
            HTMLPage home = EditFavouritePopUp.ShowDialog(
                "Edit Home",
                _db.LoadHome()
            );
            
            _db.UpdateHome(home.url);
        }
    }
}
