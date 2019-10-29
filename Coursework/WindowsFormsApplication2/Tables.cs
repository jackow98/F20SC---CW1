using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;

namespace Browser
{

    /// <summary>
    /// Abstract class that stores details of a web page including a URL, Title, NO. of Visits and LastLoad
    /// </summary>
    public abstract class WebPageTable
    {
        [Column(Name = "Id", IsPrimaryKey = true)]
        public abstract int? Id { get; set; }
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
        [ Column (Name = "Id", IsPrimaryKey = true)]
        public override int? Id { get; set; }
        [ Column (Name = "Url")]
        public override string Url { get ; set ; }
        [ Column (Name = "Title")]
        public override string Title { get ; set ; }
        [ Column (Name = "Visits")]
        public override int Visits { get ; set ; }
        [ Column (Name = "LastLoad")]
        public override string LastLoad { get ; set ; }
    }
    
    [ Table ( Name = "History") ]
    public class History : WebPageTable {
        [ Column (Name = "Id", IsPrimaryKey = true)]
        public override int? Id { get; set; }
        [ Column (Name = "Url")]
        public override string Url { get ; set ; }
        [ Column (Name = "Title")]
        public override string Title { get ; set ; }
        [ Column (Name = "Visits")]
        public override int Visits { get ; set ; }
        [ Column (Name = "LastLoad")]
        public override string LastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Tabs") ]
    public class Tabs : WebPageTable
    {
        [Column(Name = "Id",  IsPrimaryKey = true)]
        public override int? Id { get; set; }
            [ Column (Name = "Url")]
        public override string Url { get ; set ; }
        [ Column (Name = "Title")]
        public override string Title { get ; set ; }
        [ Column (Name = "Visits")]
        public override int Visits { get ; set ; }
        [ Column (Name = "LastLoad")]
        public override string LastLoad { get ; set ; }
        
        public void Detach()
        {
            GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, null);
        }
    }
    
    [ Table ( Name = "Home") ]
    public class Home
    {
        [Column(Name = "Id",  IsPrimaryKey = true)]
        public int? Id { get; set; }
        [ Column (Name = "Url")]
        public string Url { get ; set ; }
        [ Column (Name = "Title")]
        public  string Title { get ; set ; }
    }
}