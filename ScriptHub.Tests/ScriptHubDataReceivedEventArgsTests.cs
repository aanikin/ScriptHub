using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptHub.Model;

namespace ScriptHub.Tests
{
    [TestClass]
    public class ScriptHubDataReceivedEventArgsTests
    {
        [TestMethod]
        public void ScriptHubDataReceivedEventArgsCreatedCorrectly()
        {
            var testData = "test";
            var scriptHubDataReceivedEventArgs = new ScriptHubDataReceivedEventArgs(testData);
            Assert.AreEqual(testData, scriptHubDataReceivedEventArgs.Data);
        }
    }
}
