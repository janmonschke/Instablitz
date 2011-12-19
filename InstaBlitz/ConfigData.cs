using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;

namespace InstaBlitz
{

        /**
        * A singleton Config class to read and write the Config  
        */
        [Serializable()]
        public class ConfigData : ISerializable
        {
            public static string FILENAME = "instablitz_config";

            public String oauth_token;
            public String oauth_token_secret;
            public bool developer_mode;

            public ConfigData()
            {
                this.oauth_token = "";
                this.oauth_token_secret = "";
            }

            public ConfigData(SerializationInfo info, StreamingContext ctxt) : base()
            {
                this.oauth_token = (string)info.GetValue("oauth_token", typeof(string));
                this.oauth_token_secret = (string)info.GetValue("oauth_token_secret", typeof(string));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("oauth_token", this.oauth_token);
                info.AddValue("oauth_token_secret", this.oauth_token_secret);
            }

            public override string ToString()
            {
                return "oauth_token:" + this.oauth_token + " " +
                        "oauth_token_secret:" + this.oauth_token_secret;
            }
        }
}
