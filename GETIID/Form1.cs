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

namespace GETIID
{
    public partial class  Form1 : Form
    {
        public string iid;
        public int[] iidSegments;
        public HttpClient client = new HttpClient();
        public string url;
        public Form1()
        {
            InitializeComponent();


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
            string iid = getBetween(output, "edition: ", "-");
            textBox1.Text = iid;

            process.WaitForExit();

            updateList();

            url = $"https://getcid.info/api/{iid}/fupimuem1lf";

            


        }

        private void IID_GET_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void UNINSTALL_SELECTED_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private async void ACTIVATE_BUTTON_Click(object sender, EventArgs e)
        {
            string s = await getCID(url);

        }

        private void OPEN_BROWSER_Click(object sender, EventArgs e)
        {

        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            updateList();
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

        }
        public async Task getCID(string url) {

            string response = await client.GetStringAsync(url);
            Console.WriteLine(response);
        
        }
    }
}
