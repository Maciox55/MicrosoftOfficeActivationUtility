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
using System.Management;
using SeleniumExtras.WaitHelpers;

namespace GETIID
{
    public partial class  Form1 : Form
    {
        public ProductKey[] productKeys;
        public string iid;
        public string cid;
        public HttpClient client = new HttpClient();
        public string url;
        public IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getIID();
            get_keys();
        }
        private void IID_GET_BUTTON_Click(object sender, EventArgs e)
        {
            getIID();
        }

        private void UNINSTALL_SELECTED_BUTTON_Click(object sender, EventArgs e)
        {
            if (ACTIVE_SERIALS.SelectedItems.Count > 0 && ACTIVE_SERIALS.SelectedItems[0].SubItems[2].Text != "")
            {
                status.Text = "Status: Attempting Key Uninstall";
                string command = "/c cscript //nologo ospp.vbs /unpkey:" + ACTIVE_SERIALS.SelectedItems[0].SubItems[2].Text.Trim();
                CMDCommand(command,true,true);
                Console.WriteLine(ACTIVE_SERIALS.SelectedItems[0].SubItems[2].Text.Trim());
            }
            else {
                status.Text = "Status: Please select a valid item with key from the list.";
            }
        }

        private void ACTIVATE_BUTTON_Click(object sender, EventArgs e)
        {
            activateByCID(cid_textbox.Text);
        }

        private void OFFICE_ACTIVATION_BUTTON_Click(object sender, EventArgs e)
        {
            activateByKEY(officekey_textbox.Text);
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            updateList();
        }

        private void CID_GET_BUTTON_Click(object sender, EventArgs e)
        {
            getCID();
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

        public void getIID() {
            string command = "/c cscript //nologo ospp.vbs /dinstid";
            string output = CMDCommand(command,true,false);
            iid = getBetween(output, "edition: ", "-");
            iid_textbox.Text = iid;
        }

        public void getCID() {

            try
            {
                if (Properties.Settings.Default.portable_mode == false)
                {
                    if (Properties.Settings.Default.browser_driver == "chrome")
                    {
                        driver = new ChromeDriver();
                    }
                    else if (Properties.Settings.Default.browser_driver == "edge")
                    {
                        var options = new EdgeOptions();
                        options.UseChromium = true;
                        driver = new EdgeDriver(options);
                    }
                }
                else if (Properties.Settings.Default.portable_mode == true)
                {
                    if (Properties.Settings.Default.browser_driver == "chrome")
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.PlatformName = Properties.Settings.Default.remote_server_platform;
                        driver = new RemoteWebDriver(new Uri("http://" + Properties.Settings.Default.remote_server_address + "/wd/hub"), chromeOptions);
                        
                    }
                    else if (Properties.Settings.Default.browser_driver == "edge")
                    {
                        var options = new EdgeOptions();
                        options.UseChromium = true;
                        options.PlatformName = Properties.Settings.Default.remote_server_platform;
                        driver = new RemoteWebDriver(new Uri("http://" + Properties.Settings.Default.remote_server_address + "/wd/hub"), options);
                    }

                }

                driver.Navigate().GoToUrl(Properties.Settings.Default.url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.Id("1461173234025-3129f8602eccbe259104553afa8415434b4581-02de_1461173234023-2568f8602eccbe259104553afa8415434b458-10ad")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


                for (int f = 0; f < 9; f++)
                {

                    IWebElement element = driver.FindElement(By.Id("field" + (f + 1)));
                    element.SendKeys(iid.Substring(f * 7, 7));
                }

                driver.FindElement(By.Id("custom-msft-submit")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                var numinstalls = WaitUntilElementVisible(driver, "numberOfInstalls", 10);

                if (numinstalls != null)
                {
                    numinstalls.SendKeys("0");
                    driver.FindElement(By.Id("custom-msft-submit")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
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

                driver.Quit();
            }
            catch(Exception e){
                MessageBox.Show("Oops! " + e.Message);

            }
        }
        public void activateByCID(string cid)
        {
            if (cid == null || cid == "")
            {
                status.Text = "Status: Please provide CID";
            }
            else {
                string command = "/c cscript //nologo ospp.vbs /actcid:" + cid;
                string output = CMDCommand(command,true,true);
                status.Text = "Status: CID Activation Attempted";
            }
        }

        public void activateByKEY(string key)
        {
            if (key == null || key == "")
            {
                status.Text = "Status: Please provide Office Key";
            }
            else
            {
                string command = "/c /user:Administrator cscript //nologo ospp.vbs /inpkey:" + key;
                string output = CMDCommand(command,false,true);
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
                    MessageBox.Show("Oops! " + e.Message);
                    return null;
                }
                else
                { 
                    
                }

                return null;
            }
        }

        public string CMDCommand(string command, bool noWindow, bool shellexe)
        {
            
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = noWindow;
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = shellexe;
            startInfo.Verb = "runas";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();

            if (shellexe == false)
            {
                string output = process.StandardOutput.ReadToEnd();
                return output;
            }
            else {
                return null;
            }
            process.WaitForExit();
            process.Close();
            
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
