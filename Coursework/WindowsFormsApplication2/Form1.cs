using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace Coursewok
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.StatusCodeLabel.Text = "";
            this.HTMLPageDisplay.Text = "";

            string URL = this.SearchBar.Text;

            //Create a request for the URL
            if (URL != "")
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse response = null;

                // Get the response
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    //Display statuS in label
                    this.StatusCodeLabel.Text = ((HttpWebResponse)response).StatusDescription;

                    // Get the stream containing content returned by the server. 
                    // The using block ensures the stream is automatically closed. 
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.  
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.  
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.  
                        this.HTMLPageDisplay.Text = responseFromServer;
                    }

                    response.Close();
                }
                catch (WebException exception)
                {
                    if (exception.Status == WebExceptionStatus.ProtocolError)
                    {
                        response = (HttpWebResponse)exception.Response;
                        this.StatusCodeLabel.Text = response.StatusDescription;
                    }
                    else
                    {
                        this.StatusCodeLabel.Text = response.StatusDescription;
                    }
                }
                finally
                {
                    if (response != null)
                    {
                        response.Close();
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string relativePath = @"demo.DB";
            var parentdir = Path.GetDirectoryName(Application.StartupPath);
    
            string absolutePath = Path.Combine(parentdir, "Debug", "demo.DB");
            string connectionString = string.Format("Data Source={0}",absolutePath);

            var connection = new SQLiteConnection(connectionString);
           
            DataContext db = new DataContext(connection);

            Table<Favourites> FavouriteTable = db.GetTable<Favourites>();
            IQueryable<Favourites> dbQuery = from URL in FavouriteTable select URL;
            
            foreach ( var favourite in dbQuery ) {
                var result = MessageBox.Show( "URL : "+ favourite.URL ); 
            }
        }
    }
}
