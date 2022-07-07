using FKCPObj.SimleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.SimpleClass
{
    public interface IEgais<T> where T : SimpleOP
    {
        ulong FsrarID { get; set; }
        DateOnly Gost { get; set; }
        DateOnly RSA { get; set; }
        public IEgais<T> GetEgaisLic();
        public void SetEgaisLic();


    }
}
