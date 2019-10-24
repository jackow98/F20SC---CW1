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
        private WebPages<T> history; 
        private WebPages<T> favourites; 
        private WebPages<T> tabs;
        private HTMLPage Home;
        
        public BrowserWindow()
        {
            InitializeComponent();
        }

        //Browser GUI 
        private void ReloadButton_Click(object sender, EventArgs e)
        {
             
        }
        
        //Tab GUI 
        private void SearchButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
