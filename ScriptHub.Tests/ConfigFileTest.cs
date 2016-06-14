using ScriptHub.Model.Interfaces;
using ScriptHub.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Configuration;

namespace ScriptHub.Tests
{
    [TestClass]
    public class ConfigFileTest
    {
        IConfigFile<Scripts> _config;
        string _scriptsConfig = "Data\\scripts.config";
        Scripts _scripts;

        [TestInitialize]
        public void TestInitialize()
        {
            _config = new ConfigFile<Scripts>(_scriptsConfig);
            _scripts = _config.Load();
        }

        [TestMethod]
        public void AllScriptsShouldBeLoadedFromConfig()
        {
           Assert.AreNotEqual(_scripts.List.Count, 0);
        }

        [TestMethod]
        public void AllScriptsShouldBeSavedToNewConfig()
        {
            var newConfigName = "newscripts.config";
            
            var newConfig = new ConfigFile<Scripts>(newConfigName);
            
            newConfig.Save(_scripts);
            Assert.AreEqual(File.Exists(newConfigName), true);

            newConfig.Save(_scripts);
            Assert.AreEqual(File.Exists(newConfigName + ".backup"), true);
            
            var scriptsFromNewFile = newConfig.Load();

            Assert.AreEqual(scriptsFromNewFile.List.Count, _scripts.List.Count);

            File.Delete(newConfigName);
            File.Delete(newConfigName + ".backup");

        }

    }
}
