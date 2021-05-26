using ChatbotApi.Core;
using ChatbotApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatbotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgFromUserController : ControllerBase
    {
        private static List<Message> history = new List<Message>();
        [HttpPost]
        public async Task<IActionResult> GetCountryOverView([FromBody] Message msg)
        {

            history.Add(msg);

            var msgService = new MsgService(msg.MessageBody);
            var newMsgDto = await msgService.MsgProcessorAsync();

            history.Add(new Message(){ UserName = newMsgDto.UserName, MessageBody = newMsgDto.MessageBody });

            newMsgDto.HistoryDto = new List<Message>(history);

            msgService.CleanHistory(history);

            return Ok(newMsgDto);
        }
    }
}
