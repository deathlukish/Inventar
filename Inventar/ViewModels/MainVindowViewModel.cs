using FKCPObj;
using System.Windows;
using Telegram.Bot.Types;
using TelegramBotPolling;
using TelegramPolling;

namespace Inventar.ViewModels
{
    internal class MainVindowViewModel:ViewModel
    {

        public MainVindowViewModel()
        {
            BotInit bot = new BotInit(ConfigLoad.LoadConfig().ApiToken!.Token!);
            UpdateHandlers.Update += (Message a)=>MessageBox.Show(a.From.ToString());
            bot.Send("Я готов к работе");
        }

       

    }
}
