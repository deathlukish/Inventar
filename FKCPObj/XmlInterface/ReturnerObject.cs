using FKCPObj.SimpleClass;
using System.Xml.Serialization;

namespace FKCPObj.XmlInterface
{
    public class ReturnerObject
    {
     
        public CommandResults GetObjectFromXmlInterface()
        {
            
            XmlQueryBuilder xmlQuery = new();
            //xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.CASHES,true, "Code", "AltName", "DeviceLicenses", "Childs","Name");
            xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.RESTAURANTS, true, "Code", "AltName", "DeviceLicenses", "Childs", "Name");
            //xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.EMPLOYEES, true);
            string s = SenderQuery.GetResultXML(xmlQuery);
            var xml = new XmlSerializer(typeof(CommandResults));
            using (var sr = new StringReader(s))
            {
                return (CommandResults)xml.Deserialize(sr);
            }
            
        }
    }
}
