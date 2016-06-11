using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System;

namespace ScriptHub
{
    class ScriptStore : IScriptStore
    {
        Scripts _scripts;
        string _configFile;
        HashSet<string> _hashset;

        public ScriptStore(string configFile)
        { 
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(configFile);
            }

            _configFile = configFile;

            LoadScripts();
        }

        private void LoadScripts()
        {
            var serializer = new XmlSerializer(typeof(Scripts));

            using (FileStream fileStream = new FileStream(_configFile,FileMode.Open)) 
            {
                _scripts = (Scripts)serializer.Deserialize(fileStream);
            }

            _hashset = new HashSet<string>(_scripts.ScriptList.Select(x => x.Name).ToList());

            if (_hashset.Count() != _scripts.ScriptList.Count)
            {
                throw new Exception("Scripts have duplicate names of scripts! Please fix scripts.config.");
            }

            SortListByName(); //
        }

        private void SaveScripts()
        {
            var serializer = new XmlSerializer(typeof(Scripts));

            SortListByName();

            BackupConfigFile();

            using (FileStream fileStream = new FileStream(_configFile, FileMode.CreateNew))
            {
                serializer.Serialize(fileStream, _scripts);
            }

        }

        private void BackupConfigFile()
        {
            File.Delete(_configFile + ".backup");
            File.Move(_configFile, _configFile + ".backup");
        }

        private void SortListByName()
        {
           _scripts.ScriptList = _scripts.ScriptList.OrderBy(x => x.Name).ToList();
        }

        public List<Script> GetScripts()
        {
            return _scripts.ScriptList;
        }

        public Script GetScript(int index)
        {
            return GetScripts()[index];
        }

        public bool AddScript(Script script)
        {
            if (CheckUnique(script))
            {
                _scripts.ScriptList.Add(script);
                SaveScripts();
                return true;
            }

            return false;
        }

        public bool UpdateScript(int index, Script script)
        {
            if (_scripts.ScriptList[index].Name == script.Name)
            {
                _scripts.ScriptList[index] = script;
            } else
            {
                if (CheckUnique(script))
                {
                    _scripts.ScriptList[index] = script;
                }
                else
                {
                    return false;
                }
            }

            SaveScripts();
            return true;
        }

        public void DeleteScript(int index)
        {
            _scripts.ScriptList.RemoveAt(index);
            SaveScripts();
        }

        public bool CheckUnique(Script script)
        {
            if (_scripts.ScriptList.FirstOrDefault(x => x.Name.ToLower() == script.Name.ToLower()) != null)
            {
                return false;
            }

            return true;
        }

    }

    
    [XmlRoot("Scripts")]
    public class Scripts
    {
        [XmlElement("Script")]
        public List<Script> ScriptList { get; set; }

    }

    public class Script: ICloneable
    {
        [XmlElement("Name")]
        public string Name { get; set;}
        [XmlElement("Path")]
        public string Path { get; set;}
        [XmlElement("Arguments")]
        public string Arguments { get; set; }
        [XmlElement("Details")]
        public string Details { get; set;}

        public ScriptType Type 
        {
            get 
            {
                var result = ScriptType.Unknown;

                if (Path.Contains(".ps1"))
                    result = ScriptType.Powershell;

                return result;
            }
        }
        public object Clone()
        {
            return new Script
            {
                Name = this.Name,
                Path = this.Path,
                Arguments = this.Arguments,
                Details = this.Details
            };
        }
        
    }

    public enum ScriptType
    {
        Unknown = 0,
        Powershell = 1
    }
}
