using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.Generic;
using StaticAnalysisContractsLib;
using UtilityLib;

namespace FxCopLib
{
    public class FxCop : IStaticAnalysisTool
    {
        private string InputDirectory { get; set; }
        private string Argument { get; set; }
        private string OutputFileDirectory { get; set; }
        private string InputProjFile { get; set; }
        private string CurrentDirectory { get; set; }
        private string InstallationPath { get; set; }
        public FxCop(string InstallationPath)
        {
            this.InstallationPath = InstallationPath;
        }
        public bool PrepareInput(string inputDirectory)
        {
            bool success = true;
            InputDirectory = inputDirectory;
            CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            OutputFileDirectory = CurrentDirectory + "\\StaticAnalysisReports";
            InputProjFile = CurrentDirectory + "\\FxCopInput.FxCop";
            if (!Helper.CheckFileExists(InputProjFile))
            {
                success = false;
                return success;
            }
            XElement root = XElement.Load(InputProjFile);
            XElement requiredTag = (from elem in root.DescendantsAndSelf()
                                    where elem.Name == "Target"
                                    select elem).FirstOrDefault();
            if (requiredTag != null)
            {
                requiredTag.SetValue(GetFiles(InputDirectory));
            }
            return success;
        }

        public void ProcessOutput()
        {
            string argument = PrepareArgument(InputProjFile, OutputFileDirectory);
            Helper.ExecuteStaticAnalysisTool(InstallationPath, argument);
            if (Helper.CheckFileExists(OutputFileDirectory + "\\FxCopResults.xml"))
            {
                Parser obj = new Parser(OutputFileDirectory + "\\FxCopResults.xml");
            }
        }
        private static string GetFiles(string _inputDirectory)
        {
            string filename;
            filename = Directory.GetFiles(_inputDirectory, "*.exe", SearchOption.AllDirectories).First();
            return filename;
        }
        private static string PrepareArgument(string InputFile, string OutputDirectory)
        {
            string argument = "/p:"+InputFile+ " /out:"+ OutputDirectory+"\\FxCopResults.xml";
            return argument;
        }
    }
}
