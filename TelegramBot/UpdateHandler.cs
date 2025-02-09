using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    internal class UpdateHandler : IUpdateHandler
    {
        public delegate UpdateHandler MessageHandler(string message);
        public event MessageHandler HandlerUpdateStarted;
        public event MessageHandler HandlerUpdateCompleted;
        private record CatFactDto(string Fact, int length);

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            HandlerUpdateStarted.Invoke(update.Message?.Text ?? "");

            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Text.ToLower() == "/start")
                {
                    var cts = new CancellationTokenSource();
                    using var client = new HttpClient();
                    var catFact = await client.GetFromJsonAsync<CatFactDto>("https://catfact.ninja/fact", cts.Token);
                    client.Dispose();
                    await botClient.SendMessage(update.Message.Chat.Id, $"One more fact about Cats:\n {catFact?.Fact}\n");
                }
            }
            else
            {
                await botClient.SendMessage(update.Message!.Chat.Id, $"Message  \"{update.Message.Text}\" processed successfully!");
            }

            HandlerUpdateCompleted?.Invoke(update.Message?.Text ?? "");

        }
    }
}
