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

namespace GETIID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.Write("cscript ospp.vbs /dstatus");
            string output = process.StandardOutput.ReadToEnd();

            MessageBox.Show(output);
            process.WaitForExit();
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

        private void ACTIVATE_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void OPEN_BROWSER_Click(object sender, EventArgs e)
        {

        }
    }
}
