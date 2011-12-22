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
        
        public Bookmark(InstapaperConnector con) : base(con)
        {
            this.HtmlText = "";
        }

    }
}
