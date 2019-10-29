﻿using System.Collections.Generic;
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
            LoadHome();
        }

        /// <summary>
        ///     Connects and maps SQLite database using LINQ
        /// </summary>
        private void MakeConnection()
        {
            var parentdir = Path.GetDirectoryName(Application.StartupPath);
            var absolutePath = Path.Combine(parentdir, "Debug", "demo.DB");
            var connectionString = string.Format("Data Source={0}", absolutePath);
            _connectedDatabase = new SQLiteConnection(connectionString);
        }

        /// <summary>
        ///     Maps SQLite table to LINQ table
        /// </summary>
        /// <typeparam name="TTable"> The type of the table to be fetched and returned </typeparam>
        /// <returns> A LINQ table of the type provided</returns>
        public Table<TTable> loadTable<TTable>() where TTable : WebPageTable
        {
            //TODO: Handle exceptions
            using (var db = new DataContext(_connectedDatabase))
            {
                return db.GetTable<TTable>();
            }
        }

        public List<TTable> getTableAsList<TTable>() where TTable : WebPageTable
        {
            //TODO: Handle exceptions, must return iterable
            using (var db = new DataContext(_connectedDatabase))
            {
                return db.GetTable<TTable>().ToList();
            }
        }
  
        public int getTableSize<TTable>() where TTable : WebPageTable
        {
            //todo: must return int
            using (var db = new DataContext(_connectedDatabase))
            {
                return db.GetTable<TTable>().ToList().Count;
            }
        }

        /// <summary>
        ///     Gets homepage URL from SQLite
        /// </summary>
        public string LoadHome()
        {
            //TODO: Handle exceptions
            using (var db = new DataContext(_connectedDatabase))
            {
                var homeTable = db.GetTable<Home>();

                foreach (var home in homeTable) return home.Url;

                return "";
            }
        }

        /// <summary>
        ///     Adds a new favourite to the database if no entry with the same URL already exists
        /// </summary>
        /// <param name="url"> A string of the URL corresponding to the new favourite to be added </param>
        /// <param name="title"> A string of the title corresponding to the new favourite to be added </param>
        public void AddFavourite(string url, string title)
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                if (db.GetTable<Favourites>().Any(favourite => favourite.Url == url)) return;

                var fav = new Favourites
                {
                    Url = url,
                    Title = title,
                    Visits = 0,
                    LastLoad = ""
                };

                var favs = db.GetTable<Favourites>();
                favs.InsertOnSubmit(fav);
                db.SubmitChanges();
            }
        }

        public void AddHistory(string url, string title)
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                var history = new History
                {
                    Url = url,
                    Title = title,
                    Visits = 0,
                    LastLoad = ""
                };

                var his = db.GetTable<History>();
                his.InsertOnSubmit(history);
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

        /// <summary>
        ///     Adds a new blank tab to the database
        /// </summary>
        public void AddTab()
        {
            using (var db = new DataContext(_connectedDatabase))
            {
                var tab = new Tabs
                {
                    Url = "",
                    Title = "",
                    Visits = 0,
                    LastLoad = "",
                    Id = null
                };


                var tabs = db.GetTable<Tabs>();
                tabs.InsertOnSubmit(tab);
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