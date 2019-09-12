using StaticAnalysisContractsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ToolsMetaLib;

namespace ConfigurationLib
{
    public class StaticAnalysisApplication
    {
        private IEnumerable<IStaticAnalysisTool> StaticAnalysisPlugins;
        public IEnumerable<IStaticAnalysisTool> ToolObjectList => StaticAnalysisPlugins;
        public StaticAnalysisApplication(IEnumerable<ToolMeta> staticAnalysisPluginMeta)
        {
            StaticAnalysisPlugins = IntializeToolsList(staticAnalysisPluginMeta);
        }

        private IEnumerable<IStaticAnalysisTool> IntializeToolsList(IEnumerable<ToolMeta> configuredTools)
        {
            List<IStaticAnalysisTool> availableTools = new List<IStaticAnalysisTool>();

            foreach (var toolMeta in configuredTools)
            {
                var assembly = Assembly.LoadFile(toolMeta.Wrapper.Assembly);
                var toolClassType = toolMeta.Wrapper.Namespace + "." + toolMeta.Wrapper.ClassName;
                var type = assembly.GetType(toolClassType);
                if (!(type == null))
                {
                    object tool;

                    var constructor = type.GetConstructor(new Type[] { typeof(string) });
                    if (constructor != null)
                    {
                        tool = constructor.Invoke(new string[] { toolMeta.InstallationPath });
                    }
                    else
                    {
                        var defaultConstructor = type.GetConstructors(BindingFlags.Public).First();
                        tool = defaultConstructor.Invoke(null);
                    }

                    availableTools.Add((IStaticAnalysisTool)tool);
                }
                else
                {
                    Console.WriteLine($"Tool {toolMeta.Name} not found at {toolMeta.Wrapper}");
                }
            }

            return availableTools;

        }

        public int Run(string inputPath)
        {
            int exitCode = 0;
            try
            {
                foreach (var tool in StaticAnalysisPlugins)
                {
                    tool.PrepareInput(inputPath);
                    tool.ProcessOutput();
                }
            }
            catch(Exception exception)
            {
                var ex = exception.GetType();
                exitCode = -2;
            }
            return exitCode;
        }
    }
}
