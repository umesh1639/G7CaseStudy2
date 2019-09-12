using StaticAnalysisToolContracts;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ToolsMetaLib;

namespace ConfigurationLib
{
    public class ToolsConfiguration : IConfiguration
    {
        private List<ToolMeta> tools = new List<ToolMeta>();
        private string configurationFilepath;
        public ToolsConfiguration(string configurationFilepath)
        {
            this.configurationFilepath = configurationFilepath;
        }
        public IReadOnlyCollection<ToolMeta> LoadConfiguration()
        {
            XElement configurationRoot = XElement.Load(configurationFilepath);
            if (configurationRoot != null)
            {
                var installedPlugins = from element in configurationRoot.DescendantsAndSelf()
                                       where element.Name == "installedPlugins"
                                       select element;
                foreach (var element in installedPlugins.Elements())
                {
                    ToolMeta.WrapperMeta wrapperMeta =
                        new ToolMeta.WrapperMeta(
                            element.Attribute("wrapperClassName").Value, element.Attribute("namespace").Value, element.Attribute("assembly").Value);

                    tools.Add(new ToolMeta
                      (
                        element.Attribute("name").Value,
                        element.Attribute("installationPath").Value,
                        wrapperMeta
                      ));
                }
                
            }
            return tools;
        }

    }
}
