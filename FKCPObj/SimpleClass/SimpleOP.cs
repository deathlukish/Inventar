
namespace FKCPObj.SimpleClass
{
    public class SimpleOP
    {
        private byte _NumOp;
        private string _NetName;
        private string _RKeepName;
        private string _VendorName;
        private string _ModelName;
        private string _Version;
        private uint _DiskSize;
        private uint _OZUSize;
        private TypeLicense _TypeLicense;
        private DateOnly _DateEndLicense;
        public ulong Ident { get; set; }
        public string? AltName { get; set; }
        public int Code { get; set; }
        public string? LicenseTxt { get; set; }
        public string ExpiresAT { get; set; }



    }
}
