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

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(configFile);
            }

            _configFile = configFile;
        }

        public T Load()
        {
            T data;

            var serializer = new XmlSerializer(typeof(T));

            using (FileStream fileStream = new FileStream(_configFile, FileMode.Open))
            {
                data = (T)serializer.Deserialize(fileStream);
            }

            //if (_scripts.ScriptList.Select(x => x.Name).Distinct().Count() != _scripts.ScriptList.Count)
            // {
            //    throw new Exception("Scripts have duplicate names of scripts! Please fix scripts.config.");
            //}

            return data;
        }

        public void Save(T data)
        {
            var serializer = new XmlSerializer(typeof(T));

            // SortListByName();

            //  BackupConfigFile();
        
            using (FileStream fileStream = new FileStream(_configFile, FileMode.CreateNew))
            {
                serializer.Serialize(fileStream, data);
            }

        }

    }
}
