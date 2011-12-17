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

            appPath = appPath.Replace("\\bin\\Debug","\\htmlshizzle\\oauth-signature-manizzle.htm");
            appPath = appPath.Replace("\\bin\\Release", "\\htmlshizzle\\oauth-signature-manizzle.htm");

            htmlshizzlebrowser.Url = new Uri(appPath);
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            String[] scriptParams = { emailBox.Text, passwordBox.Text };
            String oauthShizzle = (String) htmlshizzlebrowser.Document.InvokeScript("signParams", scriptParams);
            String[] splitted = oauthShizzle.Split('|');
            String signature = splitted[0];

            String NormalizedRequestParameters = splitted[1];
            String url = "https://www.instapaper.com/api/1/oauth/access_token";

            WebRequest wr = WebRequest.Create(url);
            wr.Method = "POST";
            String body = NormalizedRequestParameters + "&oauth_signature=" + signature;
            wr.Headers.Set(HttpRequestHeader.Authorization, body);
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.ContentLength = body.Length;
            Stream r = wr.GetRequestStream();
            StreamWriter sr = new StreamWriter(r);
            Console.WriteLine("========BODY=========");
            for (int i = 0; i < body.Length; i++)
            {
                sr.Write(body[i]);
                Console.Write(body[i]);
            }
            Console.WriteLine();
            Console.WriteLine("========/BODY=========");
            sr.Close();
            r.Close();



            try
            {
                WebResponse res = wr.GetResponse();
                Console.WriteLine("========RESPONSE=========");
                Stream s = res.GetResponseStream();
                StreamReader sr2 = new StreamReader(s);
                String response = sr2.ReadToEnd();
                NameValueCollection values = System.Web.HttpUtility.ParseQueryString(response);

                Console.Write(response);
                Console.WriteLine("========/RESPONSE=========");
                s.Close();
                sr2.Close();
            }
            catch (WebException we)
            {
                Console.WriteLine("========RESPONSE ERROR=========");

                Stream s = we.Response.GetResponseStream();
                StreamReader sr2 = new StreamReader(s);
                Console.WriteLine(sr2.ReadToEnd());
                sr2.Close();
                s.Close();
                Console.WriteLine("========EXCEPTION MESSAGE=========");
                Console.WriteLine(we);
                Console.WriteLine("========/RESPONSE ERROR=========");
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
