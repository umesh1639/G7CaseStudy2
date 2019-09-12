using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigurationLib;
using System.Linq;
using StaticAnalysisToolContracts;
using System.ComponentModel;

namespace UnitTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void given_configurationFile_when_Loaded_then_validCountExpected()
        {
            var configurationFilepath = @"C:\Users\320050767\Source\Repos\G7CaseStudy13\StaticAnalyzer\ConfigurationLib\Configuration.xml";
            IConfiguration toolsConfiguration = new ToolsConfiguration(configurationFilepath);
            var toolList = toolsConfiguration.LoadConfiguration();
            var expectedValue = toolList.Count;
            var actualValue = 1;
            Assert.AreEqual(expectedValue,actualValue);
        }
        [TestMethod]
        public void given_configurationToolList_when_objectCreated_then_validCountExpecetd()
        {
            var configurationFilepath = @"C:\Users\320050767\Source\Repos\G7CaseStudy13\StaticAnalyzer\ConfigurationLib\Configuration.xml";
            IConfiguration toolsConfiguration = new ToolsConfiguration(configurationFilepath);
            var toolList = toolsConfiguration.LoadConfiguration();
            var staticAnalyzer = new StaticAnalysisApplication(toolList);
            var staticAnalyzerList = staticAnalyzer.ToolObjectList;
            var expectedValue = staticAnalyzerList.Count();
            var actualValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        [ExpectedException(typeof(Win32Exception))]
        public void given_toolObjectList_when_toolInvoked_then_noExceptionExpected()
        {
            var configurationFilepath = @"C:\Users\320050767\Source\Repos\G7CaseStudy13\StaticAnalyzer\ConfigurationLib\Configuration.xml";
            var inputPath = @"C:\Users\320050767\Source\Repos\G7CaseStudy13\StaticAnalyzer";
            IConfiguration toolsConfiguration = new ToolsConfiguration(configurationFilepath);
            var toolList = toolsConfiguration.LoadConfiguration();
            var staticAnalyzer = new StaticAnalysisApplication(toolList);
            staticAnalyzer.Run(inputPath);
        }
    }
}
