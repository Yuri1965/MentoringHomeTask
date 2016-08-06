using System;
using System.Text;

namespace XMLUtil
{
    static class Program
    {
        private static int minCountParams = 3;
        private static int maxCountParams = 4;

        static void Main(string[] args)
        {
            if (args.Length < minCountParams || args.Length > maxCountParams)
            {
                StringBuilder message = new StringBuilder();

                message.Append("Usage: XMLUtil.exe /<command> <param1> <param2> <param3>");
                message.AppendLine("for examples:");
                message.AppendLine(@"   Check XML file: XMLUtil.exe /checkByScheme c:\sourceXMLFile\xmlFile.xml c:\sourceXSDFile\xsdSchemeFile.xsd");
                message.AppendLine(@"   Translate XML files to Atom format file: XMLUtil.exe /translateToAtom c:\sourceXMLtoAtom\xmlFile.xml c:\outputAtom\feedAtom.xml c:\sourceXSLTSchemeFiles\sourceXSLTSchemeFileToAtom.xslt");
                message.AppendLine(@"   Translate XML file to HTML report: XMLUtil.exe /translateToHTML c:\sourceXMLFile\xmlFile.xml c:\outputHTMLFile\report.html c:\sourceXSLTSchemeFiles\translateSchemeFileToHTML.xslt");
                XMLUtils.PrintMessage(message.ToString());

                return;
            }

            XMLUtils.runCommand(args);
        }
    }
}

