using ChatbotApi.Models;
using System.Collections.Generic;

namespace ChatbotApi.Dto
{
    public class MessageDto
    {
        public string UserName { get; set; }
        public string MessageBody { get; set; }
        public List<Message> HistoryDto { get; set; }
    }
}
