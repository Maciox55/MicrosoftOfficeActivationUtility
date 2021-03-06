﻿using System;
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

namespace GETIID
{
    public partial class  Form1 : Form
    {
        public string iid;
        public string cid;
        public HttpClient client = new HttpClient();
        public string url;
        public Form1()
        {
            InitializeComponent();

            
            getIID();
            getCID();
            //updateList();

        }

        private void IID_GET_BUTTON_Click(object sender, EventArgs e)
        {
            getIID();
        }

        private void UNINSTALL_SELECTED_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(iid_textbox.Text);
        }

        private void ACTIVATE_BUTTON_Click(object sender, EventArgs e)
        {
            activateByCID(cid_textbox.Text);
        }

        private void OFFICE_ACTIVATION_BUTTON_Click(object sender, EventArgs e)
        {
            activateByKEY(officekey_textbox.Text);
        }

        private void OPEN_BROWSER_Click(object sender, EventArgs e)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            IWebDriver driver = new ChromeDriver(chromeOptions);

            
            driver.Navigate().GoToUrl(Properties.Settings.Default.url);

            driver.Manage().Window.Minimize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("1461173234025-3129f8602eccbe259104553afa8415434b4581-02de_1461173234023-2568f8602eccbe259104553afa8415434b458-10ad")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            for (int f = 0; f < 9; f++)
            {
                
                IWebElement element = driver.FindElement(By.Id("field" + (f+1)));
                element.SendKeys(iid.Substring(f * 7, 7));
                
            }

            driver.FindElement(By.Id("custom-msft-submit")).Click();
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            updateList();
        }

        private void CID_GET_BUTTON_Click(object sender, EventArgs e)
        {
            getCID();
        }
        public string get_keys() {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.Verb = "runas";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "dstatusall.bat";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            var listviewitem = new ListViewItem(getBetween(output, "key ", "-"));
            listviewitem.SubItems.Add("test");
            ACTIVE_SERIALS.Items.Add(listviewitem);
            Console.WriteLine(output);
            process.WaitForExit();
            return output;
        }
        public void updateList() {
            ACTIVE_SERIALS.Items.Clear();
            var listviewitem = new ListViewItem(get_keys());
            listviewitem.SubItems.Add("test");
            ACTIVE_SERIALS.Items.Add(listviewitem);
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
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.Verb = "runas";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "getiid.bat";
            process.StartInfo = startInfo;
            process.Start();
            //process.StandardInput.Write("cscript ospp.vbs /dstatus");
            string output = process.StandardOutput.ReadToEnd();
            iid = getBetween(output, "edition: ", "-");
            iid_textbox.Text = iid;
            process.WaitForExit();
            process.Close();
        }

        public void getCID() {
            IWebDriver driver = new ChromeDriver();
            
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


            var elements = driver.FindElements(By.XPath("//tbody/tr[@style='font-size:14pt;']/td[@align='center']"));

            if (elements != null)
            {
                foreach (var element in elements)
                {
                    Console.WriteLine(element.Text);
                    cid += element.Text;
                }
                cid_textbox.Text = cid;
                status.Text = "Status: CID retireved";

                activateByCID(cid);
            }
            else {
                status.Text = "Status: Problem getting CID";
            }
            

            driver.Quit();
        }
        public void activateByCID(string cid)
        {
            if (cid == null || cid == "")
            {
                status.Text = "Status: Please provide CID";
            }
            else {
                string command = "/c cscript //nologo ospp.vbs /actcid:" + cid;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = false;
                startInfo.Verb = "runas";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.CreateNoWindow = false;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = command;
                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
                status.Text = "Status: Activation Attempted";
                process.Close();
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
                string command = "/c cscript //nologo ospp.vbs /inpkey:" + key;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = false;
                startInfo.Verb = "runas";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.CreateNoWindow = false;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = command;
                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
                status.Text = "Status: Key Activation Attempted";
                process.Close();
            }
        }

        
    }

}
