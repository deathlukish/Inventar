using FKCPObj;
using FKCPObj.SimleClass;
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
using System.Xml.Serialization;
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
            SenderQuery senderQuery = new();
            string a = senderQuery.GetResultXML();
            XDocument doc = XDocument.Parse(a);
            List<SimpleOP>? b = doc.Element("RK7QueryResult")?
                .Element("CommandResult")?
                .Element("RK7Reference")?
                .Element("Items")?
                .Elements("Item")?
                .Select (step => new SimpleOP
                {
                    NetName = step?.Attribute("Ident")?.Value
                })?.ToList();
            //var my = (from s in doc.Descendants("Items")
            //          select new
            //          {
            //              Id = s.Element("Item").Value

            //          }).ToList();



        }


    }
}
