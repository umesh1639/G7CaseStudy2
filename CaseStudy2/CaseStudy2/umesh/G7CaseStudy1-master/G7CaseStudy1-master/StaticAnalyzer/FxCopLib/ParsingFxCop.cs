using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FxCopLib
{

    class Parser
    {


        public Parser(string fileName)
        {
            XElement root = XElement.Load(fileName);
            var issues = GetAllIssues(root);
            NumberOfIssues = issues.Count;
            Console.WriteLine(NumberOfIssues + "\n");

            var criticalErrors = GetCriticalErrors(issues);
            var errors = GetErrors(issues);
            var criticalWarnings = GetCriticalWarnings(issues);
            var warnings = GetWarnings(issues);

            NumberOfCriticalErrors = criticalErrors.Count;
            NumberOfErrors = errors.Count;
            NumberOfCriticalWarnings = criticalWarnings.Count;
            NumberOfWarnings = warnings.Count;

            Console.WriteLine("NumberOfCriticalErrors " + NumberOfCriticalErrors + "\n");
            Console.WriteLine("NumberOfErrors" + NumberOfErrors + "\n");
            Console.WriteLine("NumberOfCriticalWarnings " + NumberOfCriticalWarnings + "\n");
            Console.WriteLine("NumberOfWarnings " + NumberOfWarnings + "\n");
        }

        public int NumberOfIssues { get; private set; }

        public int NumberOfCriticalErrors { get; private set; }

        public int NumberOfErrors { get; private set; }

        public int NumberOfCriticalWarnings { get; private set; }

        public int NumberOfWarnings { get; private set; }

        private List<XElement> GetAllIssues(XElement doc)
        {
            IEnumerable<XElement> issues =
                from el in doc.Descendants("Issue")
                select el;

            return issues.ToList();
        }

        private List<XElement> GetCriticalErrors(List<XElement> issues)
        {
            IEnumerable<XElement> errors =
                from el in issues
                where (string)el.Attribute("Level") == "CriticalError"
                select el;

            return errors.ToList();
        }

        private List<XElement> GetErrors(List<XElement> issues)
        {
            IEnumerable<XElement> errors =
                from el in issues
                where (string)el.Attribute("Level") == "Error"
                select el;

            return errors.ToList();
        }

        private List<XElement> GetCriticalWarnings(List<XElement> issues)
        {
            IEnumerable<XElement> warn =
                from el in issues
                where (string)el.Attribute("Level") == "CriticalWarning"
                select el;

            return warn.ToList();
        }

        private List<XElement> GetWarnings(List<XElement> issues)
        {
            IEnumerable<XElement> warn =
                from el in issues
                where (string)el.Attribute("Level") == "Warning"
                select el;

            return warn.ToList();
        }
    }
}