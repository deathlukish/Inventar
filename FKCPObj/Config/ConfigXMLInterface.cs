using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.Config
{
    public class ConfigXMLInterface
    {
        /// <summary>
        /// Адрес сервера
        /// </summary>
        public string ServerURL { get; set; }
        /// <summary>
        /// Логин пользователя с правами XML интерфейса
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя с правами XML интерфейса
        /// </summary>
        public string Password { get; set; }
    }
}
