using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptHub.Model.Interfaces;
using ScriptHub.Model;

namespace ScriptHub.Tests
{
    [TestClass]
    public class ScriptRunnerFactoryTests
    {
        string _runnersConfigFilePath = "Data\\runners.config";
        IConfigFile<Runners> _config;
        IScriptRunnerFactory _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            _config = new ConfigFile<Runners>(_runnersConfigFilePath);
            _factory = new ScriptRunnerFactory(_config);
        }

        [TestMethod]
        public void FactoryWillReturnCorrectRunner()
        {
            var runners = _factory.Runners;

            Script script = new Script
            {
                Type = runners[0].Type,
                Name = "Some name"
            };
            try
            {
                var runner = _factory.CreateScriptRunner(script);
            }
            catch (RunnerNotFoundException e)
            {
                Assert.Fail();
            }
            
        }

        [TestMethod]
        public void FactoryWillThrowExceptionWhenRunnerNotFound()
        {
            
            Script script = new Script
            {
                Type = "UnknownType",
                Name = "Some name"
            };
            try
            {
                var runner = _factory.CreateScriptRunner(script);
            }
            catch (RunnerNotFoundException e)
            {
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FactoryWillReturnSomeRunners()
        {
            Assert.AreNotEqual(_factory.Runners.Count, 0);
        }

        [TestMethod]
        public void FactoryConstructorFailWithNullConfig()
        {
            try
            {
                var factory = new ScriptRunnerFactory(null);
            }
            catch (ArgumentNullException e)
            {
                return;
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
