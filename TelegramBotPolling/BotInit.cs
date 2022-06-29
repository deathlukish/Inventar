using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramBotPolling;

namespace TelegramPolling
{
    public static class BotInit
    {
        public static async void LoadBot(string Token)
        {
            var bot = new TelegramBotClient(Token);
            var me = await bot.GetMeAsync();
            using var cts = new CancellationTokenSource();
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
                ThrowPendingUpdates = true,
            };

            bot.StartReceiving(updateHandler: UpdateHandlers.HandleUpdateAsync,
                               pollingErrorHandler: UpdateHandlers.PollingErrorHandler,
                               receiverOptions: receiverOptions,
                               cancellationToken: cts.Token);
            // Send cancellation request to stop bot
            //  cts.Cancel();

        }
    }
}
