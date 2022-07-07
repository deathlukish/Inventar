using FKCPObj;
using FKCPObj.Config;
using Inventar.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventar.ViewModels
{
    internal class ConfiguratorViewModel:ViewModel
    {
        private BaseConfigToLoad _baseConfig;
        public ICommand SaveConfig { get; }
        private bool CanSaveConfig(object p) => true;
        private void OnSaveConfig(object p) => ConfigLoad.SaveConfig();
        public string BotName { get => _baseConfig.ApiToken.Name; set => _baseConfig.ApiToken.Name = value; }
        public string BotToken { get => _baseConfig.ApiToken.Token; set => _baseConfig.ApiToken.Token = value; }
        public string XmlUrl { get => _baseConfig.XMLInterface.ServerURL; set => _baseConfig.XMLInterface.ServerURL = value; }
        public string XmlUSer { get => _baseConfig.XMLInterface.Login; set => _baseConfig.XMLInterface.Login = value; }
        public string XmlPas { get => _baseConfig.XMLInterface.Password; set => _baseConfig.XMLInterface.Password = value; }
        public ConfiguratorViewModel()
        {
            SaveConfig = new RelayCommand(OnSaveConfig, CanSaveConfig);
            _baseConfig = ConfigLoad.GetConfig();

        }
    }
}
