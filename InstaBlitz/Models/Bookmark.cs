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
        public String Id;
        public String Title;
        public String Url;
        public String Description;
        public Boolean Starred;
        
        public Bookmark(InstapaperConnector con) : base(con)
        {
            this.HtmlText = "";
        }

        public delegate void StarSuccess();
        public event StarSuccess OnStarChanged;

        public void Star()
        {
            this.connector.OnStarChanged += delegate() {
                this.Starred = true;
                this.OnStarChanged();    
            };
            this.connector.StarBookmark(this.Id);
        }

        public void UnStar()
        {
            this.connector.OnStarChanged += delegate()
            {
                this.Starred = false;
                this.OnStarChanged();
            };
            this.connector.UnStarBookmark(this.Id);
        }

    }
}
