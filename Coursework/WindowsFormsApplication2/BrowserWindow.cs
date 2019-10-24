using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace Browser
{
    
    public partial class BrowserWindow <T> where T : IWebpage
    {
        //TODO: Refactor so only used DatabaseFunctionality
        //private WebPages<T> history; 
        //private WebPages<T> favourites; 
        //private WebPages<T> tabs;
        //private HTMLPage Home;
        
        public BrowserWindow()
        {
            DatabaseFunctionality db = new DatabaseFunctionality();
            InitializeComponent();
        }
        
        //Tab GUI 
        private void SearchButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
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
