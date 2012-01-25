namespace InstaBlitz
{
    partial class BookmarkBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarkBrowser));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.FolderList = new System.Windows.Forms.ListView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.Username = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BookmarkList = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.BookmarkView = new System.Windows.Forms.WebBrowser();
            this.theBrowser = new System.Windows.Forms.WebBrowser();
            this.StarBookmarkButton = new System.Windows.Forms.Button();
            this.DeleteBookmarkButton = new System.Windows.Forms.Button();
            this.ArchiveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1129, 480);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.FolderList);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(170, 480);
            this.splitContainer4.SplitterDistance = 380;
            this.splitContainer4.TabIndex = 1;
            // 
            // FolderList
            // 
            this.FolderList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.FolderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderList.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderList.HideSelection = false;
            this.FolderList.Location = new System.Drawing.Point(0, 0);
            this.FolderList.MultiSelect = false;
            this.FolderList.Name = "FolderList";
            this.FolderList.Size = new System.Drawing.Size(170, 380);
            this.FolderList.TabIndex = 2;
            this.FolderList.UseCompatibleStateImageBehavior = false;
            this.FolderList.View = System.Windows.Forms.View.List;
            this.FolderList.SelectedIndexChanged += new System.EventHandler(this.FolderList_SelectedIndexChanged_1);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.Username);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.LogoutButton);
            this.splitContainer5.Size = new System.Drawing.Size(170, 96);
            this.splitContainer5.SplitterDistance = 63;
            this.splitContainer5.TabIndex = 0;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(12, 21);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(53, 13);
            this.Username.TabIndex = 0;
            this.Username.Text = "username";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoutButton.Location = new System.Drawing.Point(0, 0);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(170, 29);
            this.LogoutButton.TabIndex = 2;
            this.LogoutButton.Text = "Log out";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BookmarkList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(955, 480);
            this.splitContainer2.SplitterDistance = 337;
            this.splitContainer2.TabIndex = 0;
            // 
            // BookmarkList
            // 
            this.BookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookmarkList.Font = new System.Drawing.Font("Arial", 14F);
            this.BookmarkList.HideSelection = false;
            this.BookmarkList.Location = new System.Drawing.Point(0, 0);
            this.BookmarkList.Name = "BookmarkList";
            this.BookmarkList.Size = new System.Drawing.Size(337, 480);
            this.BookmarkList.TabIndex = 0;
            this.BookmarkList.UseCompatibleStateImageBehavior = false;
            this.BookmarkList.View = System.Windows.Forms.View.List;
            this.BookmarkList.SelectedIndexChanged += new System.EventHandler(this.BookmarkList_SelectedIndexChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.BookmarkView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.theBrowser);
            this.splitContainer3.Panel2.Controls.Add(this.StarBookmarkButton);
            this.splitContainer3.Panel2.Controls.Add(this.DeleteBookmarkButton);
            this.splitContainer3.Panel2.Controls.Add(this.ArchiveButton);
            this.splitContainer3.Size = new System.Drawing.Size(614, 480);
            this.splitContainer3.SplitterDistance = 448;
            this.splitContainer3.TabIndex = 0;
            // 
            // BookmarkView
            // 
            this.BookmarkView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookmarkView.Location = new System.Drawing.Point(0, 0);
            this.BookmarkView.MinimumSize = new System.Drawing.Size(20, 20);
            this.BookmarkView.Name = "BookmarkView";
            this.BookmarkView.ScriptErrorsSuppressed = true;
            this.BookmarkView.Size = new System.Drawing.Size(614, 448);
            this.BookmarkView.TabIndex = 2;
            // 
            // theBrowser
            // 
            this.theBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theBrowser.Location = new System.Drawing.Point(150, 0);
            this.theBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.theBrowser.Name = "theBrowser";
            this.theBrowser.ScrollBarsEnabled = false;
            this.theBrowser.Size = new System.Drawing.Size(389, 28);
            this.theBrowser.TabIndex = 3;
            this.theBrowser.Visible = false;
            this.theBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.theBrowser_DocumentCompleted);
            // 
            // StarBookmarkButton
            // 
            this.StarBookmarkButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.StarBookmarkButton.Location = new System.Drawing.Point(75, 0);
            this.StarBookmarkButton.Name = "StarBookmarkButton";
            this.StarBookmarkButton.Size = new System.Drawing.Size(75, 28);
            this.StarBookmarkButton.TabIndex = 1;
            this.StarBookmarkButton.Text = "Star";
            this.StarBookmarkButton.UseVisualStyleBackColor = true;
            this.StarBookmarkButton.Click += new System.EventHandler(this.StarBookmarkButton_Click);
            // 
            // DeleteBookmarkButton
            // 
            this.DeleteBookmarkButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteBookmarkButton.Enabled = false;
            this.DeleteBookmarkButton.Location = new System.Drawing.Point(539, 0);
            this.DeleteBookmarkButton.Name = "DeleteBookmarkButton";
            this.DeleteBookmarkButton.Size = new System.Drawing.Size(75, 28);
            this.DeleteBookmarkButton.TabIndex = 0;
            this.DeleteBookmarkButton.Text = "Delete";
            this.DeleteBookmarkButton.UseVisualStyleBackColor = true;
            this.DeleteBookmarkButton.Click += new System.EventHandler(this.DeleteBookmarkButton_Click);
            // 
            // ArchiveButton
            // 
            this.ArchiveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ArchiveButton.Enabled = false;
            this.ArchiveButton.Location = new System.Drawing.Point(0, 0);
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.Size = new System.Drawing.Size(75, 28);
            this.ArchiveButton.TabIndex = 2;
            this.ArchiveButton.Text = "Archive";
            this.ArchiveButton.UseVisualStyleBackColor = true;
            this.ArchiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // BookmarkBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 480);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookmarkBrowser";
            this.Text = "Instablitz";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView BookmarkList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.WebBrowser BookmarkView;
        private System.Windows.Forms.Button StarBookmarkButton;
        private System.Windows.Forms.Button DeleteBookmarkButton;
        private System.Windows.Forms.Button ArchiveButton;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.WebBrowser theBrowser;
        private System.Windows.Forms.ListView FolderList;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label Username;

    }
}