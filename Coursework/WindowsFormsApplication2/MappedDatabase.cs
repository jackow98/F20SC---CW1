using System.Data.Linq;
using System.Data.SQLite;

namespace Browser
{
    public class MappedDatabase
    {
        private SQLiteConnection con;
        public MappedDatabase(SQLiteConnection connection)
        {
            con = connection;
        }

        public Table<Home> GetHomeTable()
        {
            DataContext db = new DataContext(con);
            return db.GetTable<Home>();
        }

        public Table<T> GetWebPageNameTable<T>() where T : WebPageTable
        {
            DataContext db = new DataContext(con);
            return db.GetTable<T>();
        }

        public void WriteChanges()
        {
            using (DataContext db = new DataContext(con))
            {
                db.SubmitChanges();
            }
        }
    }
}