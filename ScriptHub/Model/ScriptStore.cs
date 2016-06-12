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
        IConfigFile<Scripts> _config;
       
        public ScriptStore(IConfigFile<Scripts> config)
        {

            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            _config = config;

            Initialize();
        }

        private void Initialize()
        {
            _scripts = _config.Load();

            VerifyLoadedList();
            SortListByName();
        }

        private void VerifyLoadedList()
        {
            if (_scripts.List.Select(x => x.Name).Distinct().Count() != _scripts.List.Count)
            {
                throw new Exception("Scripts have duplicate names of scripts! Please fix scripts.config.");
            }
        }
        private void SortListByName()
        {
           _scripts.List = _scripts.List.OrderBy(x => x.Name).ToList();
        }

        public List<Script> GetScripts()
        {
            return _scripts.List;
        }

        public Script GetScript(int index)
        {
            return GetScripts()[index];
        }

        public bool AddScript(Script script)
        {
            if (CheckUnique(script))
            {
                _scripts.List.Add(script);

                SaveScripts();
                
                return true;
            }

            return false;
        }

       
        public bool UpdateScript(int index, Script script)
        {
            if (_scripts.List[index].Name == script.Name)
            {
                _scripts.List[index] = script;
            } else
            {
                if (CheckUnique(script))
                {
                    _scripts.List[index] = script;
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
            _scripts.List.RemoveAt(index);
            _config.Save(_scripts);
        }

        public bool CheckUnique(Script script)
        {
            if (_scripts.List.FirstOrDefault(x => x.Name.ToLower() == script.Name.ToLower()) != null)
            {
                return false;
            }

            return true;
        }

        private void SaveScripts()
        {
            SortListByName();
            _config.Save(_scripts);
        }
    }

    
    [XmlRoot("Scripts")]
    public class Scripts 
    {
        [XmlElement("Script")]
        public List<Script> List { get; set; }

    }

    public class Script
    {
        [XmlElement("Type")]
        public string Type { get; set; }
        
        [XmlElement("Name")]
        public string Name { get; set;}
      
        [XmlElement("Path")]
        public string Path { get; set;}
        
        [XmlElement("Arguments")]
        public string Arguments { get; set; }
        
        [XmlElement("Details")]
        public string Details { get; set;}
        
    }

}
