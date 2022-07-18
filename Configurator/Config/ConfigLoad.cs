using FKCPObj.Config;
using Newtonsoft.Json;

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
            
            BaseConfigToLoad clients = new();
            if (!File.Exists(_path))
            {
                using (FileStream fs = File.Create(_path))
                {

                }
            }           
            using (StreamReader streamReader = new StreamReader(_path))
            {
               
                clients = JsonConvert.DeserializeObject<BaseConfigToLoad>(streamReader.ReadToEnd());

            }
            return clients;

        }
        /// <summary>
        /// Получить объект конфигурации
        /// </summary>
        /// <returns></returns>
        public static BaseConfigToLoad GetConfig() => _config;
    }
}
