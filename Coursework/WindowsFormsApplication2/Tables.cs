using System.Data.Linq.Mapping;

namespace Browser
{
    [ Table ( Name = "Favourites") ]
    public class Favourites
    {
        [ Column (IsPrimaryKey=true)]
        public string URL { get ; set ; }
        [ Column ]
        public string name { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column (IsPrimaryKey=true)]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "History") ]
    public class History
    {
        [ Column (IsPrimaryKey=true)]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column (IsPrimaryKey=true)]
        public string lastLoad { get ; set ; }
    }

    [Table(Name = "Tabs")]
    public class Tabs
    {
        [Column(IsPrimaryKey = true)] 
        public string URL { get; set; }
        [Column] 
        public string title { get; set; }
        [Column] 
        public string rawHTML { get; set; }
        [Column] 
        public string ID { get; set; }

    }

    [ Table ( Name = "Home") ]
    public class Home
    {
        [ Column (IsPrimaryKey=true)]
        public string URL { get ; set ; }
    }
}