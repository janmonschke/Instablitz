using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;

namespace Instablitz
{
    static class Program
    {

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Get the config
            ConfigData c = Config.GetData();
            if (c.oauth_token.Length > 0)
                MessageBox.Show("Woohooo, you've already been authenticated before");
            else
                Application.Run(new Login());

            Console.WriteLine("Read config: " + c);
        }
    }
}
