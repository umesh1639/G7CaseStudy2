using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class Helper
    {
        public static bool CheckFileExists(string filepath)
        {
            bool success = false;
            if (File.Exists(filepath))
            {
                success = true;
            }
            return success;
        }
        public static bool CheckDirectoryExists(string directoryPath)
        {
            bool success = false;
            if (Directory.Exists(directoryPath))
            {
                success = true;
            }
            return success;
        }
        public static void ExecuteStaticAnalysisTool(string exeFileAndLocation, string arguments)
        {
            using (Process ExeToExecute = Process.Start(exeFileAndLocation, arguments))
            {
                ExeToExecute.WaitForExit();
            }
        }
    }
}
