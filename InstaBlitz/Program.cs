using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace Instablitz
{
    static class Program
    {
        public static bool IsConnected()
        {
            Ping p = new Ping();
            PingReply pr;
            try
            {
                pr = p.Send("google.com");
            }
            catch
            {
                return false;
            }
            
            return pr.Status == IPStatus.Success;
        }

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
            Console.WriteLine("start");
            if (IsConnected())
                Application.Run(new Login());
            else
                MessageBox.Show("offline");

            
            //if (c.oauth_token.Length > 0)
            //    new InstapaperConnector().GetFolderList(c.oauth_token, c.oauth_token_secret);
            //else
                

            Console.WriteLine("Read config: " + c);
        }
    }
}
