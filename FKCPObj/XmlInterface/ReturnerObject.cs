using FKCPObj.SimpleClass;
using System.Xml.Linq;

namespace FKCPObj.XmlInterface
{
    public class ReturnerObject
    {
        public List<SimpleOP>? GetAllOp()
        {
            List<SimpleOP>? b =  new();
            XmlQueryCreater xmlQuery = new();
            xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.RESTAURANTS, "Code", "AltName", "DeviceLicenses", "Status");
            string a = SenderQuery.GetResultXML(xmlQuery);
            XDocument doc = XDocument.Parse(a);
            if (doc.Element("RK7QueryResult")?
                .Element("CommandResult")?
                .Attribute("Status")?.Value == "Ok")
            {
                     b = doc.Element("RK7QueryResult")?
                    .Element("CommandResult")?
                    .Element("RK7Reference")?
                    .Element("Items")?
                    .Elements("Item")?
                    .Select(step => new SimpleOP
                    {
                        Ident = Convert.ToUInt32(step?.Attribute("Ident")?.Value),
                        AltName = step?.Attribute("AltName")?.Value,
                        Code = Convert.ToUInt64(step?.Attribute("Code")?.Value),
                        Status = step?.Attribute("Status")?.Value,
                        LicenseTxt = step?.Element("DeviceLicenses")?
                        .Element("Items")?
                        .Element("Item")?
                        .Attribute("LicenseTxt")?.Value
                        .ToString(),
                        ExpiresAT = step?.Element("DeviceLicenses")?
                        .Element("Items")?
                        .Element("Item")?
                        .Attribute("ExpiresAT")?.Value
                        .ToString(),
                    })?.ToList();
            }
            return b;
        }

        public List<SimpleUK> GetAllUK()
        {
            XmlQueryCreater xmlQuery = new();
            xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.CASHES);
            string a = SenderQuery.GetResultXML(xmlQuery);
            XDocument doc = XDocument.Parse(a);
            List<SimpleUK>? b = doc.Element("RK7QueryResult")?
                .Element("CommandResult")?
                .Element("RK7Reference")?
                .Element("Items")?
                .Elements("Item")?
                .Select(step => new SimpleUK
                {
                    Ident = Convert.ToInt32(step.Attribute("Ident")?.Value),
                    Name = step.Attribute("Name").Value
                    //Ident = Convert.ToUInt32(step?.Attribute("Ident")?.Value),
                    //AltName = step?.Attribute("AltName")?.Value,
                    //Code = Convert.ToUInt64(step?.Attribute("Code")?.Value),
                    //Status = step?.Attribute("Status")?.Value,
                    //LicenseTxt = step?.Element("DeviceLicenses")?
                    //.Element("Items")?
                    //.Element("Item")?
                    //.Attribute("LicenseTxt")?.Value
                    //.ToString(),
                    //ExpiresAT = step?.Element("DeviceLicenses")?
                    //.Element("Items")?
                    //.Element("Item")?
                    //.Attribute("ExpiresAT")?.Value
                    //.ToString(),
                })?.ToList();
            return b;
        }
    }
}
