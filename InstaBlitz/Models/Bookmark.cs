using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Instablitz;

namespace InstaBlitz.Models
{
    class Bookmark : BaseModel
    {
        public String HtmlText;
        public String Url;
        public String Description;
        public Boolean Starred;
        
        public Bookmark(InstapaperConnector con) : base(con)
        {
            this.HtmlText = "";
        }

        private void starred(IAsyncResult res)
        {
            this.Starred = true;
            this.currentCallback.Invoke(res);
        }

        public void Star(AsyncCallback callback)
        {
            this.currentCallback = callback;
            this.connector.StarBookmark(this, callback);
        }

        public void UnStar(AsyncCallback callback)
        {
            this.connector.UnStarBookmark(this, callback);
        }

        public void GetText(AsyncCallback callback)
        {
            this.connector.GetBookmarkText(this, callback);
        }
    }
}
