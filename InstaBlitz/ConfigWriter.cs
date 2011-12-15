using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaBlitz
{
    public class ConfigWriter
    {
        private Config config;

        public ConfigWriter(Config c)
        {
            this.config = c;
        }

        public String WriteConfig()
        {
            String configString = this.config.ToString();
            this.WriteConfigString(configString);
            return configString;
        }

        private void WriteConfigString(String content)
        {
            try
            {
                StreamWriter fw = new StreamWriter(Config.FILENAME);
                fw.Write(content);
                fw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
