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
using InstaBlitz;

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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            emailBox.Focus();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginButton.Text = "Loading...";
            LoginButton.Enabled = false;

            InstapaperConnector ipc = new InstapaperConnector(new OAuthHelper(htmlshizzlebrowser));
            ipc.OnOAuthFail += delegate(String message)
            {
                MessageBox.Show(this, message, "Login error");
                LoginButton.Text = "Login";
                LoginButton.Enabled = true;
                emailBox.Focus();
            };
            ipc.OnOAuthTokenReceived += delegate(OAuthTokenEventArgs args)
            {
                Console.WriteLine(args.OAuthToken);
                ConfigData cd = Config.GetData();
                cd.oauth_token = args.OAuthToken;
                cd.oauth_token_secret = args.OAuthTokenSecret;
                Config.Write();
                MessageBox.Show("Your Token has been created", "Success");
            };
            
            //ipc.GetOAuthToken(emailBox.Text, passwordBox.Text);
            ipc.VerifyCredentials();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
