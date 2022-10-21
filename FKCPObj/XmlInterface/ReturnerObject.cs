using FKCPObj.SimpleClass;
using System.Xml.Serialization;

namespace FKCPObj.XmlInterface
{
    public class ReturnerObject
    {
     
        public async Task<RK7QueryResult> GetObjectFromXmlInterface()
        {
            
            XmlQueryBuilder xmlQuery = new();
            //xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.CASHES,true, "Code", "AltName", "DeviceLicenses", "Childs","Name");
            xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.RESTAURANTS, true, "Code", "AltName", "DeviceLicenses", "Childs", "Name");
            //xmlQuery.AddCommand(Rk7Cmd.GetRefData, RefNames.EMPLOYEES, true);
            string s = await SenderQuery.GetResultXML(xmlQuery);
            var xml = new XmlSerializer(typeof(RK7QueryResult));
            using (var sr = new StringReader(s))
            {
                return (RK7QueryResult)xml.Deserialize(sr);
            }
            
        }
    }
}
