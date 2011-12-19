using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net;
using System.Collections.Specialized;

namespace Instablitz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            htmlshizzlebrowser.Url = new Uri(appPath + "\\htmlshizzle\\oauth-signature-manizzle.htm");
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.instapaper.com/user/register");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstapaperConnector ipc = new InstapaperConnector();
            ipc.OnOAuthTokenReceived += delegate(OAuthTokenEventArgs args)
            {
                Console.WriteLine(args.OAuthToken);
                ConfigData cd = Config.GetData();
                cd.oauth_token = args.OAuthToken;
                cd.oauth_token_secret = args.OAuthTokenSecret;
                Config.Write();
            };
            ipc.GetOAuthToken(emailBox.Text, passwordBox.Text, htmlshizzlebrowser);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
