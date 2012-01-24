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
                this.Folders = folders;
                this.OnFoldersReceived();
            };
            this.connector.GetFolderList();
        }

    }
}
