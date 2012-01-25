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

        public void Star(AsyncCallback callback)
        {
            this.connector.StarBookmark(this, delegate(IAsyncResult res){
                this.Starred = true;
                callback.Invoke(res);
            });
        }

        public void UnStar(AsyncCallback callback)
        {
            this.connector.UnStarBookmark(this, delegate(IAsyncResult res){
                this.Starred = false;
                callback.Invoke(res);
            });
        }

        public void GetText(AsyncCallback callback)
        {
            this.connector.GetBookmarkText(this, callback);
        }
    }
}
