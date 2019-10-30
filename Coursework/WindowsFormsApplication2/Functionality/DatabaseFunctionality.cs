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
        private bool MakeConnection()
        {
            return SafeExecution.DatabaseConnection(() =>
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

                return true;
            });
        }

        /// <summary>
        ///     Gets homepage URL from SQLite, returns empty string if no home page
        /// </summary>
        public string LoadHome()
        {
            try
            {
                using (DataContext db = new DataContext(_connectedDatabase))
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
                using (DataContext db = new DataContext(_connectedDatabase))
                {
                    return db.GetTable<TTable>().ToList();
                }
            }
            catch (NullReferenceException e)
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
                using (DataContext db = new DataContext(_connectedDatabase))
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
        /// <param name="url"> A string of the URL corresponding to the new entry to be added </param>
        /// <param name="title"> A string of the title corresponding to the new entry to be added </param>
        public bool AddWebPage<TTable>(string url = "", string title = "", bool uniqueUrl = false)
            where TTable : WebPageTable, new()
        {
            return SafeExecution.DatabaseConnection(() =>
            {
                using (DataContext db = new DataContext(_connectedDatabase))
                {
                    //If unique URL required, checks table for existing entry
                    if (uniqueUrl)
                    {
                        if (db.GetTable<TTable>().Any(row => row.Url == url)) return false;
                    }

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

                return true;
            });
        }

        /// <summary>
        ///     Updates an entry in the database
        /// </summary>
        /// <param name="index">The index of the entry to be updated</param>
        /// <param name="url"> A unique string of the URL corresponding to the entry to be updated </param>
        /// <param name="title"> A string of the title corresponding to the entry to be updated </param>
        public bool UpdateTable<TTable>(int index, string url, string title) where TTable : WebPageTable
        {
            return SafeExecution.DatabaseConnection(() =>
            {
                using (DataContext db = new DataContext(_connectedDatabase))
                {
                    Table<TTable> table = db.GetTable<TTable>();

                    int count = 0;
                    foreach (TTable entry in table)
                    {
                        if (index == count)
                        {
                            entry.Url = url;
                            entry.Title = title;
                            break;
                        }

                        count++;
                    }

                    db.SubmitChanges();
                }

                return true;
            });
        }

        /// <summary>
        ///     Updates home page database
        /// </summary>
        /// <param name="url"> A string of the URL corresponding to the new home page </param>
        public bool UpdateHome(string url)
        {
            return SafeExecution.DatabaseConnection(() =>
            {
                using (DataContext db = new DataContext(_connectedDatabase))
                {
                    var homeTable = db.GetTable<Home>();

                    foreach (Home home in homeTable) home.Url = url;

                    db.SubmitChanges();
                }

                return true;
            });
        }

        /// <summary>
        ///     Delete a web page from table in databse by unique ID
        /// </summary>
        /// <param name="index"></param>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        public bool DeleteWebpage<TTable>(int index) where TTable : WebPageTable
        {
            return SafeExecution.DatabaseConnection(() =>
            {
                using (DataContext db = new DataContext(_connectedDatabase))
                {
                    Table<TTable> table = db.GetTable<TTable>();

                    int count = 0;
                    foreach (TTable entry in table)
                    {
                        if (index == count)
                        {
                            table.DeleteOnSubmit(entry);
                            break;
                        }

                        count++;
                    }

                    db.SubmitChanges();
                }

                return true;
            });
        }
    }
}