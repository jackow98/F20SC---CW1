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