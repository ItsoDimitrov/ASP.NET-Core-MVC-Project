using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.Chat
{
    public class Message : IMessage
    {
        public string User { get; set; }

        public string Text { get; set; }
    }
}
