using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.API.HubSettings
{
    internal class CustomerMenuSender : Hub
    {
        public CustomerMenuSender()
        {

        }

        public async Task SendNotificationFromCustomerToWaiter(string message)
        {
            await Clients.Clients(Context.ConnectionId).SendAsync("askServerResponse", message);
        }
    }
}
