using FKCPObj;
using FKCPObj.SimpleClass;
using FKCPObj.XmlInterface;
using Inventar.Command;
using Inventar.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Telegram.Bot.Types;
using TelegramBotPolling;
using TelegramPolling;

namespace Inventar.ViewModels
{
    internal class MainVindowViewModel:ViewModel
    {

        public ICommand OpenConfig { get; }
        private bool CanOpenGonfig(object p) => true;
        private void OnOpenConfig(object p) => new Configurator().Show();
        public MainVindowViewModel()
        {
            OpenConfig = new RelayCommand(OnOpenConfig, CanOpenGonfig);
            BotInit bot = new BotInit(ConfigLoad.GetConfig().ApiToken!.Token!);
            UpdateHandlers.Update += (Message a)=>MessageBox.Show(a.From?.ToString());
            ReturnerObject returner = new();
            var a = returner.GetAllUK();

        }







    }
}
