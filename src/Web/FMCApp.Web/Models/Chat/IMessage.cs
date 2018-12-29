using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.Chat
{
    public interface IMessage
    {
        string User { get; set; }
        string Text { get; set; }
    }
}
