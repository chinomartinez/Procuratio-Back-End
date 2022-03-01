using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Order.Shared;
using Procuratio.Modules.Order.Shared.DTO;
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

        public async Task<List<ItemForReportDTO>> GetItemForBestSelling(int topBestSellingItems)
        {
            return await _orderService.GetItemForBestSelling(topBestSellingItems);
        }

        public async Task<List<ItemForReportDTO>> GetItemForWorstSelling(int topWorstSellingItems)
        {
            return await _orderService.GetItemForWorstSelling(topWorstSellingItems);
        }

        public async Task<List<OrderForReportDTO>> GetOrderForReport(int from, int to)
        {
            return await _orderService.GetOrderForReport(from, to);
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
