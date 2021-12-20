using Procuratio.Modules.Menu.Shared.DTO;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderInProgressDTO>> GetInProgressAsync();

        Task<OrderEditionFormInitializerDTO> GetOrderDetailAsync(int id, bool dineIn);

        Task UpdateOrderDetailAsync(OrderFromFormDTO updateDTO, int id);

        Task<IReadOnlyList<OrderListForKitchenDTO>> GetOrdersInProgressForKitchenAsync();

        Task OrderForDeliverAsync(int id);

        Task DeliverOrderAsync(int id);

        Task WaitingForPaymentAsync(int id);

        Task PaidAsync(int id);

        Task<List<OrderWithOrderDetailVM>> GetOrderDetailForKitchenAsync(int id);
    }
}
