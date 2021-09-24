using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Management;
using SeleniumExtras.WaitHelpers;

namespace GETIID
{
    public partial class  Form1 : Form
    {
        public ProductKey[] productKeys;
        public Settings settings = new Settings(); //For read only
        public string iid;
        public string cid;
        public HttpClient client = new HttpClient();

        public FileStream ioStreamer;
        public string url;
        public IWebDriver driver;
        public string path;
        public Form1()
        {
            InitializeComponent();

            string directory = Directory.GetCurrentDirectory();
            path = directory + "\\settings.xml";
            ioStreamer = new FileStream(path, FileMode.Open);
            XmlSerializer xser = new XmlSerializer(settings.GetType());
            settings = (Settings)xser.Deserialize(ioStreamer);

            Console.WriteLine(settings.url);
            Console.WriteLine(settings.remote_server_address);
            Console.WriteLine(settings.url);
            Console.WriteLine(settings.url);

            ioStreamer.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetIID();
            get_keys();
        }
        private void IID_GET_BUTTON_Click(object sender, EventArgs e)
        {
            GetIID();
        }

        private void UNINSTALL_SELECTED_BUTTON_Click(object sender, EventArgs e)
        {
            if (ACTIVE_SERIALS.SelectedItems.Count > 0 && ACTIVE_SERIALS.SelectedItems[0].SubItems[2].Text != "")
            {
                status.Text = "Status: Attempting Key Uninstall";
                string command = "/c cscript //nologo ospp.vbs /unpkey:" + ACTIVE_SERIALS.SelectedItems[0].SubItems[2].Text.Trim();
                CMDCommand(command,true,true);
                updateList();
            }
            else {
                status.Text = "Status: Please select a valid item with key from the list.";
            }
        }

        private void ACTIVATE_BUTTON_Click(object sender, EventArgs e)
        {
            ActivateByCID(cid_textbox.Text);
        }

        private void OFFICE_ACTIVATION_BUTTON_Click(object sender, EventArgs e)
        {
            ActivateByKEY(officekey_textbox.Text);
            
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            updateList();
        }

        private void CID_GET_BUTTON_Click(object sender, EventArgs e)
        {
            GetCID();
        }

        public void get_keys() {
            string command = "/c cscript //nologo ospp.vbs /dstatusall";
            
            string output = CMDCommand(command,true,false);


            output = output.Remove(0, Convert.ToString(output).Split('\n').FirstOrDefault().Length + 1);//Remove the first PROCESSING line.
            string[] separators = {"---------------------------------------"};
            string[] sets = output.Split(separators, StringSplitOptions.RemoveEmptyEntries); //Separate the sets of keys into 3 
            Array.Resize(ref sets, sets.Length - 2); //Remove the two trailing EXITING and --- lines.

            foreach (var entry in sets)
            {
                string[] sep = { "\r\n" };
                string[] lines = entry.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                ProductKey pk = new ProductKey();
                
                foreach (var line in lines)
                {
                    string[] values = line.Split(':');

                    switch (values[0])
                    {
                        case "SKU ID":
                            pk.SKUID = values[1];
                            break;
                        case "LICENSE NAME":
                            pk.LicenseName = values[1];
                            break;
                        case "LICENSE DESCRIPTION":
                            pk.LicenseDesc = values[1];
                            break;
                        case "LICENSE STATUS":
                            pk.LicenseStatus = values[1];
                            break;
                        case "ERROR CODE":
                            pk.ErrorCode = values[1];
                            break;
                        case "ERROR DESCRIPTION":
                            pk.ErrorDescription = values[1];
                            break;
                        case "Last 5 characters of installed product key":
                            pk.LicenseKey = values[1];
                            break;
                    }
                }
                
                var listviewitem = new ListViewItem();
                listviewitem.Text = pk.SKUID;
                listviewitem.SubItems.Add(pk.LicenseName);
                listviewitem.SubItems.Add(pk.LicenseKey);
                listviewitem.SubItems.Add(pk.LicenseDesc);
                listviewitem.SubItems.Add(pk.LicenseStatus);
                listviewitem.Tag = pk;
                ACTIVE_SERIALS.Items.Add(listviewitem);
            }

            string pattern = @"(.+:)|(\w.*[a-zA-Z0-9])";
            Regex r = new Regex(pattern);
            Match m = r.Match(output);
            int matchCount = 0;
            if (m.Success)
            {
                Console.WriteLine("Match" + (++matchCount));
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    Console.WriteLine("Group"+i+"="+g);
                }
            }
        }
        public void updateList() {
            ACTIVE_SERIALS.Items.Clear();
            get_keys();
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return "";
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionsForm = new Options_Form();
            optionsForm.Show();
        }

        public void GetIID() {
            string command = "/c cscript //nologo ospp.vbs /dinstid";
            string output = CMDCommand(command,true,false);
            iid = getBetween(output, "edition: ", "-");
            iid_textbox.Text = iid;
        }

