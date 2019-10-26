using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data.Linq;
using System.Data.SQLite;
using System.Linq;

namespace Browser
{
    public class DatabaseFunctionality
    {
        private DataContext databaseConnection;
        public Table<Favourites> FavouriteTable;
        public Table<Tabs> TabTable;
        public Table<History> HistoryTable;
        public string HomeURL;
        
        public DatabaseFunctionality()
        {
            this.makeConnection();
            this.loadFavourites();
            this.loadTabs();
            this.loadHistory();
            this.loadHome();
        }

        private void makeConnection()
        {
            var parentdir = Path.GetDirectoryName(Application.StartupPath);
            string absolutePath = Path.Combine(parentdir, "Debug", "demo.DB");
            string connectionString = string.Format("Data Source={0}",absolutePath);
            var connection = new SQLiteConnection(connectionString);
            databaseConnection =  new DataContext(connection);
        }

        //TODO: Make generic
        private void loadFavourites()
        {
            FavouriteTable = databaseConnection.GetTable<Favourites>();
        }
        
        private void loadTabs()
        {
            TabTable = databaseConnection.GetTable<Tabs>();
        }
        
        private void loadHistory()
        {
            HistoryTable = databaseConnection.GetTable<History>();
        }

        private void loadHome()
        {
            Table<Home> homeTable = databaseConnection.GetTable<Home>();
            foreach (var home in homeTable)
            {
                HomeURL = home.URL;
            }
        }

        public void AddFavourite(string url, string name)
        {
            //TODO: Check if already in table and update if yes
            //TODO: Use a unique primary key for all tables
            Favourites fav = new Favourites
            {
                URL = url,
                name = name,
                visits = 1,
                lastLoad = DateTime.Now.ToString()
            };
            
            FavouriteTable.InsertOnSubmit(fav);
            
            WriteToDatabse();
        }
        
        public void AddTab()
        {
            Tabs tab = new Tabs();

            tab.URL = "";
            tab.rawHTML = "";
            tab.title = "";
            tab.firstLoad = DateTime.Now.ToString();
            
            this.loadTabs();
            TabTable.InsertOnSubmit(tab);
            
            WriteToDatabse();

            //MessageBox.Show(tab.ID.ToString());
        }

        public void WriteToDatabse()
        {
            try
            {
                databaseConnection.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                databaseConnection.SubmitChanges();
            }
            
            databaseConnection.Refresh(RefreshMode.KeepCurrentValues);
        }
    }
}