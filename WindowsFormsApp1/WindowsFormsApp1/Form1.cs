using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            private DataContext _mappedDatabase;
            
            [ Table ( Name = "Tabs") ]
            public class Tabs
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
            }
            
            Tabs tab = new Tabs()
            {
                Url = "",
                Title = "",
                Visits = 0,
                LastLoad = "",
                Id = null
            };

            TabsTable.InsertOnSubmit(tab);
            
            try
            {
                _mappedDatabase.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _mappedDatabase.SubmitChanges();
            }
            
            _mappedDatabase.Refresh(RefreshMode.KeepCurrentValues);
        }

    internal class DataContext
    {
    }
}
}