using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System.Xml.Serialization;
using SeleniumExtras.WaitHelpers;
using System.Net.Http;
using System.Net;
using System.IO.Compression;

namespace GETIID
{
    public partial class DebugMenu : Form
    {
        public Settings settings = new Settings(); //For read only
        public FileStream ioStreamer;
        public string url;
        public IWebDriver driver;
        public string path;
        public Uri latestVersionUrl;
        public string responseString;
        private static readonly HttpClient client = new HttpClient();
        public DebugMenu()
        {

            InitializeComponent();
            string directory = Directory.GetCurrentDirectory();
            path = directory + "\\settings.xml";
            ioStreamer = new FileStream(path, FileMode.Open);
            XmlSerializer xser = new XmlSerializer(settings.GetType());
            settings = (Settings)xser.Deserialize(ioStreamer);
            //latestVersionUrl = new Uri("https://chromedriver.storage.googleapis.com/LATEST_RELEASE");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //InvalidOperationException

            get();
            //try
            //{
            //    driver = new ChromeDriver();
            //    //driver.Navigate().GoToUrl(settings.url);
            //    //driver.Quit();
            //    MessageBox.Show("Chrome driver is up to date.");
                
            //}
            //catch (InvalidOperationException ee) {

            //    get();
            //}

        }
        private async void get() { 

            var responseString = await client.GetStringAsync("https://chromedriver.storage.googleapis.com/LATEST_RELEASE");

            using (var client = new WebClient())
            {
                client.DownloadFile("https://chromedriver.storage.googleapis.com/"+responseString+"/chromedriver_win32.zip", "chromedriver.zip");
            }
            using (ZipArchive archive = ZipFile.Open(Directory.GetCurrentDirectory()+"/chromedriver.zip", ZipArchiveMode.Update))
            {
                Console.WriteLine(archive.GetEntry("chromedriver.exe"));
                ZipArchiveEntry file = archive.GetEntry("chromedriver.exe");
                ZipFileExtensions.ExtractToFile(file , "chromedriver.exe", true);
            }
            MessageBox.Show("Chromedriver was updated to version: " + responseString);
        }
    }
}
