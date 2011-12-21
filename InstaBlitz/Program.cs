using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using InstaBlitz;

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

            Application.Run(new BookmarkBrowser());
            
            

            

            
            //if (c.oauth_token.Length > 0)
            //    new InstapaperConnector().GetFolderList(c.oauth_token, c.oauth_token_secret);
            //else

        }
    }
}
