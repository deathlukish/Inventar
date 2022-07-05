using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.SimpleClass
{
    public interface ILicense
    {
        TypeLicense LicenseType { get; set; }
        DateTime LicenseExpirinse { get; set; }
        public ILicense GetLicense();
        public ILicense SetLicense();
    }
}
