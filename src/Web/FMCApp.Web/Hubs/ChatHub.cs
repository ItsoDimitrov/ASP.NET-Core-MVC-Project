using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Web.Models.Chat;
using Microsoft.AspNetCore.SignalR;

namespace FMCApp.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                await this.Clients.All.SendAsync("NewMessage", new Message
                {

                    User = this.Context.User.Identity.Name,
                    Text = message,
                });

            }
        }
    }
}
