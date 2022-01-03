using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.IO.Compression;
using System.Net;
using System.Net.Http;

namespace GETIID
{
    public partial class Options_Form : Form
    {

        public Settings s;
        public XmlSerializer xser;
        public FileStream ioStreamer;
        public string path;
        public Form1 parent;
        private string responseString;
        private static readonly HttpClient client = new HttpClient();
        public Options_Form(Form1 parentForm)
        {
            InitializeComponent();
            Console.WriteLine(Directory.GetCurrentDirectory());
            string directory = Directory.GetCurrentDirectory();
            path = directory + "\\settings.xml";
            parent = parentForm;
            s = parent.settings;
            try
            {

                //ioStreamer = new FileStream(path, FileMode.Open);
                //XmlSerializer xser = new XmlSerializer(s.GetType());
                //s = (Settings)xser.Deserialize(ioStreamer);
                

                Portable_Mode.Checked = s.portable_mode;
                url_textbox.Text = s.url;
                Default_Browser_Settings.SelectedItem = s.browser_driver;
                Remote_Server_Address.Text = s.remote_server_address;
                Console.WriteLine(s.remote_server_platform);
                Remote_Server_Platform.SelectedItem = s.remote_server_platform;
                chromeversionLabel.Text = s.currentVersion;
                Console.WriteLine(s.browser_driver);
                //Close the file editing process

            }
            catch (FileNotFoundException e)
            {
                File.Create(path);

                Portable_Mode.Checked = Properties.Settings.Default.portable_mode;
                url_textbox.Text = Properties.Settings.Default.url;
                Default_Browser_Settings.SelectedItem = Properties.Settings.Default.browser_driver;
                Remote_Server_Address.Text = Properties.Settings.Default.remote_server_address;
                Remote_Server_Platform.SelectedItem = Properties.Settings.Default.remote_server_platform;
                Console.WriteLine("File Not Found, created and applied default values");

            }
            
            //url_textbox.Text = Properties.Settings.Default.url;
            //Default_Browser_Settings.SelectedItem = Properties.Settings.Default.browser_driver;
            //Remote_Server_Address.Text = Properties.Settings.Default.remote_server_address;
            //Remote_Server_Platform.SelectedItem = Properties.Settings.Default.remote_server_platform;


            //PortTextBox.Text = Properties.Settings.Default.remote_server_port;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            XmlSerializer xser = new XmlSerializer(s.GetType());
            if (responseString != null && !s.versions.Exists(v => v == responseString))
            {
               
                s.versions.Add(responseString);
            }
            else {
                Console.WriteLine("No responseString or alread in list");
            }
            
            s.url = url_textbox.Text;
            parent.settings.url = url_textbox.Text;
            Properties.Settings.Default.url = url_textbox.Text;
           
            s.browser_driver = Default_Browser_Settings.SelectedItem.ToString();
            parent.settings.browser_driver = Default_Browser_Settings.SelectedItem.ToString();
            Properties.Settings.Default.browser_driver = Default_Browser_Settings.SelectedItem.ToString();

            s.remote_server_address = Remote_Server_Address.Text;
            parent.settings.remote_server_address = Remote_Server_Address.Text;
            Properties.Settings.Default.remote_server_address = Remote_Server_Address.Text;

            s.remote_server_platform = Remote_Server_Platform.SelectedItem.ToString();
            parent.settings.remote_server_platform = Remote_Server_Platform.SelectedItem.ToString();
            Properties.Settings.Default.remote_server_platform = Remote_Server_Platform.SelectedItem.ToString();
               
            s.remote_server_port = "4444";
            parent.settings.remote_server_port = "4444";


            s.portable_mode = Portable_Mode.Checked;
            parent.settings.portable_mode = Portable_Mode.Checked;
            Properties.Settings.Default.portable_mode = Portable_Mode.Checked;
            //Save User defaults
            Properties.Settings.Default.Save();


            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            xser.Serialize(writer, s);
            writer.Close();
            parent.getSeleniumStatus(parent.settings.remote_server_address, parent.settings.remote_server_port, false);
            this.Close();
        }

        private void github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Maciox55/MicrosoftOfficeActivationUtility");
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            responseString = await client.GetStringAsync("https://chromedriver.storage.googleapis.com/LATEST_RELEASE");

            using (var client = new WebClient())
            {
                client.DownloadFile("https://chromedriver.storage.googleapis.com/" + responseString + "/chromedriver_win32.zip", "chromedriver.zip");
            }
            using (ZipArchive archive = ZipFile.Open(Directory.GetCurrentDirectory() + "/chromedriver.zip", ZipArchiveMode.Update))
            {
                Console.WriteLine(archive.GetEntry("chromedriver.exe"));
                ZipArchiveEntry file = archive.GetEntry("chromedriver.exe");
                ZipFileExtensions.ExtractToFile(file, "chromedriver.exe", true);
            }
            s.currentVersion = responseString;
            chromeversionLabel.Text = responseString;
            MessageBox.Show("Chromedriver was updated to version: " + responseString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.getSeleniumStatus(parent.settings.remote_server_address, parent.settings.remote_server_port, true);
        }
    }
}
