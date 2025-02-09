using System.Runtime.CompilerServices;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;


namespace TelegramBot
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Secrets secrets = new Secrets();
            var telegramBot = new TelegramBotClient(token: secrets.TGBotToken!);
            var ct = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = [UpdateType.Message],          // only message allowed
                DropPendingUpdates = true                       // clear updates queue on bot started
            };
            var handler = new UpdateHandler();

            telegramBot.StartReceiving(handler, receiverOptions);

            var me = await telegramBot.GetMe();
            Console.WriteLine($"Bot {me.FirstName} started!");
            Console.WriteLine($"Press A to exit");

            try
            {

                handler.HandlerUpdateStarted += OnHandlerUpdateStarted!;
                handler.HandlerUpdateCompleted += OnHandlerUpdateCompleted!;

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.A)
                        {
                            ct.Cancel();
                            break;
                        }
                        else
                        {
                            (_, int y) = Console.GetCursorPosition();
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine($"Bot {me.FirstName} is runnig...");
                        }
                    }
                }
            }
            finally
            {
                handler.HandlerUpdateStarted -= OnHandlerUpdateStarted!;
                handler.HandlerUpdateCompleted -= OnHandlerUpdateCompleted!;
            }

        }

        public static UpdateHandler? OnHandlerUpdateStarted(string message)
        {
            Console.WriteLine($"Message \"{message}\" processing started...");
            return null;
        }

        public static UpdateHandler? OnHandlerUpdateCompleted(string message)
        {
            Console.WriteLine($"Message processing \"{message}\" completed.");
            return null;
        }

    }
}
