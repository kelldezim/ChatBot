using System.Collections.Generic;

namespace ChatbotApi.Core
{
    public static class StaticResponseLibrary
    {
        public static Dictionary<string, string> cmds = new Dictionary<string, string>()
        {
            { "HI", "Hello! How can I help you?" },
            { "BYE", "Bye it was pleasure to talk with you" }
        };
    }
}
