using System.Windows.Forms;

namespace Browser
{
    partial class BrowserWindow<T> : Form  where T : IWebpage
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
            this.HTMLPageDisplay = new System.Windows.Forms.RichTextBox();
            this.WebPageTitleLabel = new System.Windows.Forms.Label();
            this.StatusCodeLabel = new System.Windows.Forms.Label();
            this.DisplayTypeDropdown = new System.Windows.Forms.ComboBox();
            this.AddFavouriteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SearchButton.Location = new System.Drawing.Point(600, 69);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(74, 34);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            this.SearchBar.Location = new System.Drawing.Point(175, 69);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(415, 27);
            this.SearchBar.TabIndex = 5;
            this.SearchBar.Text = "Enter URL";
            this.HomeButton.Location = new System.Drawing.Point(79, 64);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(73, 39);
            this.HomeButton.TabIndex = 7;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            this.FavouritesButton.Location = new System.Drawing.Point(713, 69);
            this.FavouritesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FavouritesButton.Name = "FavouritesButton";
            this.FavouritesButton.Size = new System.Drawing.Size(99, 34);
            this.FavouritesButton.TabIndex = 8;
            this.FavouritesButton.Text = "Favourites";
            this.FavouritesButton.UseVisualStyleBackColor = true;
            this.FavouritesButton.Click += new System.EventHandler(this.FavouritesButton_Click);
            this.HistoryButton.Location = new System.Drawing.Point(819, 68);
            this.HistoryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(112, 35);
            this.HistoryButton.TabIndex = 9;
            this.HistoryButton.Text = "History";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            this.TabsDropdown.FormattingEnabled = true;
            this.TabsDropdown.Location = new System.Drawing.Point(5, 1);
            this.TabsDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabsDropdown.Name = "TabsDropdown";
            this.TabsDropdown.Size = new System.Drawing.Size(773, 28);
            this.TabsDropdown.TabIndex = 10;
            this.TabsDropdown.Text = "CurrentTab";
            this.AddTabButton.Location = new System.Drawing.Point(786, 1);
            this.AddTabButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddTabButton.Name = "AddTabButton";
            this.AddTabButton.Size = new System.Drawing.Size(78, 31);
            this.AddTabButton.TabIndex = 11;
            this.AddTabButton.Text = "Add Tab";
            this.AddTabButton.UseVisualStyleBackColor = true;
            this.AddTabButton.Click += new System.EventHandler(this.AddTabButton_Click);
            this.CloseTabButton.Location = new System.Drawing.Point(871, 1);
            this.CloseTabButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseTabButton.Name = "CloseTabButton";
            this.CloseTabButton.Size = new System.Drawing.Size(78, 31);
            this.CloseTabButton.TabIndex = 12;
            this.CloseTabButton.Text = "Close Tab";
            this.CloseTabButton.UseVisualStyleBackColor = true;
            this.CloseTabButton.Click += new System.EventHandler(this.CloseTabButton_Click);
            this.ReloadButton.Location = new System.Drawing.Point(5, 64);
            this.ReloadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(67, 39);
            this.ReloadButton.TabIndex = 13;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            this.HTMLPageDisplay.Location = new System.Drawing.Point(5, 224);
            this.HTMLPageDisplay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.HTMLPageDisplay.Name = "HTMLPageDisplay";
            this.HTMLPageDisplay.Size = new System.Drawing.Size(955, 449);
            this.HTMLPageDisplay.TabIndex = 6;
            this.HTMLPageDisplay.Text = "";
            this.WebPageTitleLabel.Location = new System.Drawing.Point(6, 181);
            this.WebPageTitleLabel.Name = "WebPageTitleLabel";
            this.WebPageTitleLabel.Size = new System.Drawing.Size(613, 42);
            this.WebPageTitleLabel.TabIndex = 14;
            this.WebPageTitleLabel.Text = "CurrentWebPage";
            this.StatusCodeLabel.Location = new System.Drawing.Point(625, 181);
            this.StatusCodeLabel.Name = "StatusCodeLabel";
            this.StatusCodeLabel.Size = new System.Drawing.Size(152, 42);
            this.StatusCodeLabel.TabIndex = 15;
            this.StatusCodeLabel.Text = "Staus Code";
            this.DisplayTypeDropdown.FormattingEnabled = true;
            this.DisplayTypeDropdown.Location = new System.Drawing.Point(777, 178);
            this.DisplayTypeDropdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisplayTypeDropdown.Name = "DisplayTypeDropdown";
            this.DisplayTypeDropdown.Size = new System.Drawing.Size(182, 28);
            this.DisplayTypeDropdown.TabIndex = 16;
            this.DisplayTypeDropdown.Text = "Raw HTML";
            this.DisplayTypeDropdown.SelectedIndexChanged +=
                new System.EventHandler(this.DisplayTypeDropdown_SelectedIndexChanged);
            this.AddFavouriteButton.Location = new System.Drawing.Point(819, 684);
            this.AddFavouriteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddFavouriteButton.Name = "AddFavouriteButton";
            this.AddFavouriteButton.Size = new System.Drawing.Size(129, 32);
            this.AddFavouriteButton.TabIndex = 17;
            this.AddFavouriteButton.Text = "Add Favourite";
            this.AddFavouriteButton.UseVisualStyleBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 721);
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
            this.Controls.Add(this.HTMLPageDisplay);
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
        private System.Windows.Forms.RichTextBox HTMLPageDisplay;
        private System.Windows.Forms.Button AddFavouriteButton;
    }
}

