using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScriptHub
{
    public class ScriptRunnerFactory : IScriptRunnerFactory
    {
        Runners _runners;
        string _configFile;

        public ScriptRunnerFactory(string configFile)
        { 
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(configFile);
            }

            _configFile = configFile;

            LoadRunners();
        }

        private void LoadRunners()
        {
            var serializer = new XmlSerializer(typeof(Runners));

            using (FileStream fileStream = new FileStream(_configFile, FileMode.Open)) 
            {
                _runners = (Runners)serializer.Deserialize(fileStream);
            }

        }

    
        public IScriptRunner CreateScriptRunner(Script script)
        {
            var runner = _runners.RunnersList.FirstOrDefault<Runner>(r => r.Type == script.Type);
           
            if (runner == null)
            {
                throw new Exception("Couldn't find runner for script " + script.Name + " with type " + script.Type);
            }

            return new ScriptRunner(runner, script);
        }
    }

    [XmlRoot("Runners")]
    public class Runners
    {
        [XmlElement("Runner")]
        public List<Runner> RunnersList { get; set; }

    }

    public class Runner
    {
        [XmlElement("Type")]
        public ScriptType Type { get; set; }
        [XmlElement("Executable")]
        public string Executable { get; set; }
        [XmlElement("CommandLine")]
        public string CommandLine { get; set; }
        

    }

}
