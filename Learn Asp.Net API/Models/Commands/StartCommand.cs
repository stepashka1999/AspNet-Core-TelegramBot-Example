using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Learn_Asp.Net_API.Models.Commands
{
    public class StartCommand : ICommand
    {
        public string Name => @"/start";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Привет педик, я телеграм бот, написанный на ASP.NET Core)))", parseMode: ParseMode.Markdown);
        }
    }
}
