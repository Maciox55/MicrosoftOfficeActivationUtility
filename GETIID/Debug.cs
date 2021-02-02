using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
