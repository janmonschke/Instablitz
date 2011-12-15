using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaBlitz
{
    public class ConfigLoader
    {
        private Config config;

        public ConfigLoader(Config _config)
        {
            this.config = _config;
        }

        public void LoadConfig()
        {
            string readConfig = "";
            try
            {
                StreamReader file = File.OpenText(Config.FILENAME);
                // Read the file into a string
                readConfig = file.ReadToEnd();
                file.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error reading in the config file. Creating a new one.");

                readConfig = new ConfigWriter(this.config).WriteConfig();
            }
            ParseStringToConfig(readConfig);
        }

        private void ParseStringToConfig(string read)
        {
            String[] splitted = read.Split(Config.SEPARATOR.ToCharArray());
            this.config.oauth_token = splitted[0];
            
            if (splitted.Length > 1)
            {
                bool dev_mode = splitted[1].Split(Config.IDENTIFIER.ToCharArray())[1].Equals("True");
                this.config.developer_mode = dev_mode;
            }
        }
    }
}
