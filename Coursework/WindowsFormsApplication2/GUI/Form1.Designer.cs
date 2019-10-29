using System;
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
            this.components = new System.ComponentModel.Container();
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
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.HtmlPageDisplay = new System.Windows.Forms.TextBox();
            this.FavouriteHandlerStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowswerPageUrlLabel = new System.Windows.Forms.Label();
            this.BrowserPageTitleLabel = new System.Windows.Forms.Label();
            this.BrowserPageTitleDisplay = new System.Windows.Forms.ListBox();
            this.BrowserPageDateLabel = new System.Windows.Forms.Label();
            this.BrowserPageDateDisplay = new System.Windows.Forms.ListBox();
            this.BrowserPageVisitsLabel = new System.Windows.Forms.Label();
            this.BrowserPageVisitsDisplay = new System.Windows.Forms.ListBox();
            this.FavouriteHandlerStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SearchButton.Location = new System.Drawing.Point(487, 49);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(66, 26);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(139, 51);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(340, 23);
            this.SearchBar.TabIndex = 5;
            this.SearchBar.Text = "Enter URL";
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(67, 49);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(64, 26);
            this.HomeButton.TabIndex = 7;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            this.HomeButton.MouseHover += new System.EventHandler(this.HomeButton_Hover);
            // 
            // FavouritesButton
            // 
            this.FavouritesButton.Location = new System.Drawing.Point(680, 49);
            this.FavouritesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FavouritesButton.Name = "FavouritesButton";
            this.FavouritesButton.Size = new System.Drawing.Size(74, 26);
            this.FavouritesButton.TabIndex = 8;
            this.FavouritesButton.Text = "Favourites";
            this.FavouritesButton.UseVisualStyleBackColor = true;
            this.FavouritesButton.Click += new System.EventHandler(this.FavouritesButton_Click);
            // 
            // HistoryButton
            // 
            this.HistoryButton.Location = new System.Drawing.Point(756, 49);
            this.HistoryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(74, 26);
            this.HistoryButton.TabIndex = 9;
            this.HistoryButton.Text = "History";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // TabsDropdown
            // 
            this.TabsDropdown.FormattingEnabled = true;
            this.TabsDropdown.Location = new System.Drawing.Point(4, 1);
            this.TabsDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabsDropdown.Name = "TabsDropdown";
            this.TabsDropdown.Size = new System.Drawing.Size(677, 23);
            this.TabsDropdown.TabIndex = 10;
            this.TabsDropdown.Text = "CurrentTab";
            this.TabsDropdown.SelectedIndexChanged += new System.EventHandler(this.TabsDropdown_SelectedIndexChanged);
            // 
            // AddTabButton
            // 
            this.AddTabButton.Location = new System.Drawing.Point(689, 1);
            this.AddTabButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddTabButton.Name = "AddTabButton";
            this.AddTabButton.Size = new System.Drawing.Size(67, 23);
            this.AddTabButton.TabIndex = 11;
            this.AddTabButton.Text = "Add Tab";
            this.AddTabButton.UseVisualStyleBackColor = true;
            this.AddTabButton.Click += new System.EventHandler(this.AddTabButton_Click);
            // 
            // CloseTabButton
            // 
            this.CloseTabButton.Location = new System.Drawing.Point(762, 1);
            this.CloseTabButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseTabButton.Name = "CloseTabButton";
            this.CloseTabButton.Size = new System.Drawing.Size(67, 23);
            this.CloseTabButton.TabIndex = 12;
            this.CloseTabButton.Text = "Close Tab";
            this.CloseTabButton.UseVisualStyleBackColor = true;
            this.CloseTabButton.Click += new System.EventHandler(this.CloseTabButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Location = new System.Drawing.Point(4, 49);
            this.ReloadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(59, 26);
            this.ReloadButton.TabIndex = 13;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // WebPageTitleLabel
            // 
            this.WebPageTitleLabel.Location = new System.Drawing.Point(4, 136);
            this.WebPageTitleLabel.Name = "WebPageTitleLabel";
            this.WebPageTitleLabel.Size = new System.Drawing.Size(536, 31);
            this.WebPageTitleLabel.TabIndex = 14;
            // 
            // StatusCodeLabel
            // 
            this.StatusCodeLabel.Location = new System.Drawing.Point(547, 136);
            this.StatusCodeLabel.Name = "StatusCodeLabel";
            this.StatusCodeLabel.Size = new System.Drawing.Size(133, 31);
            this.StatusCodeLabel.TabIndex = 15;
            // 
            // DisplayTypeDropdown
            // 
            this.DisplayTypeDropdown.FormattingEnabled = true;
            this.DisplayTypeDropdown.Location = new System.Drawing.Point(680, 134);
            this.DisplayTypeDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisplayTypeDropdown.Name = "DisplayTypeDropdown";
            this.DisplayTypeDropdown.Size = new System.Drawing.Size(161, 23);
            this.DisplayTypeDropdown.TabIndex = 16;
            this.DisplayTypeDropdown.Text = "Raw HTML";
            this.DisplayTypeDropdown.Visible = false;
            // 
            // AddFavouriteButton
            // 
            this.AddFavouriteButton.Location = new System.Drawing.Point(717, 514);
            this.AddFavouriteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddFavouriteButton.Name = "AddFavouriteButton";
            this.AddFavouriteButton.Size = new System.Drawing.Size(113, 24);
            this.AddFavouriteButton.TabIndex = 17;
            this.AddFavouriteButton.Text = "Add Favourite";
            this.AddFavouriteButton.UseVisualStyleBackColor = true;
            this.AddFavouriteButton.Click += new System.EventHandler(this.AddFavouriteButton_Click);
            // 
            // BrowserPageUrlDisplay
            // 
            this.BrowserPageUrlDisplay.FormattingEnabled = true;
            this.BrowserPageUrlDisplay.ItemHeight = 15;
            this.BrowserPageUrlDisplay.Location = new System.Drawing.Point(195, 196);
            this.BrowserPageUrlDisplay.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.BrowserPageUrlDisplay.Name = "BrowserPageUrlDisplay";
            this.BrowserPageUrlDisplay.Size = new System.Drawing.Size(364, 304);
            this.BrowserPageUrlDisplay.TabIndex = 18;
            this.BrowserPageUrlDisplay.MouseClick +=
                new System.Windows.Forms.MouseEventHandler(this.BrowserPageUrlDisplay_MouseClick);
            this.BrowserPageUrlDisplay.MouseDoubleClick +=
                new System.Windows.Forms.MouseEventHandler(this.BrowserPageUrlDisplay_MouseDoubleClick);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(616, 49);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(46, 26);
            this.NextButton.TabIndex = 25;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(563, 49);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(49, 26);
            this.BackButton.TabIndex = 26;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HtmlPageDisplay
            // 
            this.HtmlPageDisplay.Location = new System.Drawing.Point(8, 163);
            this.HtmlPageDisplay.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.HtmlPageDisplay.Multiline = true;
            this.HtmlPageDisplay.Name = "HtmlPageDisplay";
            this.HtmlPageDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HtmlPageDisplay.Size = new System.Drawing.Size(824, 338);
            this.HtmlPageDisplay.TabIndex = 29;
            // 
            // FavouriteHandlerStrip
            // 
            this.FavouriteHandlerStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FavouriteHandlerStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.editToolStripMenuItem, this.searchToolStripMenuItem, this.deleteToolStripMenuItem});
            this.FavouriteHandlerStrip.Name = "contextMenuStrip1";
            this.FavouriteHandlerStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // BrowswerPageUrlLabel
            // 
            this.BrowswerPageUrlLabel.Location = new System.Drawing.Point(195, 174);
            this.BrowswerPageUrlLabel.Name = "BrowswerPageUrlLabel";
            this.BrowswerPageUrlLabel.Size = new System.Drawing.Size(168, 21);
            this.BrowswerPageUrlLabel.TabIndex = 21;
            this.BrowswerPageUrlLabel.Text = "URL";
            // 
            // BrowserPageTitleLabel
            // 
            this.BrowserPageTitleLabel.Location = new System.Drawing.Point(11, 174);
            this.BrowserPageTitleLabel.Name = "BrowserPageTitleLabel";
            this.BrowserPageTitleLabel.Size = new System.Drawing.Size(144, 21);
            this.BrowserPageTitleLabel.TabIndex = 27;
            this.BrowserPageTitleLabel.Text = "Title";
            // 
            // BrowserPageTitleDisplay
            // 
            this.BrowserPageTitleDisplay.FormattingEnabled = true;
            this.BrowserPageTitleDisplay.ItemHeight = 15;
            this.BrowserPageTitleDisplay.Location = new System.Drawing.Point(11, 196);
            this.BrowserPageTitleDisplay.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.BrowserPageTitleDisplay.Name = "BrowserPageTitleDisplay";
            this.BrowserPageTitleDisplay.Size = new System.Drawing.Size(172, 304);
            this.BrowserPageTitleDisplay.TabIndex = 28;
            // 
            // BrowserPageDateLabel
            // 
            this.BrowserPageDateLabel.Location = new System.Drawing.Point(564, 174);
            this.BrowserPageDateLabel.Name = "BrowserPageDateLabel";
            this.BrowserPageDateLabel.Size = new System.Drawing.Size(112, 21);
            this.BrowserPageDateLabel.TabIndex = 22;
            this.BrowserPageDateLabel.Text = "Date";
            // 
            // BrowserPageDateDisplay
            // 
            this.BrowserPageDateDisplay.FormattingEnabled = true;
            this.BrowserPageDateDisplay.ItemHeight = 15;
            this.BrowserPageDateDisplay.Location = new System.Drawing.Point(564, 196);
            this.BrowserPageDateDisplay.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.BrowserPageDateDisplay.Name = "BrowserPageDateDisplay";
            this.BrowserPageDateDisplay.Size = new System.Drawing.Size(147, 304);
            this.BrowserPageDateDisplay.TabIndex = 19;
            // 
            // BrowserPageVisitsLabel
            // 
            this.BrowserPageVisitsLabel.Location = new System.Drawing.Point(722, 174);
            this.BrowserPageVisitsLabel.Name = "BrowserPageVisitsLabel";
            this.BrowserPageVisitsLabel.Size = new System.Drawing.Size(76, 16);
            this.BrowserPageVisitsLabel.TabIndex = 23;
            this.BrowserPageVisitsLabel.Text = "Visits";
            // 
            // BrowserPageVisitsDisplay
            // 
            this.BrowserPageVisitsDisplay.FormattingEnabled = true;
            this.BrowserPageVisitsDisplay.ItemHeight = 15;
            this.BrowserPageVisitsDisplay.Location = new System.Drawing.Point(721, 196);
            this.BrowserPageVisitsDisplay.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.BrowserPageVisitsDisplay.Name = "BrowserPageVisitsDisplay";
            this.BrowserPageVisitsDisplay.Size = new System.Drawing.Size(112, 304);
            this.BrowserPageVisitsDisplay.TabIndex = 20;
            // 
            // BrowserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(965, 577);
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
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "BrowserWindow";
            this.FavouriteHandlerStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox BrowserPageUrlDisplay;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TextBox HtmlPageDisplay;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip FavouriteHandlerStrip;
        private System.Windows.Forms.ListBox BrowserPageVisitsDisplay;
        private System.Windows.Forms.Label BrowserPageVisitsLabel;
        private System.Windows.Forms.ListBox BrowserPageDateDisplay;
        private System.Windows.Forms.Label BrowserPageDateLabel;
        private System.Windows.Forms.ListBox BrowserPageTitleDisplay;
        private System.Windows.Forms.Label BrowserPageTitleLabel;
        private System.Windows.Forms.Label BrowswerPageUrlLabel;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

