using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bluegrams.Application;
namespace GETIID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            //PortableJsonSettingsProvider.SettingsFileName = "portable.config";
            //PortableSettingsProvider.SettingsDirectory = "c:\\testconfig\\school";
            //System.IO.Directory.CreateDirectory(PortableSettingsProvider.SettingsDirectory);
            PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
                Application.Run(new Form1());

            

        }
    }
}
