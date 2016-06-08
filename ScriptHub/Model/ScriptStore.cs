using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace ScriptHub
{
    class ScriptStore : IScriptStore
    {
        Scripts _scripts;
        string _path;

        public ScriptStore(string path)
        { 
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            _path = path;

            LoadScripts();
        }

        private void LoadScripts()
        {
            var serializer = new XmlSerializer(typeof(Scripts));

            using (FileStream fileStream = new FileStream(_path,FileMode.Open)) 
            {
                _scripts = (Scripts)serializer.Deserialize(fileStream);
            }

            SortListByName(); //
        }

        private void SaveScripts()
        {
            var serializer = new XmlSerializer(typeof(Scripts));

            SortListByName();

            File.Move(_path, _path + ".backup");
            using (FileStream fileStream = new FileStream(_path, FileMode.CreateNew))
            {
                serializer.Serialize(fileStream, _scripts);
            }

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

        public void AddScript(Script script)
        {
            _scripts.ScriptList.Add(script);
            SaveScripts();
        }

        public void UpdateScript(int index, Script script)
        {
            _scripts.ScriptList[index] = script;
            SaveScripts();
        }

        public void DeleteScript(int index)
        {
            _scripts.ScriptList.RemoveAt(index);
            SaveScripts();
        }
    }

    
    [XmlRoot("Scripts")]
    public class Scripts
    {
        [XmlElement("Script")]
        public List<Script> ScriptList { get; set; }

    }

    public class Script
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
                var result = ScriptType.PowershellScript;

                if (Path.Contains(".ps1"))
                    result = ScriptType.PowershellScript;

                return result;
            }
        }
        
    }

    public enum ScriptType
    {
        PowershellScript = 0
    }
}
