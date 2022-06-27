using FKCPObj.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj
{
    public class ConfigLoad
    {
        private readonly string _Path = "./Config.json";
        /// <summary>
        /// Сохранить конфигурацию
        /// </summary>
        /// <param name="configLoad"></param>
        public void SaveConfig(BaseConfigToLoad configLoad)
        {
            
            var jsonString = JsonConvert.SerializeObject(configLoad);
            using (StreamWriter fs = new StreamWriter(_Path))
            {
                fs.WriteLine(jsonString);
            }
        }
        /// <summary>
        /// Загрузить конфигурацию
        /// </summary>
        /// <returns></returns>
        public BaseConfigToLoad LoadConfig()
        {
            if (!File.Exists(_Path))
            {
                using (FileStream fs = File.Create(_Path))
                {

                }
            }
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All

            };
            BaseConfigToLoad clients = new();
            using (StreamReader streamReader = new StreamReader(_Path))
            {
               
                clients = JsonConvert.DeserializeObject<BaseConfigToLoad>(streamReader.ReadToEnd());

            }
            return clients;

        }
    }
}
