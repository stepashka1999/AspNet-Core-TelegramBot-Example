using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_Asp.Net_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace Learn_Asp.Net_API.Controllers
{
    [Route("api/message/update")]
    public class MessageController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Method GET unaviable";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var bot = await Bot.GetBotClientAsync();

            foreach(var command in commands)
            {
                if(command.Contains(message))
                {
                    await command.Execute(message, bot);
                    break;
                }
            }

            return Ok();
        }
    }
}
