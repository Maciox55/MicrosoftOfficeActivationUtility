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
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (url_textbox.Text != null || url_textbox.Text != "")
            {
                Properties.Settings.Default.url = url_textbox.Text;
                this.Close();
            }
            else {

                this.Close();
            }
        }
    }
}
