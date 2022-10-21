using System.Xml.Serialization;

namespace FKCPObj.SimpleClass
{

    [XmlRoot("RK7QueryResult")]
    public class RK7QueryResult
    {
        [XmlAttribute]
        public string? ServerVersion { get; set; }
        [XmlAttribute]
        public string? XmlVersion { get; set; }
        [XmlAttribute]
        public string? NetName { get; set; }
        [XmlAttribute]
        public string? Status { get; set; }
        [XmlAttribute]
        public string? Processed { get; set; }
        [XmlElement]
        public List<CommandResult> CommandResult { get; set; }
    }
    public class CommandResult
    {
        [XmlAttribute]
        public string? CMD { get; set; }
        [XmlAttribute]
        public string? Status { get; set; }
        [XmlAttribute]
        public string? ErrorText { get; set; }
        [XmlAttribute]
        public string? DateTime { get; set; }
        [XmlAttribute]
        public string? WorkTime { get; set; }
        [XmlElement]
        public RK7Reference RK7Reference { get; set; }
        [XmlElement]
        public SourceCommand SourceCommand { get; set; }
    }
    public class SourceCommand
    {
        [XmlElement]
        public RK7Command2 RK7Command2 { get; set; }
    }
    public class RK7Command2
    {
        [XmlAttribute]
        public string? CMD { get; set; }
        [XmlAttribute]
        public string? RefName { get; set; }
    }
    public class RK7Reference
    {
        [XmlAttribute]
        public string? DataVersion { get; set; }
        [XmlAttribute]
        public string? Name { get; set; }
        [XmlElement]
        public Items Items { get; set; }

    }
    public class Items
    {
        [XmlElement]
        public List<Item> Item { get; set; }
    
    }
    public class Item
    {
        [XmlAttribute]
        public string Ident { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string AltName { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlElement]
        public DeviceLicenses DeviceLicenses { get; set; }
        [XmlElement]
        public Childs Childs { get; set; }
    }
    public class DeviceLicenses
    {
        [XmlElement]
        public ItemsLic Items { get; set; }
    }
    public class ItemsLic
    {
        [XmlElement]
        public List<ItemLic> Item { get; set; }
    }
    public class ItemLic
    {
        [XmlAttribute]
        public string Ident { get; set; }
        [XmlAttribute]
        public string LicenseTxt { get; set; }
        [XmlAttribute]
        public string ExpiresAT { get; set; }
    }
    public class Childs
    {
        [XmlElement]
        public List<Child> Child { get; set; }
    }
    public class Child
    {
        [XmlAttribute]
        public string ChildIdent { get; set; }
        [XmlAttribute]
        public string IsTerminal { get; set; }
    }
}
