using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Order.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services.ModuleAPI
{
    internal class OrderModuleAPI : IOrderModuleAPI
    {
        private readonly IOrderService _orderService;

        public OrderModuleAPI(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<string>> GetTablesForWaiterNotification(string customerPassword)
        {
            return await _orderService.GetTablesForWaiterNotification(customerPassword);
        }

        public async Task<int?> GetWaiterIdOfTheOrder(string orderKey)
        {
            return await _orderService.GetWaiterIdOfTheOrder(orderKey);
        }
    }
}
