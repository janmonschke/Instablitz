using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Instablitz;

namespace InstaBlitz.Models
{
    class User : BaseModel
    {
        public List<Folder> Folders;

        public User(InstapaperConnector con) : base(con)
        {
            this.Folders = new List<Folder>();
        }

        public delegate void FoldersReceived();
        public event FoldersReceived OnFoldersReceived;

        public void GetFolders()
        {
            this.connector.OnFoldersReceived += delegate(List<Folder> folders){
                this.Folders.Clear();

                // manually add the predefined folders
                Folder unread = new Folder(this.connector);
                unread.Id = Folder.UNREAD;
                unread.Title = "Unread";
                Folder starred = new Folder(this.connector);
                starred.Id = Folder.STARRED;
                starred.Title = "Starred";
                Folder archive = new Folder(this.connector);
                archive.Id = Folder.ARCHIVE;
                archive.Title = "Archive";
                this.Folders.Add(unread);
                this.Folders.Add(starred);
                this.Folders.Add(archive);

                // add all new folders
                foreach (Folder f in folders)
                    this.Folders.Add(f);

                this.OnFoldersReceived();
            };
            this.connector.GetFolderList();
        }

    }
}
