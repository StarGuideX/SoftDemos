using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stone.CommonLib.XML
{
    public class XMLHelper
    {
        public void CreateXMLFile() {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Encoding.UTF8.ToString(), null));
            XmlElement root = doc.CreateElement("ROOT");





            doc.AppendChild(root);
            
        }
    }
}
