using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Coursewok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.HTTPResponseStatus.Text = "";
            this.HTTPStreamContent.Text = "";

            var values = new Dictionary<string, string>
            {
                {"thing1", "hello" },
                {"thing2", "world" }
            };

            string URL = this.URLContent.Text;

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
                    this.HTTPResponseStatus.Text = ((HttpWebResponse)response).StatusDescription;

                    // Get the stream containing content returned by the server. 
                    // The using block ensures the stream is automatically closed. 
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.  
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.  
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.  
                        this.HTTPStreamContent.Text = responseFromServer;
                    }

                    response.Close();
                }
                catch (WebException exception)
                {
                    if (exception.Status == WebExceptionStatus.ProtocolError)
                    {
                        response = (HttpWebResponse)exception.Response;
                        this.HTTPResponseStatus.Text = response.StatusDescription;
                    }
                    else
                    {
                        this.HTTPResponseStatus.Text = response.StatusDescription;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
