using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Instablitz;
using System.Net.NetworkInformation;
using InstaBlitz.Models;
using System.IO;
using System.Reflection;

namespace InstaBlitz
{
    public partial class BookmarkBrowser : Form
    {
        public BookmarkBrowser()
        {
            InitializeComponent();
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            theBrowser.Url = new Uri(appPath + "\\htmlshizzle\\oauth-signature-manizzle.htm");
        }

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

        private InstapaperConnector connector = null;

        private InstapaperConnector getConnector()
        {
            return this.connector == null ? new InstapaperConnector(new OAuthHelper(theBrowser)) : this.connector;
        }

        private void displayData()
        {
            

            
            Folder f = new Folder(getConnector());
            f.Id = Folder.UNREAD;

            f.OnBookmarksReceived += delegate(List<Bookmark> bookmarks)
            {
                Console.WriteLine("received " + bookmarks.Count);
                foreach(Bookmark b in bookmarks)
                    Console.WriteLine("Title: " + b.Title + " Starred? " + b.Starred);
            };

            f.OnFoldersReceived += delegate(List<Folder> folders) {
                Console.WriteLine("got themmmmm " + folders.Count);
            };
            
            f.GetBookmarks();

            //getConnector().VerifyCredentials();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BookmarkList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FolderList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // ask the user if he really wants to logout
            DialogResult res = MessageBox.Show("Are you sure you want to logout? (All cached data will get lost)", "Confirm Logout", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Config.Delete();
                // show the login view when he logged out
                DialogResult dr = new Login().ShowDialog(this);
                Console.WriteLine(dr);
                // when the login view has been cancelled, close the program
                if (dr == DialogResult.Cancel)
                    this.Close();
                else
                    this.displayData();
            }
        }

        private void BookmarkBrowser_Load(object sender, EventArgs e)
        {

        }

        private void theBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ConfigData cd = Config.GetData();
            DialogResult dr;
            if (IsConnected())
                if (!cd.IsUserAuthenticated())
                {
                    dr = new Login().ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                        this.Close();
                    else if (dr == DialogResult.OK)
                        this.displayData();
                }
                else
                    this.displayData();
            else
                MessageBox.Show("offline mode");
        }

        private void DeleteBookmarkButton_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void LikeBookmarkButton_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void LogoutButton_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
