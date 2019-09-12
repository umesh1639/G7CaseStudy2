using ConfigurationLib;
using StaticAnalysisToolContracts;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UtilityLib;

namespace StaticAnalyzer
{
    public class Program
    {
        static int Main(string[] args)
        {
            string configurationFilePath;
            string inputPath = "";
            if (args.Length != 2)
            {
                Console.WriteLine("Input Path not provided");
                return -1;
            }
            configurationFilePath = args[0];
            inputPath = args[1];
            if (Helper.CheckDirectoryExists(inputPath))
            {
                if (Helper.CheckFileExists(configurationFilePath))
                {
                    Console.WriteLine("Welcome to Static Analysis Tool");

                    IConfiguration toolsConfiguration = new ToolsConfiguration(configurationFilePath);
                    var toolsConfigurationList = toolsConfiguration.LoadConfiguration();

                    StaticAnalysisApplication staticAnalysis = new StaticAnalysisApplication(toolsConfigurationList);

                    int errorcode = staticAnalysis.Run(inputPath);
                    if (errorcode == -2)
                    {
                        return -2;
                    }
                }
            }
            return 0;
        }
    }
}
