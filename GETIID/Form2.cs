using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GETIID
{
    public partial class Options_Form : Form
    {
        public Options_Form()
        {
            InitializeComponent();

            url_textbox.Text = Properties.Settings.Default.url;
            Default_Browser_Settings.SelectedItem = Properties.Settings.Default.browser_driver;
            Binary_Location_Textbox.Text = Properties.Settings.Default.browser_binary_location;
            Remote_Server_Address.Text = Properties.Settings.Default.remote_server_address;
            Remote_Server_Platform.SelectedItem = Properties.Settings.Default.remote_server_platform;
            Licenses_Location_Textbox.Text = Properties.Settings.Default.licenses_location;

            //DB Settings
            ipAddressTextBox.Text = Properties.Settings.Default.db_ipaddress;
            db_UsernameTextBox.Text = Properties.Settings.Default.db_username;
            db_PasswordTextBox.Text = Properties.Settings.Default.db_password; //I know it's not secure, tool will only be used in a local network environment therefore no real security needed.
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (url_textbox.Text != null || url_textbox.Text != "")
            {
                Properties.Settings.Default.url = url_textbox.Text;
            }
            if (Default_Browser_Settings.SelectedItem.ToString() != Properties.Settings.Default.browser_driver)
            {
                Properties.Settings.Default.browser_driver = Default_Browser_Settings.SelectedItem.ToString();
            }
            if (Binary_Location_Textbox.Text != null || Binary_Location_Textbox.Text !="")
            {
                Properties.Settings.Default.browser_binary_location = Binary_Location_Textbox.Text;
            }
            if (Driver_Location_Textbox.Text != null || Driver_Location_Textbox.Text != "")
            {
                Properties.Settings.Default.browser_driver_location = Driver_Location_Textbox.Text;
            }
            if (Remote_Server_Address != null || Remote_Server_Address.Text != "")
            {
                Properties.Settings.Default.remote_server_address = Remote_Server_Address.Text;
            }
            if (Remote_Server_Platform.SelectedText != Properties.Settings.Default.remote_server_platform)
            {
                Properties.Settings.Default.remote_server_platform = Remote_Server_Platform.SelectedItem.ToString();
            }
            if (Licenses_Location_Textbox.Text != Properties.Settings.Default.licenses_location)
            {
                Properties.Settings.Default.licenses_location = Licenses_Location_Textbox.Text;
            }

            //DB Settings
            if (ipAddressTextBox.Text != Properties.Settings.Default.db_ipaddress)
            {
                Properties.Settings.Default.db_ipaddress = ipAddressTextBox.Text;
            }
            if (db_UsernameTextBox.Text != Properties.Settings.Default.licenses_location)
            {
                Properties.Settings.Default.db_username = db_UsernameTextBox.Text;
            }
            if (db_PasswordTextBox.Text != Properties.Settings.Default.licenses_location)
            {
                Properties.Settings.Default.db_password = db_PasswordTextBox.Text;
            }

            Properties.Settings.Default.portable_mode = Portable_Mode.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Maciox55/MicrosoftOfficeActivationUtility");
        }

        private void Find_Binary_Location_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Find browser";
            dialog.Filter = "EXE files|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Binary_Location_Textbox.Text = dialog.FileName;
            }
        }

        private void Driver_Location_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Find driver";
            dialog.Filter = "EXE files|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Driver_Location_Textbox.Text = dialog.FileName;
            }
        }

        private void Office_Licenes_Location_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                Licenses_Location_Textbox.Text = dialog.SelectedPath;
            }
        }
    }
}
