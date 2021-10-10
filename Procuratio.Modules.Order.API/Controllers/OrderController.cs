using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.API.Controllers
{
    internal class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private const string OrderIdTemplate = "{orderId:int}";

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("without-reserve-order-detail/" + OrderIdTemplate)]
        public async Task<ActionResult<OrderEditionFormInitializerDTO>> GetWithoutReserveOrderDetailAsync(int orderId) => Ok(await _orderService.GetWithoutReserveOrderDetailAsync(orderId));

        [HttpPut("without-reserve/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateWithoutReserveAsync([FromForm] OrderFromFormDTO updateDTO, int id)
        {
            await _orderService.UpdateWithoutReserveAsync(updateDTO, id);
            return NoContent();
        }

        [HttpGet("order-in-progress")]
        public async Task<ActionResult<IReadOnlyList<OrderListForKitchenDTO>>> GetOrdersInProgressAsync() => Ok(await _orderService.GetOrdersInProgressAsync());
    }
}
