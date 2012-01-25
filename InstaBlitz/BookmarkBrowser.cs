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
        User user;

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
            user = new User(getConnector());

            user.OnFoldersReceived += delegate() {
                for(int i=0; i < user.Folders.Count; i++)
                {
                    Folder folder = user.Folders[i];
                    FolderList.Items.Add(folder.Title);
                    Console.WriteLine("Adding Folder: " + folder.Title);
                }
                // load bookmarks from default folder
                loadFolder("unread");
                // select default folder
                FolderList.Items[0].Selected = true;
            };

            user.GetFolders();
        }

        private void loadFolder(String folder_id)
        {
            Folder f = new Folder(getConnector());
            f.Id = folder_id;

            f.OnBookmarksReceived += renderBookmarks;

            f.GetBookmarks();
        }

        private void renderBookmarks(List<Bookmark> bookmarks)
        {
            //Console.WriteLine("received " + bookmarks.Count);
            //foreach(Bookmark b in bookmarks)
            //    Console.WriteLine("Title: " + b.Title + " Starred? " + b.Starred);
            /*bookmarks[0].OnStarChanged += delegate() {
                Console.WriteLine("starred");
                bookmarks[0].OnTextReceived += delegate(String text) {
                    Console.WriteLine(text);
                };
                bookmarks[0].GetText();
            };*/
            //bookmarks[0].Star();
            // clear bookmark list

            BookmarkList.Clear();
            
            for (int i = 0; i < bookmarks.Count; i++)
            {
                Bookmark bookmark = bookmarks[i];
                BookmarkList.Items.Add(bookmark.Title);
                Console.WriteLine("Adding Bookmark: " + bookmark.Title);
            }
        }

        private void loadBookmark(String bookmark_id)
        {
            Console.WriteLine("load bookmark_id: " + bookmark_id);
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

        private void FolderList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // clear bookmarkView

            // get folder_id
            // load bookmarks for said folder_id
            foreach (int index in FolderList.SelectedIndices)
                loadFolder( user.Folders[index].Id );
        }

        private void BookmarkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear bookmarkView
            Console.WriteLine("selected: " + BookmarkList.SelectedItems[0].ToString());
            // get bookmark_id
            // load bookmark for said bookmark_id
            // display it in the bookmark view
        }

        private void ArchiveButton_Click(object sender, EventArgs e)
        {
            // send bookmark request
            // reload gui with empty bookmark view
        }

        private void LikeBookmarkButton_Click(object sender, EventArgs e)
        {
            // check if bookmark is starred
            // if bookmark is stared
            //      unstar it
            //      change button text to star
            // else
            //      star the bookmark
            //      change button text to unstar
        }

        private void DeleteBookmarkButton_Click(object sender, EventArgs e)
        {
            // send delete request
            // clear bookmark view
        }
        
    }
}
