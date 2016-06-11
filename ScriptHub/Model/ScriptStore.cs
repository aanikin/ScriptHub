using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System;
using ScriptHub.Model.Interfaces;

namespace ScriptHub.Model
{
    class ScriptStore : IScriptStore
    {
        Scripts _scripts;
        string _configFile;
        IConfigFile<Scripts> _config;
       
        public ScriptStore(IConfigFile<Scripts> config)
        {

            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            _config = config;

            _scripts = _config.Load();
            SortListByName();
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
                _config.Save(_scripts);
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

            _config.Save(_scripts);
            return true;
        }

        public void DeleteScript(int index)
        {
            _scripts.ScriptList.RemoveAt(index);
            _config.Save(_scripts);
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

    public class Script : IXmlConfigEntity
    {
        [XmlElement("Type")]
        public ScriptType Type { get; set; }
        
        [XmlElement("Name")]
        public string Name { get; set;}
      
        [XmlElement("Path")]
        public string Path { get; set;}
        
        [XmlElement("Arguments")]
        public string Arguments { get; set; }
        
        [XmlElement("Details")]
        public string Details { get; set;}
        
    }

    public enum ScriptType
    {
        Unknown = 0,
        Powershell = 1
    }
}
