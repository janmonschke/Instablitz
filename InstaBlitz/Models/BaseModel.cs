using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Instablitz;

namespace InstaBlitz.Models
{
    public delegate void ModelCallback(String message);

    class BaseModel
    {
        protected static String BaseUrl = "https://www.instapaper.com/api/1/";
        protected InstapaperConnector connector;
        protected AsyncCallback currentCallback;
        public String Id;
        public String Title;

        public BaseModel(InstapaperConnector con)
        {
            this.connector = con;
            this.Id = "";
            this.Title = "";
        }

        // Load the model's data
        public void Load() { throw new NotImplementedException(); }

        // Delete the model
        public void Delete() { throw new NotImplementedException(); }
    }
}
