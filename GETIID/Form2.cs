using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GETIID
{
    public partial class Options_Form : Form
    {

        public Settings s;
        public XmlSerializer xser;
        public FileStream ioStreamer;
        public string path;
        public Options_Form()
        {
            InitializeComponent();
            Console.WriteLine(Directory.GetCurrentDirectory());
            string directory = Directory.GetCurrentDirectory();
            path = directory + "\\settings.xml";
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
                Console.WriteLine(s.browser_driver);
                ioStreamer.Close();
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

                s.url = url_textbox.Text;
                Properties.Settings.Default.url = url_textbox.Text;

                s.browser_driver = Default_Browser_Settings.SelectedItem.ToString();
                Console.WriteLine(s.browser_driver);
                Properties.Settings.Default.browser_driver = Default_Browser_Settings.SelectedItem.ToString();

                s.remote_server_address = Remote_Server_Address.Text;
                Properties.Settings.Default.remote_server_address = Remote_Server_Address.Text;

                s.remote_server_platform = Remote_Server_Platform.SelectedItem.ToString();
                Properties.Settings.Default.remote_server_platform = Remote_Server_Platform.SelectedItem.ToString();
                s.remote_server_port = "4444";


            s.portable_mode = Portable_Mode.Checked;
            Properties.Settings.Default.portable_mode = Portable_Mode.Checked;
            Properties.Settings.Default.Save();


            XmlTextWriter writer =
      new XmlTextWriter(path, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            xser.Serialize(writer, s);
            writer.Close();
            this.Close();
        }

        private void github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Maciox55/MicrosoftOfficeActivationUtility");
        }
    }
}
