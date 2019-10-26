using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Browser
{

    /// <summary>
    /// Abstract class that stores details of a web page including a URL, Title, NO. of Visits and LastLoad
    /// </summary>
    public abstract class WebPageTable
    {
        [ Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public abstract string Id { get ; set ; }
        [ Column (Name = "Url")]
        public abstract string Url { get ; set ; }
        [ Column (Name = "Title")]
        public abstract string Title { get ; set ; }
        [ Column (Name = "Visits")]
        public abstract int Visits { get ; set ; }
        [ Column (Name = "LastLoad")]
        public abstract string LastLoad { get ; set ; }
    }

    [Table(Name = "Favourites")]
    public class Favourites : WebPageTable
    {
        public override string Id { get; set; }
        public override string Url { get; set; }
        public override string Title { get; set; }
        public override int Visits { get; set; }
        public override string LastLoad { get; set; }
    }
    
    [ Table ( Name = "History") ]
    public class History : WebPageTable {
        public override string Id { get; set; }
        public override string Url { get; set; }
        public override string Title { get; set; }
        public override int Visits { get; set; }
        public override string LastLoad { get; set; }
    }
    
    [ Table ( Name = "Tabs") ]
    public class Tabs : WebPageTable {
        [ Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public override string Id { get ; set ; }
        [ Column (Name = "Url")]
        public override string Url { get ; set ; }
        [ Column (Name = "Title")]
        public override string Title { get ; set ; }
        [ Column (Name = "Visits")]
        public override int Visits { get ; set ; }
        [ Column (Name = "LastLoad")]
        public override string LastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Home") ]
    public class Home
    {
        [ Column (Name = "Url", IsPrimaryKey=true)]
        public string Url { get ; set ; }
    }
}