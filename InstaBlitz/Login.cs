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

namespace InstaBlitz
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            InstapaperConnector.GetOAuthToken(emailBox.Text, passwordBox.Text, htmlshizzlebrowser);
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
