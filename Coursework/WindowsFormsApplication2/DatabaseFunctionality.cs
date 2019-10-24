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
    [ Table ( Name = "Favourites") ]
    public class Favourites
    {
        [ Column ]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public string rawHTML { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column ]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "History") ]
    public class History
    {
        [ Column ]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public string rawHTML { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column ]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Tabs") ]
    public class Tabs
    {
        [ Column ]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public string rawHTML { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column ]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Home") ]
    public class Home
    {
        [ Column ]
        public string URL { get ; set ; }
    }
    
    public class DatabaseFunctionality
    {
        private DataContext databaseConnection;
        public Table<Favourites> FavouriteTable;
        public Table<Tabs> TabTable;
        public Table<History> HistoryTable;
        public Table<Home> HomeTable;
        
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
            string relativePath = @"demo.DB";
            var parentdir = Path.GetDirectoryName(Application.StartupPath);
            string absolutePath = Path.Combine(parentdir, "Debug", "demo.DB");
            string connectionString = string.Format("Data Source={0}",absolutePath);
            var connection = new SQLiteConnection(connectionString);
            databaseConnection =  new DataContext(connection);
        }
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
            HomeTable = databaseConnection.GetTable<Home>();
        }

        public IQueryable<Favourites> GetFavouritesQueryable()
        {
            return from favourite in FavouriteTable select favourite;
        }
        
        public IQueryable<History> GetHistoryQueryable()
        {
            return from history in HistoryTable select history;
        }
        
        public IQueryable<Tabs> GetTabsQueryable()
        {
            return from tab in TabTable select tab;
        }
    }
}