using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (url_textbox.Text != null || url_textbox.Text != "")
            {
                Properties.Settings.Default.url = url_textbox.Text;
            }
            else {

                this.Close();
            }
            if (Default_Browser_Settings.SelectedItem.ToString() != Properties.Settings.Default.browser_driver)
            {
                Properties.Settings.Default.browser_driver = Default_Browser_Settings.SelectedItem.ToString();
            }

            if (Binary_Location_Textbox.Text != null || Binary_Location_Textbox.Text !="")
            {
                Properties.Settings.Default.browser_binary_location = Binary_Location_Textbox.Text;
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
            dialog.Title = "Find driver";
            dialog.Filter = "EXE files|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Binary_Location_Textbox.Text = dialog.FileName;
            }

         }
    }
}
