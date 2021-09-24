using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
//using MongoDB.Driver;
//using MongoDB.Bson;
namespace GETIID
{
    public partial class DebugMenu : Form
    {
        public DebugMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Title = "Find browser";
            //dialog.Filter = "Label files|*.label";

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{

            //var label = DYMO.Label.Framework.Label.Open(dialog.FileName);
            //label.SetObjectText("Office_Key", "Testing");
            //label.Print("DYMO LabelWriter 450 Turbo");
            //}
            
            //DYMO.Label.Framework.Printers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MongoClient dbClient = new MongoClient("mongodb://root:Macioxxx1@192.168.1.140:27018");
            //var dblist = dbClient.ListDatabases().ToList();
            //var db = dbClient.GetDatabase("IIDGet");
            //var collection = db.GetCollection<BsonDocument>("officeLicenses");

            //var document = new BsonDocument { {"SKU ID", 10000} };
            //collection.InsertOne(document);
        }
    }
}
