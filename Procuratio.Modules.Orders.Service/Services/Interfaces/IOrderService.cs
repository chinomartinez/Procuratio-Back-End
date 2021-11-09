using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderEditionFormInitializerDTO> GetWithoutReserveOrderDetailAsync(int Id);

        Task UpdateWithoutReserveAsync(OrderFromFormDTO updateDTO, int id);

        Task<IReadOnlyList<OrderListForKitchenDTO>> GetOrdersInProgressAsync();

        Task OrderForDeliverAsync(int id);

        Task DeliverOrderAsync(int id);

        Task WaitingForPaymentAsync(int id);

        Task PaidAsync(int id);

        Task<List<MultiDTO>> GetOrderForReport();
    }
}
