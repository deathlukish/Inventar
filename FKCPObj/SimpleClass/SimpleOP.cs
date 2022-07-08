using FKCPObj.SimpleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.SimleClass
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
        public string? LicenseTxt { get; set; }
        public string? NetName { get; set; }
        public LicTest? licTest { get; set; }

    }
}
