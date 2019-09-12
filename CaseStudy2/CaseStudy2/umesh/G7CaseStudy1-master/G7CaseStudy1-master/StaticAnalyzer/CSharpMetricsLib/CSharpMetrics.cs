using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using StaticAnalyzer.PluginWrappers.CSharpMetric;
using UtilityLib;
using StaticAnalysisContractsLib;

namespace StaticAnalyzer
{
    public class CSharpMetrics : IStaticAnalysisTool
    {
        private string InputDirectory { get; set; }
        private string Argument { get; set; }
        private string OutputFileDirectory { get; set; }
        private string InputProjFile { get; set; }
        private string CurrentDirectory { get; set; }
        private string InstallationPath { get; set; }

        public CSharpMetrics(string installationPath)
        {
            InstallationPath = installationPath;
        }
        public bool PrepareInput( string inputDirectory)
        {
            bool success = true;
            InputDirectory = inputDirectory;
            CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            OutputFileDirectory = CurrentDirectory + "\\StaticAnalysisReports";
            InputProjFile = CurrentDirectory + "\\CSharpMetricInput";
            if (!File.Exists(InputProjFile))
            {
                success = false;
                return success;
            }
            List<string> filenames = GetFiles(InputDirectory);
            string requiredString = "CSharp~v6 Metrics 1.0\n" +"<" + CurrentDirectory + "\n"+ OutputFileDirectory + "\\CSharpMetricReport";
            try
            {
                using (StreamWriter streamwriter = new StreamWriter(InputProjFile))
                {
                    streamwriter.WriteLine(requiredString);
                    foreach (var str in filenames)
                    {
                        streamwriter.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }
        public void ProcessOutput()
        {
            Argument = PrepareArgument(InputDirectory, InputProjFile);
            Helper.ExecuteStaticAnalysisTool(InstallationPath, Argument);
            ParserCSharpMetric parserCSharpMetric = new ParserCSharpMetric();
            string filepath = Path.Combine(OutputFileDirectory, "CSharpMetricReport.xml");
            parserCSharpMetric.parseXML(filepath);
        }

        
        private static List<string> GetFiles(string _inputDirectory)
        {
            List<string> filenames = new List<string>();
            filenames = Directory.GetFiles(_inputDirectory,"*.cs",SearchOption.AllDirectories).ToList();
            return filenames; 
        }
        private static string PrepareArgument(string InputDirectory,string InputProjFile)
        {
            string argument = "CSharp~v6 " + InputProjFile;
            return argument;
        }
    }
}
