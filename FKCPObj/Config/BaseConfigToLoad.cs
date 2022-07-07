using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.Config
{
    public class BaseConfigToLoad
    {
        /// <summary>
        /// Конфигурация бота
        /// </summary>
        public ApiToken? ApiToken { get; set; } = new();
        /// <summary>
        /// Конфигурация XML интерфейса R-Keeper
        /// </summary>
        public ConfigXMLInterface? XMLInterface { get; set; } = new();
        /// <summary>
        /// Список подписчиков бота
        /// </summary>
        public List<ListenerForBot>? ListenerForBot { get; set; } = new();
    }
}
