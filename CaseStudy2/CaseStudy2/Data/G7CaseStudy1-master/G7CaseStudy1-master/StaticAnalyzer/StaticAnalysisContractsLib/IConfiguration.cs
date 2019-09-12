
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMetaLib;

namespace StaticAnalysisToolContracts
{
    public interface IConfiguration
    {
        IReadOnlyCollection<ToolMeta> LoadConfiguration();
    }
}
