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

        public List<Bookmark> Bookmarks;

        public Folder(InstapaperConnector con) : base(con)
        {
          this.Bookmarks = new List<Bookmark>();
        }

        public void GetBookmarks(AsyncCallback callback)
        {
            this.connector.GetBookmarks(this, callback);
        }
    }
}
