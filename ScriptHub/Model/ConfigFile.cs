using ScriptHub.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScriptHub.Model
{
    public class ConfigFile<T> : IConfigFile<T>
    {
        string _configFile;

        public ConfigFile(string configFile)
        {
            _configFile = configFile;
        }

        public T Load()
        {
            if (!File.Exists(_configFile))
            {
                throw new FileNotFoundException(_configFile);
            }

            T data;

            var serializer = new XmlSerializer(typeof(T));

            using (FileStream fileStream = new FileStream(_configFile, FileMode.Open))
            {
                data = (T)serializer.Deserialize(fileStream);
            }

            return data;
        }

        public void Save(T data)
        {
            var serializer = new XmlSerializer(typeof(T));

            BackupConfigFile();
        
            using (FileStream fileStream = new FileStream(_configFile, FileMode.CreateNew))
            {
                serializer.Serialize(fileStream, data);
            }

        }

        private void BackupConfigFile()
        {
            if (File.Exists(_configFile + ".backup"))
            {
                File.Delete(_configFile + ".backup");
            }

            if (File.Exists(_configFile))
            {
                File.Move(_configFile, _configFile + ".backup");    
            }
            
        }



    }
}
