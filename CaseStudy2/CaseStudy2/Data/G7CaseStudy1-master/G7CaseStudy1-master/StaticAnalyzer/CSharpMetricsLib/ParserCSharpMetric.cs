using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UtilityLib;

namespace StaticAnalyzer.PluginWrappers.CSharpMetric
{
    public class ParserCSharpMetric
    {
        private Dictionary<string, Dictionary<string, string>> MetricMap = new Dictionary<string, Dictionary<string, string>>();
        public void parseXML(string filepath)
        {
            if (Helper.CheckFileExists(filepath))
            {
                XElement root = XElement.Load(filepath);
                //Processing of XML to get required data
                var fileElement = from elem in root.DescendantsAndSelf()
                                  where elem.Name == "FileMetrics"
                                  select elem;
                foreach (var elem in fileElement)
                {
                    XElement filenameElement = elem.Descendants("FileName").FirstOrDefault();
                    if (filenameElement != null)
                    {
                        Dictionary<string, string> MetricOfEachFile = new Dictionary<string, string>();
                        foreach (var child in elem.Descendants("FileSummary").Elements())
                        {
                            string key = child.Name.ToString();
                            string value = child.Value;
                            MetricOfEachFile[key] = value;
                        }
                        string filename = filenameElement.Value.ToString();
                        MetricMap.Add(filename, MetricOfEachFile);

                    }
                }
                displayOutput();
            }
        }
        private void displayOutput()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*******************CSharpMetrics Result********************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine();
            foreach (var key in MetricMap.Keys)
            {
                Console.WriteLine("***********************************************************");
                Console.WriteLine(key);
                foreach (KeyValuePair<string, string> MetricMapValue in MetricMap[key])
                {
                    Console.WriteLine(MetricMapValue.Key + "\t" + MetricMapValue.Value);
                }

            }
        }
    }
}
