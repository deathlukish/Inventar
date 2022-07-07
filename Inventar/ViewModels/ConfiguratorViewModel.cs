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
        private string _botName;
        private string _botToken;
        public ICommand SaveConfig { get; }
        private bool CanSaveConfig(object p) => true;
        private void OnSaveConfig(object p) => ConfigLoad.SaveConfig();


        private BaseConfigToLoad _baseConfig;
        public string BotName { get => _botName; set => Set(ref _botName, value); }
        public string BotToken { get => _botToken; set => Set(ref _botToken, value); }
        public ConfiguratorViewModel()
        {
            SaveConfig = new RelayCommand(OnSaveConfig, CanSaveConfig);
            _baseConfig = ConfigLoad.GetConfig();
            _botName =  _baseConfig.ApiToken.Name;
            _botToken = _baseConfig.ApiToken.Token;
        }
    }
}
