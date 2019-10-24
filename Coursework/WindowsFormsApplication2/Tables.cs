using System.Data.Linq.Mapping;

namespace Browser
{
    [ Table ( Name = "Favourites") ]
    public class Favourites
    {
        [ Column ]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public string rawHTML { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column ]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "History") ]
    public class History
    {
        [ Column ]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public string rawHTML { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column ]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Tabs") ]
    public class Tabs
    {
        [ Column ]
        public string URL { get ; set ; }
        [ Column ]
        public string title { get ; set ; }
        [ Column ]
        public string rawHTML { get ; set ; }
        [ Column ]
        public int visits { get ; set ; }
        [ Column ]
        public string lastLoad { get ; set ; }
    }
    
    [ Table ( Name = "Home") ]
    public class Home
    {
        [ Column ]
        public string URL { get ; set ; }
    }
}