using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Instablitz;

namespace InstaBlitz.Models
{
    class Folder : BaseModel
    {
        protected static String BaseUrl = BaseModel.BaseUrl + "folder";
        
        public delegate void BookmarksReceived(List<Bookmark> bookmarks);
        public event BookmarksReceived OnBookmarksReceived;

        public delegate void FoldersReceived(List<Folder> folders);
        public event FoldersReceived OnFoldersReceived;

        public Folder(InstapaperConnector con) : base(con)
        {
          
        }

        public void GetBookmarks()
        {
            List<Bookmark> bookmarks = new List<Bookmark>();
            Bookmark b1 = new Bookmark(this.connector);
            b1.HtmlText = "<p>Tesssssssttt</p><p>Lorem the fuck !!!</p>";
            Bookmark b2 = new Bookmark(this.connector);
            b2.HtmlText = "<h1>Tesssssssttt 2222222</h1><p>Lorem the fuck !!!</p>";
            bookmarks.Add(b1);
            bookmarks.Add(b2);
            OnBookmarksReceived(bookmarks);
        }

        public void GetFolders()
        {
            this.connector.OnFoldersReceived += delegate(List<Folder> folders) { 
                
            };
            this.connector.GetFolderList(BaseModel.BaseUrl + "folders/list");

        }
    }
}
