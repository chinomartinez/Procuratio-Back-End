using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderEditionFormInitializerDTO> GetDineInOrderDetailAsync(int orderId);
    }
}
