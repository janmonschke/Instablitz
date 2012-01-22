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
        protected static String BaseUrl = "https://instapaper.com/api/1/";
        protected InstapaperConnector connector;
        public String Id;
        public String Title;

        public BaseModel(InstapaperConnector con)
        {
            this.connector = con;
            this.Id = "";
            this.Title = "";
        }

        // Gets fired when the model's been loaded
        public event ModelCallback OnLoad;

        // Gets fired when there was an error
        public event ModelCallback OnError;

        // Gets fired when the model has been deleted
        public event ModelCallback OnDelete;

        // Load the model's data
        public void Load() { throw new NotImplementedException(); }

        // Delete the model
        public void Delete() { throw new NotImplementedException(); }
    }
}
