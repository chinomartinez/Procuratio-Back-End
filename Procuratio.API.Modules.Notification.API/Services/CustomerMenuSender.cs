using Microsoft.AspNetCore.SignalR;
using Procuratio.Modules.Notification.API.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Procuratio.Shared.ProcuratioFramework.String;
using Procuratio.Modules.Order.Shared;
using Procuratio.Modules.Notification.API.Exceptions;
using Procuratio.Modules.Notification.API.Models;
using Microsoft.Extensions.Primitives;

namespace Procuratio.API.Modules.Notification.API.Services
{
    public class CustomerMenuSender : Hub
    {
        private readonly IOrderModuleAPI _orderModuleAPI;
        //private static List<ConnectedUsers> _connectedUsers = new List<ConnectedUsers>();

        public CustomerMenuSender(IOrderModuleAPI orderModuleAPI)
        {
            _orderModuleAPI = orderModuleAPI;
        }

        //public override Task OnConnectedAsync()
        //{
        //    StringValues orderKey = Context.GetHttpContext().Request.Query["orderKey"];
        //    StringValues waiterId = Context.GetHttpContext().Request.Query["waiterId"];

        //    if (string.IsNullOrEmpty(orderKey) && string.IsNullOrEmpty(waiterId))
        //    {
        //        throw new InvalidConectionException();
        //    }

        //    ConnectedUsers status = _connectedUsers.FirstOrDefault(x => x.OrderKey == orderKey || x.WaiterId == waiterId);

        //    if (status == null)
        //    {
        //        _connectedUsers.Add(new ConnectedUsers
        //        {
        //            ConectionId = Context.ConnectionId,
        //            OrderKey = orderKey,
        //            WaiterId = int.TryParse(waiterId, out int tryParseResult) == true ? Convert.ToInt32(waiterId) : null
        //        });
        //    } 
        //    else
        //    {
        //        foreach (ConnectedUsers conectedUser in _connectedUsers)
        //        {
        //            if (conectedUser.OrderKey == orderKey || conectedUser.WaiterId == waiterId)
        //            {
        //                conectedUser.ConectionId = Context.ConnectionId;
        //                break;
        //            }
        //        }
        //    }

        //    return base.OnConnectedAsync();
        //}

        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    _connectedUsers = _connectedUsers.Where(x => x.ConectionId != Context.ConnectionId).ToList();

        //    return base.OnDisconnectedAsync(exception);
        //}

        public async Task SendNotificationFromCustomerToWaiter(string fromUser, string orderKey)
        {
            List<string> tables = await GetTablesOfTheOrder(orderKey);

            CustomerNotificationDTO customerNotificationDTO = new();

            if (tables.Count > 1)
            {
                customerNotificationDTO.Message = $"El comensal de las mesas { string.Join(", ", tables) } te esta llamando.";
                customerNotificationDTO.Message = StringHelper.ReplaceLastOccurrence(customerNotificationDTO.Message, ", ", " y ");
            }
            else
            {
                customerNotificationDTO.Message = $"El comensal de la mesa { tables.First() } te esta llamando.";
            }

            SendUserToUserMessage("waiterResponse", customerNotificationDTO, orderKey, fromUser);
        }

        public async Task SendBillNotificationFromCustomerToWaiter(string fromUser, string orderKey)
        {
            List<string> tables = await GetTablesOfTheOrder(orderKey);

            CustomerNotificationDTO customerNotificationDTO = new();

            if (tables.Count > 1)
            {
                customerNotificationDTO.Message = $"El comensal de las mesas { string.Join(", ", tables) } quiere la cuenta.";
                customerNotificationDTO.Message = StringHelper.ReplaceLastOccurrence(customerNotificationDTO.Message, ", ", " y ");
            }
            else
            {
                customerNotificationDTO.Message = $"El comensal de la mesa { tables.First() } quiere la cuenta.";
            }

            SendUserToUserMessage("waiterBillResponse", customerNotificationDTO, orderKey, fromUser);
        }

        public async Task SendNewOrderNotificationFromCustomerToWaiter(string fromUser, string orderKey)
        {
            List<string> tables = await GetTablesOfTheOrder(orderKey);

            CustomerNotificationDTO customerNotificationDTO = new();

            if (tables.Count > 1)
            {
                customerNotificationDTO.Message = $"El comensal de las mesas { string.Join(", ", tables) } agrego artículos al pedido.";
                customerNotificationDTO.Message = StringHelper.ReplaceLastOccurrence(customerNotificationDTO.Message, ", ", " y ");
            }
            else
            {
                customerNotificationDTO.Message = $"El comensal de la mesa { tables.First() } agrego artículos al pedido.";
            }

            SendUserToUserMessage("waiterNewOrderResponse", customerNotificationDTO, orderKey, fromUser);
        }

        public string GetConnectionId() => Context.ConnectionId;

        private async void SendUserToUserMessage(string methodName, CustomerNotificationDTO customerNotificationDTO, string orderKey, string fromUser)
        {
            await Clients.All.SendAsync(methodName, customerNotificationDTO, fromUser);

            //int? waiterIdOfTheOrder = await _orderModuleAPI.GetWaiterIdOfTheOrder(orderKey);

            //if (waiterIdOfTheOrder is null || waiterIdOfTheOrder <= 0) { throw new WaiterOfflineException(); }

            //foreach (ConnectedUsers conectedUser in _connectedUsers)
            //{
            //    if (conectedUser.WaiterId == waiterIdOfTheOrder)
            //    {
            //        await Clients.Client(conectedUser.ConectionId).SendAsync(methodName, customerNotificationDTO, fromUser);
            //        return;
            //    }
            //}

            //throw new WaiterOfflineException();
        }

        private async Task<List<string>> GetTablesOfTheOrder(string orderKey)
        {
            List<string> tables = await _orderModuleAPI.GetTablesForWaiterNotification(orderKey);

            if (tables is null || tables.Count == 0) { throw new TablesNotFoundException(); }

            return tables;
        }
    }
}
