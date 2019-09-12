using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysisContractsLib
{
    public interface IStaticAnalysisTool
    {
        bool PrepareInput(string inputDirectory);
        void ProcessOutput();

    }
}
