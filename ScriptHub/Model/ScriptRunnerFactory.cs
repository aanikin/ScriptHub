using ScriptHub.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


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

            Initialize();
        }

        private void Initialize()
        {
            _runners = _config.Load();
        }

        public List<Runner> GetRunners()
        {
            return _runners.List;
        }        

        public IScriptRunner CreateScriptRunner(Script script)
        {
            var runner = _runners.List.FirstOrDefault<Runner>(r => r.Type == script.Type);
           
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
        public List<Runner> List { get; set; }

    }

    public class Runner 
    {
        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("Executable")]
        public string Executable { get; set; }
        
        [XmlElement("CommandLine")]
        public string CommandLine { get; set; }
    }

}
