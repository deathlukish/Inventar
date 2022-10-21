using FKCPObj;
using FKCPObj.SimpleClass;
using FKCPObj.XmlInterface;
using Inventar.Command;
using Inventar.Views;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using Telegram.Bot.Types;
using TelegramBotPolling;
using TelegramPolling;

namespace Inventar.ViewModels
{
    public class Lic
    {
        public string OP { get; set; }
        public DateTime Date{ get; set;}

    }
    internal class MainVindowViewModel : ViewModel
    {
        
        public ICommand OpenConfig { get; }
        private bool CanOpenGonfig(object p) => true;
        private void OnOpenConfig(object p) => new Configurator().Show();
        private async void get()
        {
            List<Lic> ints = new();
            RK7QueryResult commandResult = new();
            ReturnerObject returner = new();
            commandResult = await returner.GetObjectFromXmlInterface();
            foreach (var item in commandResult.CommandResult[0].RK7Reference.Items.Item)
            {               
                foreach (var item2 in item.DeviceLicenses.Items.Item)
                {
                    ints.Add(new Lic() 
                    {
                        OP = item.AltName, 
                        Date = new DateTime(1899, 12, 30).AddSeconds(Convert.ToInt64(item2.ExpiresAT) / 1000) 
                    });
                }
            }
         
        }
        public MainVindowViewModel()
        {
            OpenConfig = new RelayCommand(OnOpenConfig, CanOpenGonfig);
            BotInit bot = new BotInit(ConfigLoad.GetConfig().ApiToken!.Token!);
            UpdateHandlers.Update += (Message a) => MessageBox.Show(a.From?.ToString());
            //ReturnerObject returner = new();
            //var a = returner.GetObjectFromXmlInterface();
            get();
        }
    }
}
