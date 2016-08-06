using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace XMLUtil
{
    public class XMLUtils
    {
        public static void runCommand(string[] parameters)
        {
            string command = parameters[0];

            switch (command)
            {

                case "/checkByScheme":
                    try
                    {
                        //parameters[1] - xml file for check
                        //parameters[2] - xsd file by check
                        using (Stream checkXMLFileStream = File.Open(parameters[1], FileMode.Open, FileAccess.Read),
                            schemeXMLFileStream = File.Open(parameters[2], FileMode.Open, FileAccess.Read))
                        {
                            ValidateXmlFile(checkXMLFileStream, schemeXMLFileStream);
                        }
                    }
                    catch (Exception e)
                    {
                        PrintMessage(String.Format("Return errors: {0}", e.Message));
                    }

                    break;

                case "/translateToAtom":
                    //parameters[1] - xml input file 
                    //parameters[2] - xml output file (Atom format)
                    //parameters[3] - xslt file for transform to Atom format
                    runTransformXmlFile(parameters[1], parameters[2], parameters[3]);

                    break;

                case "/translateToHTML":

                    //parameters[1] - xml input file 
                    //parameters[2] - xml output file (HTML format)
                    //parameters[3] - xslt file for transform to HTML format
                    runTransformXmlFile(parameters[1], parameters[2], parameters[3]);

                    break;

                default:
                    PrintMessage(String.Format("Unknown Command /{0}", command));
                    break;
            }
        }

        private static void ValidateXmlFile(Stream xmlFile, Stream xmlSchemeFile)
        {
            var hasErrors = false;

            // Prepare validation settings
            var schema = XmlSchema.Read(xmlSchemeFile, null);

            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add(schema);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += (sender, eventArgs) =>
            {
                hasErrors = true;

                PrintMessage(String.Format("Validation error at line {0} column {1}: {2}",
                    eventArgs.Exception.LineNumber, eventArgs.Exception.LinePosition, eventArgs.Message));
            };

            // Read and validate file
            var reader = XmlReader.Create(xmlFile, xmlReaderSettings);
            while (reader.Read()) ;

            if (!hasErrors)
                PrintMessage("Validation successful, no errors reported!");
        }

        private static void runTransformXmlFile(string inputFile, string outputFile, string transformSchemeFile)
        {
            try
            {
                using (Stream sourceXMLFileStream = File.Open(inputFile, FileMode.Open, FileAccess.Read),
                    outputXMLFileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write),
                    schemeXSLTFileStream = File.Open(transformSchemeFile, FileMode.Open, FileAccess.Read)
                    )
                {
                    TransformXmlFile(schemeXSLTFileStream, sourceXMLFileStream, outputXMLFileStream);
                }

                PrintMessage(String.Format("Transformation successful! Watch the file:\n{0}", outputFile));
            }
            catch (Exception e)
            {
                PrintMessage(String.Format("Return errors: {0}", e.Message));
            }
        }

        private static void TransformXmlFile(Stream xsltFile, Stream inputStream, Stream outputStream)
        {
            var transform = new XslCompiledTransform();
            var extXSLT = new ExtXSLTUtils();

            transform.Load(XmlReader.Create(xsltFile));

            var xslArguments = new XsltArgumentList();
            xslArguments.AddExtensionObject("urn:mentoring.advanced.xml.onlineLibrary.ext", extXSLT);

            transform.Transform(XmlReader.Create(inputStream), xslArguments, XmlWriter.Create(outputStream));
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(" ");
            Console.WriteLine(message);
        }
    }
}
