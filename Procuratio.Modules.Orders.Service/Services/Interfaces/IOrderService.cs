using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.Modules.Order.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderInProgressDTO>> GetInProgressAsync(OrderInProgressFilterDTO orderInProgressFilterDTO);

        Task<OrderEditionFormInitializerDTO> GetOrderDetailAsync(int id, bool dineIn);

        Task UpdateOrderDetailAsync(OrderFromFormDTO updateDTO, int id);

        Task UpdateOrderDetailFromCustomerAsync(ShoppingCartFromFormDTO shoppingCartFromFormDTO);

        Task<IReadOnlyList<OrderListForKitchenDTO>> GetOrdersInProgressForKitchenAsync();

        Task OrderForDeliverAsync(int id);

        Task<List<ItemForReportDTO>> GetItemForBestSelling(int topBestSellingItems);

        Task DeliverOrderAsync(int id);

        Task WaitingForPaymentAsync(int id);

        Task<int?> GetWaiterIdOfTheOrder(string orderKey);

        Task PaidAsync(int id);

        Task<List<ItemForReportDTO>> GetItemForWorstSelling(int topWorstSellingItems);

        Task<int> DeleteOrderDetailAsync(int orderId, int itemId);

        Task<List<OrderWithOrderDetailVM>> GetOrderDetailForKitchenAsync(int id);

        Task<List<OrderBillDTO>> GetBillAsync(int id, bool dineIn);

        Task<List<OrderBillDTO>> GetMenuBillAsync(string orderKey);

        Task<List<string>> GetTablesForWaiterNotification(string customerPassword);

        Task<short> GetOrderStateAsync(string orderKey);

        Task WaitingForPaymentAnonymousAsync(string orderKey);

        Task<List<OrderForReportDTO>> GetOrderForReport(int from, int to);
    }
}
