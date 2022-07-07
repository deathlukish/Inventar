using FKCPObj.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj
{
    public static class ConfigLoad
    {
        private static readonly string _path = "./Config.json";
        private static BaseConfigToLoad? _config;        
        static ConfigLoad()
        {
            _config = LoadConfig();
        }

        /// <summary>
        /// Сохранить конфигурацию
        /// </summary>
        /// <param name="configLoad"></param>
        public static void SaveConfig()
        {
            string _path = "./Config.json";
            var jsonString = JsonConvert.SerializeObject(_config);
            using (StreamWriter fs = new StreamWriter(_path))
            {
                fs.WriteLine(jsonString);
            }
        }
        /// <summary>
        /// Загрузить конфигурацию
        /// </summary>
        /// <returns></returns>
        private static BaseConfigToLoad LoadConfig()
        {
            string _Path = "./Config.json";
            BaseConfigToLoad clients = new();
            if (!File.Exists(_Path))
            {
                using (FileStream fs = File.Create(_Path))
                {

                }
            }           
            using (StreamReader streamReader = new StreamReader(_Path))
            {
               
                clients = JsonConvert.DeserializeObject<BaseConfigToLoad>(streamReader.ReadToEnd());

            }
            return clients;

        }
        public static BaseConfigToLoad GetConfig() => _config;
    }
}
