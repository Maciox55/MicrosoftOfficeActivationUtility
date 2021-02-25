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
using DYMO.Label.Framework;
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Find browser";
            dialog.Filter = "Label files|*.label";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                
                var label = DYMO.Label.Framework.Label.Open(dialog.FileName);
                label.SetObjectText("Office_Key", "Testing");
                label.Print("DYMO LabelWriter 450 Turbo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.BrowserName = "chrome";

            chromeOptions.PlatformName = "windows";
            IWebDriver driver = new RemoteWebDriver(new Uri("http://" + Properties.Settings.Default.remote_server_address + "/wd/hub"), chromeOptions);
            driver.Navigate().GoToUrl(Properties.Settings.Default.url);
        }
    }
}
