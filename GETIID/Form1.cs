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
using System.Net;
using Newtonsoft.Json;

namespace GETIID
{
    public partial class  Form1 : Form
    {
        public ProductKey[] productKeys;
        public Settings settings = new Settings(); //For read only
        public string iid;
        public string cid;

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
            getSeleniumStatus(settings.remote_server_address, settings.remote_server_port);



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
                //Console.WriteLine("Match" + (++matchCount));
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    //Console.WriteLine("Group"+i+"="+g);
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
            var optionsForm = new Options_Form(this);
            optionsForm.Show();
        }

        public void GetIID() {
            string command = "/c cscript //nologo ospp.vbs /dinstid";
            string output = CMDCommand(command,true,false);
            iid = getBetween(output, "edition: ", "-");
            iid_textbox.Text = iid;
        }

        public void GetCID() { 
            //try
            //{
                cid = "";
                progressBar.Value = 0;
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
                        chromeOptions.PlatformName = settings.remote_server_platform;
                        
                        driver = new RemoteWebDriver(new Uri("http://" + settings.remote_server_address + "/wd/hub"),chromeOptions.ToCapabilities());
                    }
                    else if (settings.browser_driver == "edge")
                    {
                        var options = new EdgeOptions();
                        options.UseChromium = true;
                        options.PlatformName = settings.remote_server_platform;
                        driver = new RemoteWebDriver(new Uri("http://" + settings.remote_server_address + "/wd/hub"), options);
                    }
                }
                 progressBar.Increment(10);
                driver.Navigate().GoToUrl(settings.url);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                //Selcting the 7-segment button
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("1461173234025-3129f8602eccbe259104553afa8415434b4581-02de_1461173234023-2568f8602eccbe259104553afa8415434b458-10ad")));
                    driver.FindElement(By.Id("1461173234025-3129f8602eccbe259104553afa8415434b4581-02de_1461173234023-2568f8602eccbe259104553afa8415434b458-10ad")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                    progressBar.Increment(10);
            }
                catch (Exception e) {
                    driver.Close();
                    driver.Quit();
                    MessageBox.Show("Could not find the key type selection button on the page. Verify the button ID in the Inspector");
                };

                //Inputting the IID into the 9, 7-segment fields
                try
                {
                    for (int f = 0; f < 9; f++)
                    {
                        IWebElement element = driver.FindElement(By.Id("field" + (f + 1)));
                        element.SendKeys(iid.Substring(f * 7, 7));
                    }
                    progressBar.Increment(10);
            }
                catch (Exception e)
                { 
                    driver.Close();
                    driver.Quit();
                    MessageBox.Show("Encountered problem with inputting the 7-character segments of the IID, try again.");

            }

            //Submit the IID
            try {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("custom-msft-submit")));
                    driver.FindElement(By.Id("custom-msft-submit")).Click();
                    progressBar.Increment(10);
            }
                catch (Exception e) { 
                    driver.Close();
                    driver.Quit();
                    MessageBox.Show("Encountered problem with submitting the 7-character segments of the IID, try again.");
            }

            //Input the amount of times the key has been activated
            try
            {
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='numberOfInstalls']")));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("numberOfInstalls")));
                progressBar.Increment(10);
                //IWebElement numinstalls = driver.FindElement(By.XPath("//*[@id='numberOfInstalls']"));

                if (element != null)
                {
                    element.SendKeys("0");
                    driver.FindElement(By.Id("custom-msft-submit")).Click();
                }
                else
                {
                    Console.WriteLine("Number of installs not found");
                    throw new Exception();
                }
            }
            catch (NoSuchElementException e)
            {
                MessageBox.Show("Encountered problem with finding and submitting the amount of times the key has been activated, try again.");
            }
            catch (Exception f)
            {
                if (f is WebDriverTimeoutException ||f is NullReferenceException)
                {
                    Console.WriteLine("Could not find the number of installs element, try again.");
                }
            }

            //Returning the CID, or not
            try
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='index - page']/body/div[2]/div[2]/div/div/p/p[1]")));
                //Key not valid
                IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='index - page']/body/div[2]/div[2]/div/div/p/p[1]")));
                Console.WriteLine(ele);
                if (ele != null)
                {
                    MessageBox.Show("The entered Key is NOT VALID, please try activating using another key.");
                }

            }
            catch (NoSuchElementException e)
            {
                driver.Close();
                driver.Quit();
                MessageBox.Show("Encountered problem with finding and submitting the amount of times the key has been activated, try again!");

            }
            catch (WebDriverTimeoutException el)
            {
                try
                {
                    //wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='index - page']/body/div[2]/div[2]/div/div[1]/p/p[1]/text()")));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//tbody/tr[@style='font-size:14pt;']/td[@align='center']")));
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
                        progressBar.Increment(10);
                        //activateByCID(cid);
                    }
                    else
                    {
                        //status.Text = "Status: Problem getting CID";
                        MessageBox.Show("Problem reading CID from page, try again a few times, otherwise key is invalid");
                    }
                }
                catch (NoSuchElementException e)
                {
                    try
                    {
                        var textElement = driver.FindElements(By.XPath("//tbody/tr[@style='font-size:14pt;']/td[@align='center']"));
                        progressBar.Increment(10);
                    }
                    catch (NoSuchElementException ex)
                    {
                        driver.Close();
                        driver.Quit();
                        MessageBox.Show("Encountered problem with finding and submitting the amount of times the key has been activated, try again!");

                    }
                }
            }
            progressBar.Value = 70;
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
                var wait = new WebDriverWait(drvr, TimeSpan.FromSeconds(timeout));
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

        public void getSeleniumStatus(string ip, string port)
        {
            try
            {
                string conn = "http://"+ip + ":" + port + "/wd/hub/status";
                Console.WriteLine(ip);
                var json = new WebClient().DownloadString("http://"+ip+"/wd/hub/status");
                Root response = JsonConvert.DeserializeObject<Root>(json);
                Console.WriteLine("Checking If Selenium Server is ready.");
                Console.WriteLine(response.status);

                if (response.status == 0 && response.value.ready)
                {
                    connectonStatus.Text = "Selenium Server Detected";
                    connectonStatus.ForeColor = System.Drawing.Color.Green;
                }
                else {
                    connectonStatus.Text = "Selenium Server Detected, but not all services may be running";
                    connectonStatus.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception e){
                MessageBox.Show(e.Message);
                connectonStatus.Text = "Error connecting to Selenium Server, check if server is running";
                connectonStatus.ForeColor = System.Drawing.Color.Red;
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

public class Build
{
    public string revision { get; set; }
    public DateTime time { get; set; }
    public string version { get; set; }
}

public class Os
{
    public string arch { get; set; }
    public string name { get; set; }
    public string version { get; set; }
}

public class Java
{
    public string version { get; set; }
}

public class Value
{
    public bool ready { get; set; }
    public string message { get; set; }
    public Build build { get; set; }
    public Os os { get; set; }
    public Java java { get; set; }
}

public class Root
{
    public int status { get; set; }
    public Value value { get; set; }
}