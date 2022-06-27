using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.Config
{
    public class BaseConfigToLoad
    {
        public ApiToken? ApiToken { get; set; } = new();
        public List<ListenerForBot>? ListenerForBot { get; set; } = new();
    }
}
