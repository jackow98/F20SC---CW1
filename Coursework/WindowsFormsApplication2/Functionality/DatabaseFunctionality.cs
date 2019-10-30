using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Browser;

namespace Coursework.Functionality
{
    /// <summary>
    ///     Class to handle connection and transactions with local SQLite database
    /// </summary>
    public class DatabaseFunctionality
    {
        private SQLiteConnection _connectedDatabase;

        public DatabaseFunctionality()
        {
            MakeConnection();
        }

        /// <summary>
        ///     Connects and maps SQLite database using LINQ
        /// </summary>
        private void MakeConnection()
        {
            SafeExecution.DatabaseConnection(() =>
            {
                string parentDir = Path.GetDirectoryName(Application.StartupPath);
                if (parentDir != null)
                {
                    string absolutePath = Path.Combine(parentDir, "Debug", "demo.DB");
                    string connectionString = string.Format("Data Source={0}", absolutePath);
                    _connectedDatabase = new SQLiteConnection(connectionString);
                }
                else
                {
                    throw new SafeExecution.DatabseException("Directory of database is not valid");
                }
            });
        }

        /// <summary>
        ///     Gets homepage URL from SQLite, returns empty string if no home page
        /// </summary>
        public string LoadHome()
        {
            try
            {
                using (var db = new DataContext(_connectedDatabase))
                {
                    Table<Home> homeTable = db.GetTable<Home>();
                    foreach (var home in homeTable) return home.Url;
                    throw new SafeExecution.DatabseException("No Home page found");
                }
            }
            catch (SafeExecution.DatabseException e)
            {
                return "";
            }
        }

        /// <summary>
        ///     Gets generic table from SQLite, returns empty list if there is no table
        /// </summary>
        public List<TTable> GetTableAsList<TTable>() where TTable : WebPageTable
        {
            try
            {
                using (var db = new DataContext(_connectedDatabase))
                {
                    return db.GetTable<TTable>().ToList();
                }
            }
            catch(NullReferenceException e)
            {
                return new List<TTable>();
            }
        }
  
        /// <summary>
        ///     Returns size of table, 0 if not present
        /// </summary>
        public int GetTableSize<TTable>() where TTable : WebPageTable
        {
            try
            {
                using (var db = new DataContext(_connectedDatabase))
                {
                    return db.GetTable<TTable>().ToList().Count;
                }
            }
            catch (NullReferenceException e)
            {
                return 0;
            }

        }

        /// <summary>
        ///     Adds a new entry to the database
        /// </summary>
        /// <param name="url"> A string of the URL corresponding to the new favourite to be added </param>
        /// <param name="title"> A string of the title corresponding to the new favourite to be added </param>
        public void AddWebPage<TTable>(string url = "", string title = "", bool uniqueUrl = false) where TTable : WebPageTable, new()
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                if (uniqueUrl) { if (db.GetTable<TTable>().Any(row => row.Url == url)) return; }
                

                TTable entry = new TTable
                {
                    Url = url,
                    Title = title,
                    Visits = 0,
                    LastLoad = ""
                };

                Table<TTable> table = db.GetTable<TTable>();
                table.InsertOnSubmit(entry);
                db.SubmitChanges();
            }
        }

        public void UpdateFavourite(int index, string url, string title)
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                var favourites = db.GetTable<Favourites>();

                var count = 0;
                foreach (var favourite in favourites)
                {
                    if (index == count)
                    {
                        favourite.Url = url;
                        favourite.Title = title;
                        break;
                    }

                    count++;
                }

                db.SubmitChanges();
            }
        }

        public void UpdateHome(string url)
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                var homeTable = db.GetTable<Home>();

                foreach (var home in homeTable) home.Url = url;

                db.SubmitChanges();
            }
        }

 

        public void DeleteFavoutite(int index)
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                var favs = db.GetTable<Favourites>();

                var count = 0;
                foreach (var fav in favs)
                {
                    if (index == count) favs.DeleteOnSubmit(fav);

                    count++;
                }

                db.SubmitChanges();
            }
        }

        public void CloseTab(int index)
        {
            //TODO: LINQ error handling
            using (var db = new DataContext(_connectedDatabase))
            {
                var tabs = db.GetTable<Tabs>();

                var count = 0;
                foreach (var tab in tabs)
                {
                    if (index == count)
                    {
                        tabs.DeleteOnSubmit(tab);
                        break;
                    }

                    count++;
                }

                db.SubmitChanges();
            }
        }

        /// <summary>
        /// Writes changes to the SQLite database 
        /// </summary>
        //private void WriteToDatabase()
        //{
        //    try
        //    {
        //        MappedDatabase db = new MappedDatabase(_connectedDatabase);
        //        db.WriteChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //     
        //        MappedDatabase db = new MappedDatabase(_connectedDatabase);
        //        db.WriteChanges();
        //    }
        //    
        //}
    }
}