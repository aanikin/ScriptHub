using ScriptHub.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ScriptHub.Model.Interfaces;


namespace ScriptHub.Model
{
    public class ScriptRunnerFactory : IScriptRunnerFactory
    {
        Runners _runners;
        IConfigFile<Runners> _config;

        public ScriptRunnerFactory(IConfigFile<Runners> config)
        { 
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            _config = config;

            _runners = _config.Load();
        }
        public Runners GetRunners()
        {
            return _runners;
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

    public class Runner : IXmlConfigEntity
    {
        [XmlElement("Type")]
        public ScriptType Type { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }
        

        [XmlElement("Executable")]
        public string Executable { get; set; }
        
        [XmlElement("CommandLine")]
        public string CommandLine { get; set; }
    }

}
