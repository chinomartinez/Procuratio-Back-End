using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.API.Modules.Notification.API.Services
{
    internal class CustomerMenuSender : Hub
    {
        public CustomerMenuSender()
        {

        }

        public async Task SendNotificationFromCustomerToWaiter()
        {
            await Clients.Clients(Context.ConnectionId).SendAsync("askServerResponse", "Test");
        }
    }
}
