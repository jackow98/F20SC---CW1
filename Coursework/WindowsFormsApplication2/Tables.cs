using System.Data.Linq.Mapping;

namespace Browser
{

    /// <summary>
    /// Base class that stores details of a web page including a URL, Title, NO. of Visits and LastLoad
    /// </summary>
    public class WebPageTable
    {
        [ Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public string Id { get ; set ; }
        [ Column (Name = "Url")]
        public string Url { get ; set ; }
        [ Column (Name = "Title")]
        public string Title { get ; set ; }
        [ Column (Name = "Visits")]
        public int Visits { get ; set ; }
        [ Column (Name = "LastLoad")]
        public string LastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Favourites") ]
    public class Favourites : WebPageTable { }
    
    [ Table ( Name = "History") ]
    public class History : WebPageTable { }
    
    [ Table ( Name = "Tabs") ]
    public class Tabs : WebPageTable { }
    
    [ Table ( Name = "Home") ]
    public class Home
    {
        [ Column (Name = "Url", IsPrimaryKey=true)]
        public string Url { get ; set ; }
    }
}