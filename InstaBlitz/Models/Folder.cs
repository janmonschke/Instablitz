using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Instablitz;

namespace InstaBlitz.Models
{
    class Folder : BaseModel
    {
        public const String STARRED = "starred";
        public const String UNREAD = "unread";
        public const String ARCHIVE = "archive";

        protected static String BaseUrl = BaseModel.BaseUrl + "folder";
        
        public delegate void BookmarksReceived(List<Bookmark> bookmarks);
        public event BookmarksReceived OnBookmarksReceived;

        public Folder(InstapaperConnector con) : base(con)
        {
          
        }

        public void GetBookmarks()
        {
            this.connector.OnBookmarksReceived += delegate(List<Bookmark> bookmarks)
            {
                OnBookmarksReceived(bookmarks);
            };
            this.connector.GetBookmarks(this.Id);
        }
    }
}