        public void GetCID() { 
            try
            {
                cid = "";
                if (settings.portable_mode == false)
                {
                    if (settings.browser_driver == "chrome")
                    {
                        driver = new ChromeDriver();
                    }
                    else if (settings.browser_driver == "edge")
                    {
                        var options = new EdgeOptions();
                        options.UseChromium = true;
                        driver = new EdgeDriver(options);
                    }
                }
                else if (settings.portable_mode == true)
                {
                    if (settings.browser_driver == "chrome")
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("no-sandbox");
                        //chromeOptions.AddArgument("no-sandbox");
                        chromeOptions.PlatformName = settings.remote_server_platform;

                        
                        driver = new RemoteWebDriver(new Uri("http://" + settings.remote_server_address + "/wd/hub"),chromeOptions.ToCapabilities());
                        //ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;
                        //Console.WriteLine((capabilities.GetCapability("chrome") as Dictionary<string, object>)["chromedriverVersion"]);
                    }
                    else if (settings.browser_driver == "edge")
                    {
                        var options = new EdgeOptions();
                        options.UseChromium = true;
                        options.PlatformName = settings.remote_server_platform;
                        driver = new RemoteWebDriver(new Uri("http://" + settings.remote_server_address + "/wd/hub"), options);
                    }

                }

                driver.Navigate().GoToUrl(settings.url);
                var wait = new WebDriverWait(driver,new TimeSpan(0, 0, 30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("1461173234025-3129f8602eccbe259104553afa8415434b4581-02de_1461173234023-2568f8602eccbe259104553afa8415434b458-10ad")));
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.Id("1461173234025-3129f8602eccbe259104553afa8415434b4581-02de_1461173234023-2568f8602eccbe259104553afa8415434b458-10ad")).Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("field")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                for (int f = 0; f < 9; f++)
                {
                    IWebElement element = driver.FindElement(By.Id("field" + (f + 1)));
                    element.SendKeys(iid.Substring(f * 7, 7));
                }
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("custom-msft-submit")));
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.Id("custom-msft-submit")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                var numinstalls = WaitUntilElementVisible(driver, "numberOfInstalls", 3);

                if (numinstalls != null)
                {
                    numinstalls.SendKeys("0");
                    driver.FindElement(By.Id("custom-msft-submit")).Click();
                }

                var elements = driver.FindElements(By.XPath("//tbody/tr[@style='font-size:14pt;']/td[@align='center']"));

                if (elements != null)
                {

                    foreach (var element in elements)
                    {
                        Console.WriteLine(element.Text);
                        cid += element.Text;
                    }
                    cid_textbox.Text = cid;
                    status.Text = "Status: CID retireved, ready for activation";

                    //activateByCID(cid);
                }
                else
                {
                    status.Text = "Status: Problem getting CID";
                }
               
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                MessageBox.Show("Oops! " + e.Message);
                driver.Close();
                driver.Quit();
            }
            driver.Close();
            driver.Quit();
        }

        public void ActivateByCID(string tcid)
        {
            if (tcid == null || tcid == "")
            {
                status.Text = "Status: Please provide CID";
            }
            else {
                string command = "/c cscript //nologo ospp.vbs /actcid:" + tcid;
                CMDCommand(command,true,false);
                status.Text = "Status: CID Activation Attempted";
            }
        }

        public void ActivateByKEY(string key)
        {
            if (key == null || key == "")
            {
                status.Text = "Status: Please provide Office Key";
            }
            else
            {
                string command = "/c cscript //nologo ospp.vbs /inpkey:" + key;
                CMDCommand(command,true,true);
                updateList();
                GetIID();
                GetCID();
                ActivateByCID(cid_textbox.Text);
                status.Text = "Status: Key Activation Attempted";
            }

        }
        public static IWebElement WaitUntilElementVisible(IWebDriver drvr,string elementSelector, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(drvr, new TimeSpan(0, 0, timeout));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(elementSelector)));
                return element;
            }
            catch (Exception e)
            {
                if (e is NoSuchElementException)
                {
                    MessageBox.Show("Oops! " + e.Message);
                    return null;
                }
                else if (e is WebDriverTimeoutException)
                {
                    //MessageBox.Show("Oops! " + e.Message);
                    Console.WriteLine("Could not find the Number of installs element, moving on.");
                    return null;
                }
                else
                {
                    MessageBox.Show("Oops! " + e.Message);
                    return null;
                }
            }
        }

        public string CMDCommand(string command, bool noWindow, bool shellexe)
        {
            
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = noWindow,
                FileName = "cmd.exe",
                UseShellExecute = shellexe,
                Verb = "runas",
                Arguments = command
            };


            if (shellexe == false)
            {
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
                return output;
            }
            else {
                process.StartInfo = startInfo;
                process.Start();
                return null;
            }
            
        }
        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var debug = new DebugMenu();
            debug.Show();
        }
        private void cid_textbox_TextChanged(object sender, EventArgs e)
        {
            
            ACTIVATE_BUTTON.Enabled = !string.IsNullOrWhiteSpace(cid_textbox.Text);
            
        }
    }
}
