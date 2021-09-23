using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.API.Controllers.Base;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.API.Controllers
{
    internal class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("dine-in-order-detail/" + "{orderId:int}")]
        public async Task<ActionResult<OrderEditionFormInitializerDTO>> GetWithoutReserveOrderDetailAsync(int orderId) => Ok(await _orderService.GetWithoutReserveOrderDetailAsync(orderId));
    }
}
