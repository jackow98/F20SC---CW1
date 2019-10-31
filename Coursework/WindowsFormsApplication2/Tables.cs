using System.Data.Linq.Mapping;

namespace WindowsFormsApplication2
{
    //TODO: Implement visits and last load
    /// <summary>
    ///    Abstract class that stores details of a web page including a URL, Title, NO. of Visits and LastLoad
    ///    The WebPageTable is subclassed by History, Tabs and favourites  
    /// </summary>
    public abstract class WebPageTable
    {
        public abstract string TableName { get; }
        
        [Column(Name = "Id", IsPrimaryKey = true)]
        public abstract int? Id { get; set; }

        [Column(Name = "Url")] public abstract string Url { get; set; }

        [Column(Name = "Title")] public abstract string Title { get; set; }

        [Column(Name = "Visits")] public abstract int Visits { get; set; }

        [Column(Name = "LastLoad")] public abstract string LastLoad { get; set; }
    }

    /// <summary>
    ///     Favourites table that implements all of the methods in WebPageTable
    /// </summary>
    [Table(Name = "Favourites")]
    public class Favourites : WebPageTable
    {
        private static string _tableName = "Favourites";

        public override string TableName
        {
            get { return _tableName; }
        }

        [Column(Name = "Id", IsPrimaryKey = true)]
        public override int? Id { get; set; }

        [Column(Name = "Url")] public override string Url { get; set; }

        [Column(Name = "Title")] public override string Title { get; set; }

        [Column(Name = "Visits")] public override int Visits { get; set; }

        [Column(Name = "LastLoad")] public override string LastLoad { get; set; }
    }

    /// <summary>
    ///     History table that implements all of the methods in WebPageTable
    /// </summary>
    [Table(Name = "History")]
    public class History : WebPageTable
    {
        private static string _tableName = "History";

        public override string TableName
        {
            get { return _tableName; }
        }
        
        [Column(Name = "Id", IsPrimaryKey = true)]
        public override int? Id { get; set; }

        [Column(Name = "Url")] public override string Url { get; set; }

        [Column(Name = "Title")] public override string Title { get; set; }

        [Column(Name = "Visits")] public override int Visits { get; set; }

        [Column(Name = "LastLoad")] public override string LastLoad { get; set; }
    }

    /// <summary>
    ///     Tabs table that implements all of the methods in WebPageTable
    /// </summary>
    [Table(Name = "Tabs")]
    public class Tabs : WebPageTable
    {
        private static string _tableName = "Tabs";

        public override string TableName
        {
            get { return _tableName; }
        }
        
        [Column(Name = "Id", IsPrimaryKey = true)]
        public override int? Id { get; set; }

        [Column(Name = "Url")] public override string Url { get; set; }

        [Column(Name = "Title")] public override string Title { get; set; }

        [Column(Name = "Visits")] public override int Visits { get; set; }

        [Column(Name = "LastLoad")] public override string LastLoad { get; set; }
    }

    /// <summary>
    ///     Home table that is designed to store only one home page
    /// </summary>
    [Table(Name = "Home")]
    public class Home
    {
        [Column(Name = "Id", IsPrimaryKey = true)]
        public int? Id { get; set; }

        [Column(Name = "Url")] public string Url { get; set; }

        [Column(Name = "Title")] public string Title { get; set; }
    }
}