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

        public void GetFolders(AsyncCallback callback)
        {
            this.connector.GetFolderList(this, callback);
            
        }

    }
}
