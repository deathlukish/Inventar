using FKCPObj.SimpleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FKCPObj.XmlInterface
{
    public class ReturnerObject
    {
        public List<SimpleOP> GetAllOp()
        {
            SenderQuery senderQuery = new();
            string a = senderQuery.GetResultXML();
            XDocument doc = XDocument.Parse(a);
            List<SimpleOP>? b = doc.Element("RK7QueryResult")?
                .Element("CommandResult")?
                .Element("RK7Reference")?
                .Element("Items")?
                .Elements("Item")?
                .Select(step => new SimpleOP
                {
                    LicenseTxt = step.Element("DeviceLicenses")?
                    .Element("Items")?
                    .Element("Item")?
                    .Attribute("LicenseTxt")?.Value
                    .ToString(),
                    NetName = step?.Attribute("Ident")?.Value

                })?.ToList();
            return b;
        }
    }
}
