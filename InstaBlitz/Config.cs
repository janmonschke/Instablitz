using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
namespace InstaBlitz
{
    class Config
    {
        private static ConfigData instance = null;

        private Config()
        {
            
        }

        public static ConfigData GetData()
        {
            if (instance != null) return instance;
            else
            {
                Stream s;
                ConfigData cd = new ConfigData();
                BinaryFormatter bf = new BinaryFormatter();

                if (File.Exists(ConfigData.FILENAME) && File.ReadAllLines(ConfigData.FILENAME).Length > 0)
                {
                    s = File.Open(ConfigData.FILENAME, FileMode.OpenOrCreate);
                    cd = (ConfigData)bf.Deserialize(s);
                }
                else
                {
                    s = File.Open(ConfigData.FILENAME, FileMode.OpenOrCreate);
                    bf.Serialize(s, cd);
                }

                s.Close();
                instance = cd;
                return cd;
            }
        }

        public static void Write()
        {
            if (File.Exists(ConfigData.FILENAME))
                File.Delete(ConfigData.FILENAME);
            Stream s = File.Open(ConfigData.FILENAME, FileMode.CreateNew);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, GetData());
            s.Close();
        }
    }
}
