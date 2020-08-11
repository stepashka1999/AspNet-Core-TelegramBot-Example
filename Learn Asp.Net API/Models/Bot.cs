using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Learn_Asp.Net_API.Models.Commands;

namespace Learn_Asp.Net_API.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<ICommand> commandsList;

        public static IReadOnlyList<ICommand> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null) return botClient;

            commandsList = new List<ICommand>();
            commandsList.Add(new StartCommand());

            botClient = new TelegramBotClient(AppSettings.Token);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
