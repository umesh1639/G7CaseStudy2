using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace NDependLib
{
    internal class ParsingXmlNDepend
    {
        public void ShowingResultsAfterParsingNDependXml(string argument)
        {
            //string ques = Console.ReadLine();

            XmlTextReader reader = new XmlTextReader(argument);
            int flag = 0;
            Dictionary<string, string> NDependMetrics = new Dictionary<string, string>();
            List<string> attributeName = new List<string>();
            string[] attributeValue = null;
            while (reader.Read() && flag == 0)
            {

                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //Console.Write("<" + reader.Name);
                        if (reader.Name == "Metric")
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "Name")
                                {
                                    attributeName.Add(reader.Value);
                                }
                            }
                        }

                        if (reader.Name == "R" && flag == 0)
                        {
                            int i = 0;
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                            {
                                if (i == 2 && reader.Name == "V")
                                {
                                    //Console.Write("Debt is " + reader.Name + "='" + reader.Value + "");
                                    string ans = reader.Value;
                                    // Console.WriteLine(ans);
                                    // int x = 0;
                                    attributeValue = ans.Split('|');
                                }
                                i++;
                            }
                            flag = 1;
                        }
                        // Console.WriteLine(">");

                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }

            }

            for (int k = 0; k < attributeValue.Length; k++)
            {
                NDependMetrics.Add(attributeName[k], attributeValue[k]);
            }
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*******************Ndepend Result********************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine();
            foreach (var item in NDependMetrics)
            {
                Console.WriteLine(item);
            }

        }
    }
}
