using System;
using System.Drawing;
using System.Windows.Forms;
using Browser;
using Coursework.Functionality;

namespace Coursework.GUI
{
    /// <summary>
    ///     Class to handle changes to the GUI split into Tab and Browser interactions
    /// </summary>
    /// <typeparam name="TWebPage">The generic that implements a Web Page</typeparam>
    //TODO: Handle GUI exception cases in this class
    public partial class BrowserWindow<TWebPage> where TWebPage : IWebpage
    {
        private readonly BrowserFunctionality _browser = new BrowserFunctionality();
        private readonly DatabaseFunctionality _db;

        /// <summary>
        ///     Constructor creates a class to deal with all database operations for application and displays tabs
        /// </summary>
        public BrowserWindow()
        {
            _db = new DatabaseFunctionality();
            InitializeComponent();
            LoadTabsToGui();
        }

        #region Tab GUI Interaction
        /// <summary>
        ///     When user clicks search button, searches URL in search bar using current tab and loads web page
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(SearchBar.Text, false));
        }

        /// <summary>
        ///     When user clicks reload button, reloads page using current tab and displays newly retrieved web page
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab.load_page(false));
        }


        /// <summary>
        ///     When user clicks close tab button, removes current tab from database and GUI
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void CloseTabButton_Click(object sender, EventArgs e)
        {
            int tabToCloseIndex = TabsDropdown.SelectedIndex;

            // If closing first tab, select next tab if it exists otherwise add blank tab
            if (tabToCloseIndex == 0 && TabsDropdown.Items.Count > 1)
                TabsDropdown.SelectedIndex = 1;
            else if (tabToCloseIndex == 0 && TabsDropdown.Items.Count == 1)
                AddBlankTab();
            //If closing any other tab, select previous tab
            else
                TabsDropdown.SelectedIndex = tabToCloseIndex - 1;

            TabsDropdown.Items.RemoveAt(tabToCloseIndex);

            _browser.CloseTab(tabToCloseIndex, TabsDropdown.SelectedIndex);
            _db.CloseTab(tabToCloseIndex);
            DisplayLoadingState();
            _browser.CurrentTab.search_string(_browser.CurrentTab.CurrentPage.url, false);
        }
        #endregion
        
        #region Browser GUI interaction
        /// <summary>
        ///     When user clicks home button, loads home page associated with browser
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void HomeButton_Click(object sender, EventArgs e)
        {
            DisplayLoadingState();
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(_db.LoadHome(), false));
        }
        
        /// <summary>
        ///     When user clicks favourite button, calls function to display favourites
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void FavouritesButton_Click(object sender, EventArgs e)
        {
            DisplayTable<Favourites>("Favourites");
        }
        
        /// <summary>
        ///     When user clicks history button, loads history and details associated with them
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void HistoryButton_Click(object sender, EventArgs e)
        {
            DisplayTable<History>("Favourites");
        }
        
        /// <summary>
        ///     Loads pop up for favourites to amend details before adding to database
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void AddFavouriteButton_Click(object sender, EventArgs e)
        {
            var favourite = GUI.EditWebpagePopUp.ShowDialog(
                "Add Favourite",
                WebPageTitleLabel.Text,
                SearchBar.Text
            );
            //TODO: Input check
            _db.AddFavourite(favourite.url, favourite.title);
            MessageBox.Show("Successfully added " + favourite.title + ": " + favourite.url);
            //TODO: Add some sort of feedback for user
        }
        
        /// <summary>
        ///     When user clicks add tab button, adds a blank tab
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void AddTabButton_Click(object sender, EventArgs e)
        {
            AddBlankTab();
        }
        
        /// <summary>
        ///     On change of tab, get tab and load the associated HTML page
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void TabsDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            _browser.CurrentTabIndex = TabsDropdown.SelectedIndex;
            _browser.CurrentTab = _browser.GetTabFromIndex(_browser.CurrentTabIndex);
            SearchBar.Text = _browser.CurrentTab.CurrentPage.url;

            //TODO: Input check
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(SearchBar.Text, false));
        }
        
        /// <summary>
        ///     On click of element in table, displays context menu with options for selected element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowserPageUrlDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            int index = BrowserPageUrlDisplay.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) WebPageHandlerStrip.Show(BrowserPageUrlDisplay, new Point(0, 0));
        }
        
        /// <summary>
        ///     Loads pop up for favourites to amend details before updating in database
        /// </summary>
        /// <param name="sender">Auto generated argument by windows forms</param>
        /// <param name="e">Auto generated argument by windows forms</param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = BrowserPageUrlDisplay.SelectedIndex;

            var favourite = GUI.EditWebpagePopUp.ShowDialog(
                "Edit Favourite",
                BrowserPageTitleDisplay.Items[index].ToString(),
                BrowserPageUrlDisplay.Items[index].ToString()
            );

            //TODO: Make Generic
            _db.UpdateFavourite(index, favourite.url, favourite.title);
            DisplayTable<Favourites>("Favourites");
        }
        
        /// <summary>
        ///     Searches for URL on click of element in a table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = BrowserPageUrlDisplay.SelectedIndex;
            UpdateHtmlPageGui(_browser.CurrentTab.search_string(BrowserPageUrlDisplay.Items[index].ToString(), false));
        }
        
        /// <summary>
        ///     Deletes element in database on click of element in a table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Make generic
            var index = BrowserPageUrlDisplay.SelectedIndex;
            _db.DeleteFavoutite(index);
            DisplayTable<Favourites>("Favourites");
        }
        
        /// <summary>
        ///     Navigates to and display previous visited web page with in tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            UpdateHtmlPageGui(_browser.CurrentTab.moveThroughHistory(true));
        }

        /// <summary>
        ///     Navigates to and displays next visited webpage within tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            UpdateHtmlPageGui(_browser.CurrentTab.moveThroughHistory(false));
        }
        
        /// <summary>
        ///     Loads pop up for home to amend then updating in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var home = GUI.EditWebpagePopUp.ShowDialog(
                "Edit Home",
                null,
                _db.LoadHome()
            );

            _db.UpdateHome(home.url);
            MessageBox.Show("Successfully updated home page to" + home.url);
        }
        
        /// <summary>
        ///     On hovering over Home button, context menu with option to edit appears
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeButton_MouseHover(object sender, EventArgs e)
        {
            HomePageHandlerStrip.Show(HomeButton, new Point(0, HomeButton.Height));
        }
        #endregion
        
        #region Browser GUI Methods
        /// <summary>
        ///     Load the tabs associated with the browser to the dropdown, adds a blank if no tabs associated to browser
        /// </summary>
        private void LoadTabsToGui()
        {
            SafeExecution.UpdateGui(() =>
                {
                    TabsDropdown.Items.Clear();

                    if (_db.GetTableSize<Tabs>() == 0)
                    {
                        AddBlankTab();
                    }
                    else
                    {
                        _browser.LoadTabs(_db);
                        foreach (var tab in _browser.Tabs) TabsDropdown.Items.Add(tab.CurrentPage.title);

                        TabsDropdown.SelectedIndex = _browser.CurrentTabIndex;
                        SearchBar.Text = _browser.CurrentTab.CurrentPage.url;
                        WebPageTitleLabel.Text = _browser.CurrentTab.CurrentPage.title;
                    }
                }
            );
        }

        /// <summary>
        ///     Loads table and details associated with it to the GUI
        /// </summary>
        /// <param name="title">The title to be displayed alongside the table</param>
        /// <typeparam name="TTable">The type of the table that inherit WebPageTable</typeparam>
        private void DisplayTable<TTable>(string title) where TTable : WebPageTable
        {
            SafeExecution.UpdateGui(() =>
            {
                DisplayLoadingState();
                foreach (var element in _db.GetTableAsList<TTable>())
                {
                    BrowserPageTitleDisplay.Items.Add(element.Title);
                    BrowserPageUrlDisplay.Items.Add(element.Url);
                    BrowserPageDateDisplay.Items.Add(element.LastLoad);
                    BrowserPageVisitsDisplay.Items.Add(element.Visits);
                }

                UpdateBrowserPageGui(title);
            });

        }

        /// <summary>
        ///     Updates browser GUI to and adds tab to database
        /// </summary>
        private void AddBlankTab()
        {
            _db.AddTab();
            SearchBar.Text = "";
            DisplayLoadingState();
            UpdateHtmlPageGui(new HTMLPage("", "", "", ""));
            LoadTabsToGui();
        }
        
        /// <summary>
        ///     Updates the GUI to display a HTML page and its associated information
        /// </summary>
        /// <param name="newPage"> The HTML page to display</param>
        private void UpdateHtmlPageGui(HTMLPage newPage)
        {
            SafeExecution.UpdateGui(() =>
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

                HtmlPageDisplay.Text = newPage.rawHTML;
                StatusCodeLabel.Text = newPage.status;
                WebPageTitleLabel.Text = newPage.title;
                SearchBar.Text = newPage.url;
            });
        }
        
        /// <summary>
        ///     Updates the GUI to display information data from a Web page table
        /// </summary>
        /// <param name="title">The title of the table </param>
        private void UpdateBrowserPageGui(string title)
        {
            SafeExecution.UpdateGui(() =>
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

                WebPageTitleLabel.Text = title;
            });
        }
        
        /// <summary>
        ///     Updates the GUI to clear elements and display loading to user
        /// </summary>
        private void DisplayLoadingState()
        {
            SafeExecution.UpdateGui(() =>
            {
                StatusCodeLabel.Text = "";
                WebPageTitleLabel.Text = "Loading...";
                BrowserPageTitleDisplay.Items.Clear();
                BrowserPageUrlDisplay.Items.Clear();
                BrowserPageDateDisplay.Items.Clear();
                BrowserPageVisitsDisplay.Items.Clear();
            });
        }
        #endregion
    }
}