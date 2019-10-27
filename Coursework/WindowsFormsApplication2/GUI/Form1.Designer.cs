using System.Windows.Forms;
using Browser;

namespace WindowsFormsApplication2.GUI
{
    partial class BrowserWindow<TWebPage> : Form  where TWebPage : IWebpage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.HomeButton = new System.Windows.Forms.Button();
            this.FavouritesButton = new System.Windows.Forms.Button();
            this.HistoryButton = new System.Windows.Forms.Button();
            this.TabsDropdown = new System.Windows.Forms.ComboBox();
            this.AddTabButton = new System.Windows.Forms.Button();
            this.CloseTabButton = new System.Windows.Forms.Button();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.WebPageTitleLabel = new System.Windows.Forms.Label();
            this.StatusCodeLabel = new System.Windows.Forms.Label();
            this.DisplayTypeDropdown = new System.Windows.Forms.ComboBox();
            this.AddFavouriteButton = new System.Windows.Forms.Button();
            this.BrowserPageUrlDisplay = new System.Windows.Forms.ListBox();
            this.BrowserPageDateDisplay = new System.Windows.Forms.ListBox();
            this.BrowserPageVisitsDisplay = new System.Windows.Forms.ListBox();
            this.BrowswerPageUrlLabel = new System.Windows.Forms.Label();
            this.BrowserPageDateLabel = new System.Windows.Forms.Label();
            this.BrowserPageVisitsLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.BrowserPageTitleLabel = new System.Windows.Forms.Label();
            this.BrowserPageTitleDisplay = new System.Windows.Forms.ListBox();
            this.HtmlPageDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SearchButton.Location = new System.Drawing.Point(557, 64);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(74, 35);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(159, 68);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(388, 27);
            this.SearchBar.TabIndex = 5;
            this.SearchBar.Text = "Enter URL";
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(78, 64);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(73, 35);
            this.HomeButton.TabIndex = 7;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // FavouritesButton
            // 
            this.FavouritesButton.Location = new System.Drawing.Point(777, 64);
            this.FavouritesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FavouritesButton.Name = "FavouritesButton";
            this.FavouritesButton.Size = new System.Drawing.Size(85, 35);
            this.FavouritesButton.TabIndex = 8;
            this.FavouritesButton.Text = "Favourites";
            this.FavouritesButton.UseVisualStyleBackColor = true;
            this.FavouritesButton.Click += new System.EventHandler(this.FavouritesButton_Click);
            // 
            // HistoryButton
            // 
            this.HistoryButton.Location = new System.Drawing.Point(864, 64);
            this.HistoryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(85, 35);
            this.HistoryButton.TabIndex = 9;
            this.HistoryButton.Text = "History";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // TabsDropdown
            // 
            this.TabsDropdown.FormattingEnabled = true;
            this.TabsDropdown.Location = new System.Drawing.Point(5, 1);
            this.TabsDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabsDropdown.Name = "TabsDropdown";
            this.TabsDropdown.Size = new System.Drawing.Size(773, 28);
            this.TabsDropdown.TabIndex = 10;
            this.TabsDropdown.Text = "CurrentTab";
            this.TabsDropdown.SelectedIndexChanged += new System.EventHandler(this.TabsDropdown_SelectedIndexChanged);
            // 
            // AddTabButton
            // 
            this.AddTabButton.Location = new System.Drawing.Point(786, 1);
            this.AddTabButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddTabButton.Name = "AddTabButton";
            this.AddTabButton.Size = new System.Drawing.Size(78, 31);
            this.AddTabButton.TabIndex = 11;
            this.AddTabButton.Text = "Add Tab";
            this.AddTabButton.UseVisualStyleBackColor = true;
            this.AddTabButton.Click += new System.EventHandler(this.AddTabButton_Click);
            // 
            // CloseTabButton
            // 
            this.CloseTabButton.Location = new System.Drawing.Point(871, 1);
            this.CloseTabButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseTabButton.Name = "CloseTabButton";
            this.CloseTabButton.Size = new System.Drawing.Size(78, 31);
            this.CloseTabButton.TabIndex = 12;
            this.CloseTabButton.Text = "Close Tab";
            this.CloseTabButton.UseVisualStyleBackColor = true;
            this.CloseTabButton.Click += new System.EventHandler(this.CloseTabButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Location = new System.Drawing.Point(5, 64);
            this.ReloadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(67, 35);
            this.ReloadButton.TabIndex = 13;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // WebPageTitleLabel
            // 
            this.WebPageTitleLabel.Location = new System.Drawing.Point(6, 181);
            this.WebPageTitleLabel.Name = "WebPageTitleLabel";
            this.WebPageTitleLabel.Size = new System.Drawing.Size(613, 42);
            this.WebPageTitleLabel.TabIndex = 14;
            // 
            // StatusCodeLabel
            // 
            this.StatusCodeLabel.Location = new System.Drawing.Point(625, 181);
            this.StatusCodeLabel.Name = "StatusCodeLabel";
            this.StatusCodeLabel.Size = new System.Drawing.Size(152, 42);
            this.StatusCodeLabel.TabIndex = 15;
            // 
            // DisplayTypeDropdown
            // 
            this.DisplayTypeDropdown.FormattingEnabled = true;
            this.DisplayTypeDropdown.Location = new System.Drawing.Point(777, 178);
            this.DisplayTypeDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisplayTypeDropdown.Name = "DisplayTypeDropdown";
            this.DisplayTypeDropdown.Size = new System.Drawing.Size(182, 28);
            this.DisplayTypeDropdown.TabIndex = 16;
            this.DisplayTypeDropdown.Text = "Raw HTML";
            this.DisplayTypeDropdown.Visible = false;
            // 
            // AddFavouriteButton
            // 
            this.AddFavouriteButton.Location = new System.Drawing.Point(819, 684);
            this.AddFavouriteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddFavouriteButton.Name = "AddFavouriteButton";
            this.AddFavouriteButton.Size = new System.Drawing.Size(129, 32);
            this.AddFavouriteButton.TabIndex = 17;
            this.AddFavouriteButton.Text = "Add Favourite";
            this.AddFavouriteButton.UseVisualStyleBackColor = true;
            this.AddFavouriteButton.Click += new System.EventHandler(this.AddFavouriteButton_Click);
            // 
            // BrowserPageUrlDisplay
            // 
            this.BrowserPageUrlDisplay.FormattingEnabled = true;
            this.BrowserPageUrlDisplay.ItemHeight = 20;
            this.BrowserPageUrlDisplay.Location = new System.Drawing.Point(223, 262);
            this.BrowserPageUrlDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowserPageUrlDisplay.Name = "BrowserPageUrlDisplay";
            this.BrowserPageUrlDisplay.Size = new System.Drawing.Size(416, 404);
            this.BrowserPageUrlDisplay.TabIndex = 18;
            this.BrowserPageUrlDisplay.MouseDoubleClick += new MouseEventHandler(this.BrowserPageUrlDisplay_MouseDoubleClick);
            // 
            // BrowserPageDateDisplay
            // 
            this.BrowserPageDateDisplay.FormattingEnabled = true;
            this.BrowserPageDateDisplay.ItemHeight = 20;
            this.BrowserPageDateDisplay.Location = new System.Drawing.Point(645, 262);
            this.BrowserPageDateDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowserPageDateDisplay.Name = "BrowserPageDateDisplay";
            this.BrowserPageDateDisplay.Size = new System.Drawing.Size(167, 404);
            this.BrowserPageDateDisplay.TabIndex = 19;
            // 
            // BrowserPageVisitsDisplay
            // 
            this.BrowserPageVisitsDisplay.FormattingEnabled = true;
            this.BrowserPageVisitsDisplay.ItemHeight = 20;
            this.BrowserPageVisitsDisplay.Location = new System.Drawing.Point(824, 262);
            this.BrowserPageVisitsDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowserPageVisitsDisplay.Name = "BrowserPageVisitsDisplay";
            this.BrowserPageVisitsDisplay.Size = new System.Drawing.Size(126, 404);
            this.BrowserPageVisitsDisplay.TabIndex = 20;
            // 
            // BrowswerPageUrlLabel
            // 
            this.BrowswerPageUrlLabel.Location = new System.Drawing.Point(223, 232);
            this.BrowswerPageUrlLabel.Name = "BrowswerPageUrlLabel";
            this.BrowswerPageUrlLabel.Size = new System.Drawing.Size(192, 28);
            this.BrowswerPageUrlLabel.TabIndex = 21;
            this.BrowswerPageUrlLabel.Text = "URL";
            // 
            // BrowserPageDateLabel
            // 
            this.BrowserPageDateLabel.Location = new System.Drawing.Point(645, 232);
            this.BrowserPageDateLabel.Name = "BrowserPageDateLabel";
            this.BrowserPageDateLabel.Size = new System.Drawing.Size(128, 28);
            this.BrowserPageDateLabel.TabIndex = 22;
            this.BrowserPageDateLabel.Text = "Date";
            // 
            // BrowserPageVisitsLabel
            // 
            this.BrowserPageVisitsLabel.Location = new System.Drawing.Point(825, 232);
            this.BrowserPageVisitsLabel.Name = "BrowserPageVisitsLabel";
            this.BrowserPageVisitsLabel.Size = new System.Drawing.Size(87, 22);
            this.BrowserPageVisitsLabel.TabIndex = 23;
            this.BrowserPageVisitsLabel.Text = "Visits";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(704, 64);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(54, 35);
            this.NextButton.TabIndex = 25;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(642, 64);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(56, 35);
            this.BackButton.TabIndex = 26;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // BrowserPageTitleLabel
            // 
            this.BrowserPageTitleLabel.Location = new System.Drawing.Point(14, 232);
            this.BrowserPageTitleLabel.Name = "BrowserPageTitleLabel";
            this.BrowserPageTitleLabel.Size = new System.Drawing.Size(166, 28);
            this.BrowserPageTitleLabel.TabIndex = 27;
            this.BrowserPageTitleLabel.Text = "Title";
            // 
            // BrowserPageTitleDisplay
            // 
            this.BrowserPageTitleDisplay.FormattingEnabled = true;
            this.BrowserPageTitleDisplay.ItemHeight = 20;
            this.BrowserPageTitleDisplay.Location = new System.Drawing.Point(14, 262);
            this.BrowserPageTitleDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowserPageTitleDisplay.Name = "BrowserPageTitleDisplay";
            this.BrowserPageTitleDisplay.Size = new System.Drawing.Size(196, 404);
            this.BrowserPageTitleDisplay.TabIndex = 28;
            // 
            // HtmlPageDisplay
            // 
            this.HtmlPageDisplay.Location = new System.Drawing.Point(12, 218);
            this.HtmlPageDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HtmlPageDisplay.Multiline = true;
            this.HtmlPageDisplay.Name = "HtmlPageDisplay";
            this.HtmlPageDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HtmlPageDisplay.Size = new System.Drawing.Size(941, 448);
            this.HtmlPageDisplay.TabIndex = 29;
            // 
            // BrowserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 721);
            this.Controls.Add(this.HtmlPageDisplay);
            this.Controls.Add(this.BrowserPageTitleDisplay);
            this.Controls.Add(this.BrowserPageTitleLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.BrowserPageVisitsLabel);
            this.Controls.Add(this.BrowserPageDateLabel);
            this.Controls.Add(this.BrowswerPageUrlLabel);
            this.Controls.Add(this.BrowserPageVisitsDisplay);
            this.Controls.Add(this.BrowserPageDateDisplay);
            this.Controls.Add(this.BrowserPageUrlDisplay);
            this.Controls.Add(this.AddFavouriteButton);
            this.Controls.Add(this.DisplayTypeDropdown);
            this.Controls.Add(this.StatusCodeLabel);
            this.Controls.Add(this.WebPageTitleLabel);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.CloseTabButton);
            this.Controls.Add(this.AddTabButton);
            this.Controls.Add(this.TabsDropdown);
            this.Controls.Add(this.HistoryButton);
            this.Controls.Add(this.FavouritesButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.SearchButton);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "BrowserWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button HistoryButton;
        private System.Windows.Forms.Button FavouritesButton;
        private System.Windows.Forms.Button CloseTabButton;
        private System.Windows.Forms.Button AddTabButton;
        private System.Windows.Forms.ComboBox TabsDropdown;
        private System.Windows.Forms.Label StatusCodeLabel;
        private System.Windows.Forms.Label WebPageTitleLabel;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.ComboBox DisplayTypeDropdown;
        private System.Windows.Forms.Button AddFavouriteButton;
        private System.Windows.Forms.Label BrowserPageDateLabel;
        private System.Windows.Forms.Label BrowserPageVisitsLabel;
        private System.Windows.Forms.ListBox BrowserPageVisitsDisplay;
        private System.Windows.Forms.Label BrowswerPageUrlLabel;
        private System.Windows.Forms.ListBox BrowserPageUrlDisplay;
        private System.Windows.Forms.ListBox BrowserPageDateDisplay;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label BrowserPageTitleLabel;
        private System.Windows.Forms.ListBox BrowserPageTitleDisplay;
        private System.Windows.Forms.TextBox HtmlPageDisplay;
    }
}

