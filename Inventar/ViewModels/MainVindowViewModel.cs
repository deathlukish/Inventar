using FKCPObj;
using System.Windows;
using TelegramBotPolling;
using TelegramPolling;

namespace Inventar.ViewModels
{
    internal class MainVindowViewModel:ViewModel
    {

        public MainVindowViewModel()
        {
            BotInit bot = new BotInit(ConfigLoad.LoadConfig().ApiToken!.Token!);
            UpdateHandlers.Update += (string a)=>MessageBox.Show(a);
            bot.Send("Я готов к работе");
        }

       

    }
}
