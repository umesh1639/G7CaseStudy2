using StaticAnalysisContractsLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UtilityLib;

namespace NDependLib
{
    public class Ndepend : IStaticAnalysisTool
    {
        private string InstallationPath { get; set; }
        private string InputDirectory { get; set; }
        private string Argument { get; set; }
        private string OutputDirectory { get; set; }
        private string InputProjFile { get; set; }
        private string CurrentDirectory { get; set; }
        public Ndepend(string InstallationPath)
        {
            this.InstallationPath = InstallationPath;
        }
        public bool PrepareInput(string inputDirectory)
        {
            bool success = true;
            CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            InputDirectory = inputDirectory;
            OutputDirectory = CurrentDirectory + "\\StaticAnalysisReports";
            InputProjFile = CurrentDirectory + "\\NDependInput.ndproj";
           


            XElement root = XElement.Load(InputProjFile);
            XElement requiredVal = (from elem in root.DescendantsAndSelf()
                                    where elem.Name == "IDEFile"
                                    select elem).FirstOrDefault();
            if (requiredVal == null)
            {
                success = false;
                return success;
            }
            string slnFilename = GetFiles(InputDirectory);
            requiredVal.Attribute("FilePath").SetValue(slnFilename);
            root.Save(InputProjFile);
            return success;
        }
        public void ProcessOutput()
        {
            Argument = PrepareArgument(InputProjFile, OutputDirectory);
            Helper.ExecuteStaticAnalysisTool(InstallationPath, Argument);
            string filepath = Path.Combine(OutputDirectory ,"TrendMetrics\\NDependTrendData2019.xml");
            ParsingXmlNDepend parsingXmlNDepend = new ParsingXmlNDepend();
            parsingXmlNDepend.ShowingResultsAfterParsingNDependXml(filepath);
        }
        private string GetFiles(string _inputDirectory)
        {
            string filename;
            filename = Directory.GetFiles(_inputDirectory, "*.sln", SearchOption.AllDirectories).First();
            return filename;
        }
        private string PrepareArgument(string InputProjFile, string OutputDirectory)
        {
            string argument = InputProjFile + " /LogTrendMetrics /OutDir " + OutputDirectory;
            return argument;
        }

    }
}
