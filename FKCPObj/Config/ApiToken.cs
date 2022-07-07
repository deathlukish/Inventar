using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.Config
{
    public class ApiToken
    {
        /// <summary>
        /// Токен бота
        /// </summary>
        public string? Token { get;
            set; } 
        /// <summary>
        /// Имя бота
        /// </summary>
        public string? Name { get; set; }
    }
}
