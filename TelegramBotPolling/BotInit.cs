using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramBotPolling;

namespace TelegramPolling
{
    public class BotInit
    {
        private readonly TelegramBotClient _client;
        public BotInit(string Token)
        {
            _client = new TelegramBotClient(Token);
            LoadBot();
        
        }
        private async void LoadBot()
        {
      
            var me = await _client.GetMeAsync();
            using var cts = new CancellationTokenSource();
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
                ThrowPendingUpdates = true,
            };

            _client.StartReceiving(updateHandler: UpdateHandlers.HandleUpdateAsync,
                               pollingErrorHandler: UpdateHandlers.PollingErrorHandler,
                               receiverOptions: receiverOptions,
                               cancellationToken: cts.Token);
            // Send cancellation request to stop bot
            //  cts.Cancel();
            
 
        }
        public async void Send()
        {

            await _client.SendTextMessageAsync(chatId: 617719714,
                                                 text: "Я запущен и готов к работе" );

        }
    }
}
