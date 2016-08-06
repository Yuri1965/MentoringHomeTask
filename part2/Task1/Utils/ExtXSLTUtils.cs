using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;

namespace XMLUtil
{
    public class ExtXSLTUtils
    {
        public XPathNodeIterator DistinctTextNodes(XPathNodeIterator nodes)
        {
            var result = new XmlDocument();
            var existingsElements = new HashSet<string>();
            var root = result.CreateElement("root");
            
            foreach (var node in nodes)
            {
                var nodeStr = node.ToString();
            
                if (!existingsElements.Contains(nodeStr))
                {
                    existingsElements.Add(nodeStr);

                    var element = result.CreateElement("resultItem");
                    element.InnerText = nodeStr;

                    root.AppendChild(element);
                }
            }

            result.AppendChild(root);
            return result.CreateNavigator().Select("/root/resultItem");
        }

        public String convertStringDateTimeByFormat(string strDateTime, string formatDate, bool isUniversalDateTime)
        {
            DateTime resultDateTime;
            string result = "";

            if (DateTime.TryParse(strDateTime, out resultDateTime))
                result = (isUniversalDateTime ? resultDateTime.ToUniversalTime().ToString(formatDate) : resultDateTime.ToString(formatDate));

            return result;
        }

        public String GetCurrenDate(string formatDate, bool isUniversalDateTime)
        {
            return (isUniversalDateTime ? DateTime.Now.ToUniversalTime().ToString(formatDate) : DateTime.Now.ToString(formatDate));
        }
    }
}
