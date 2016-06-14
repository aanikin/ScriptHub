using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptHub.Model;
using ScriptHub.Model.Interfaces;
using System.Linq;

namespace ScriptHub.Tests
{
    [TestClass]
    public class ScriptStoreTests
    {
        IConfigFile<Scripts> _config;
        string _scriptsConfig = "Data\\scripts.config";
        Scripts _scripts;
        IScriptStore _store;

        [TestInitialize]
        public void TestInitialize()
        {
            _config = new ConfigFile<Scripts>(_scriptsConfig);
            
            _store = new ScriptStore(_config);

            _scripts = _config.Load();
        }

        [TestMethod]
        public void ScriptsListShouldBeSortedByName()
        {
            var scriptsFromStore = _store.Scripts;

            var namesFromConfig = _scripts.List.OrderBy(x => x.Name).Select(x => x.Name).ToList();
            var namesFromStore = scriptsFromStore.Select(x => x.Name).ToList();
            bool equal = true;
            for (int i = 0; i < namesFromConfig.Count; i++)
            {
                equal = (namesFromConfig[i] == namesFromStore[i]);
                
                if (!equal)
                {
                    break;
                }
            }

            Assert.AreEqual(equal, true);
        }

        [TestMethod]
        public void AddScriptWithNonUniqueNameShouldFail()
        {
            var scriptsFromStore = _store.Scripts;

            Script newScript = new Script {
                Name = scriptsFromStore[0].Name
            };

            bool added = _store.AddScript(newScript);

            Assert.AreEqual(added, false);

        }

        [TestMethod]
        public void UpdateScriptWithNonUniqueNameShouldFail()
        {
            int itemToUpdate = 0;

            var scriptsFromStore = _store.Scripts;

            var newNonUniqueName = scriptsFromStore[itemToUpdate + 1].Name;

            Script scriptToUpdate = new Script
            {
                Type = scriptsFromStore[itemToUpdate].Type,
                Name = newNonUniqueName,
                Path = scriptsFromStore[itemToUpdate].Path,
                Arguments = scriptsFromStore[itemToUpdate].Arguments,
                Details = scriptsFromStore[itemToUpdate].Details
            };

            bool added = _store.UpdateScript(itemToUpdate, scriptToUpdate);

            Assert.AreEqual(added, false);
        }

        [TestMethod]
        public void AddUpdateDeleteScriptWithUniqueNameShouldPass()
        {
            Script script = new Script
            {
                Type = "TEST",
                Name = "Test Script 2",
                Path = "TEST",
                Arguments = "TEST",
                Details = "TEST"
            };

            Assert.AreEqual(_store.AddScript(script), true);

            int index = _store.GetScriptIndexByName(script.Name);

            Script script_Updated = new Script
            {
                Type = "TEST_Updated",
                Name = "TEST_Updated",
                Path = "TEST_Updated",
                Arguments = "TEST_Updated",
                Details = "TEST_Updated"
            };

            Assert.AreEqual(_store.UpdateScript(index, script_Updated), true);

            index = _store.GetScriptIndexByName(script_Updated.Name);

            _store.DeleteScript(index);

        }
    }
}
