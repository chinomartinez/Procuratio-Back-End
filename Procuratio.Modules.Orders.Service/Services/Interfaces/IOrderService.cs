using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderEditionFormInitializerDTO> GetWithoutReserveOrderDetailAsync(int orderId);

        Task UpdateWithoutReserveAsync(OrderFromFormDTO updateDTO, int id);
    }
}
