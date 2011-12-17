using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace InstaBlitz
{
        /**
        * A singleton Config class to read and write the Config  
        */
        public class Config
        {
            public const string FILENAME = "instablitz_config";
            public const string SEPARATOR = "|";
            public const string IDENTIFIER = ":";

            private static Config instance;

            public String oauth_token;
            public String oauth_token_secret;
            public bool developer_mode;

            private Config()
            {
                this.oauth_token = "";
                this.developer_mode = false;
            }

            public static Config GetInstance()
            {
                if (instance != null) return instance;
                else {
                    Config conf = new Config();
                    ConfigLoader cl = new ConfigLoader(conf);
                    cl.LoadConfig();
                    instance = conf;
                    return conf;
                }
            }

            public void Write(){
                new ConfigWriter(instance).WriteConfig();
            }

            public override string ToString()
            {
                FieldInfo[] finfo = this.GetType().GetFields();
                for (int i = 0; i < finfo.Length; i++)
                {
                    Console.WriteLine(finfo[i].Name);
                }
                return "oauth_token:" + this.oauth_token + SEPARATOR +
                        "dev_mode:" + this.developer_mode + SEPARATOR +
                        "oauth_token_secret:" + this.oauth_token_secret;
            }
        }
}
