using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsMetaLib
{
    public class ToolMeta
    {
        public string Name { get; private set; }
        public string InstallationPath { get; private set; }
        public WrapperMeta Wrapper { get; private set; }

        public ToolMeta(string name, string path, WrapperMeta wrapperDetails)
        {
            Name = name;
            InstallationPath = path;
            Wrapper = wrapperDetails;
        }

        public class WrapperMeta
        {
            public string ClassName { get; private set; }
            public string Namespace { get; private set; }
            public string Assembly { get; private set; }

            public WrapperMeta(string className, string nameSpace,string assembly)
            {
                ClassName = className;
                Namespace = nameSpace;
                Assembly = assembly;
            }
        }
    }

}

