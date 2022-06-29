﻿using FKCPObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramBotPolling;
using TelegramPolling;

namespace Inventar.ViewModels
{
    internal class MainVindowViewModel:ViewModel
    {

        public MainVindowViewModel()
        {
            BotInit bot = new BotInit(ConfigLoad.LoadConfig().ApiToken!.Token!);
            //bot.LoadBot(ConfigLoad.LoadConfig().ApiToken!.Token!);
            UpdateHandlers.Update += Show;
            bot.Send();
        }
        public void Show(string obj)
        {
            MessageBox.Show(obj);
        }
       

    }
}
