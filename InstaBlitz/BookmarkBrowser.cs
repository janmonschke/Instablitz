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

namespace InstaBlitz
{
    public partial class BookmarkBrowser : Form
    {
        public BookmarkBrowser()
        {
            InitializeComponent();
           
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
                
                // when the login view has been cancelled, close the program
                if (dr == DialogResult.Cancel)
                    this.Close();
            }
                

        }

        private void BookmarkBrowser_Load(object sender, EventArgs e)
        {
            ConfigData cd = Config.GetData();
            DialogResult dr;
            if (IsConnected())
                if (!cd.IsUserAuthenticated())
                {
                    dr = new Login().ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                        this.Close();
                }
                else
                    Console.WriteLine("load data");
            else
                MessageBox.Show("offline mode");
        }
        
    }
}
