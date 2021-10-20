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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("without-reserve-order-detail/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<OrderEditionFormInitializerDTO>> GetWithoutReserveOrderDetailAsync(int id) => Ok(await _orderService.GetWithoutReserveOrderDetailAsync(id));

        [HttpPut("without-reserve/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateWithoutReserveAsync([FromBody] OrderFromFormDTO updateDTO, int id)
        {
            await _orderService.UpdateWithoutReserveAsync(updateDTO, id);
            return NoContent();
        }

        [HttpGet("order-in-progress")]
        public async Task<ActionResult<IReadOnlyList<OrderListForKitchenDTO>>> GetOrdersInProgressAsync() => Ok(await _orderService.GetOrdersInProgressAsync());

        [HttpPut("for-delivery/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> OrderForDeliverAsync(int id)
        {
            await _orderService.OrderForDeliverAsync(id);
            return NoContent();
        }

        [HttpPut("deliver/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeliverOrderAsync(int id)
        {
            await _orderService.DeliverOrderAsync(id);
            return NoContent();
        }

        [HttpPut("waiting-for-payment/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> WaitingForPaymentAsync(int id)
        {
            await _orderService.WaitingForPaymentAsync(id);
            return NoContent();
        }

        [HttpPut("paid/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> PaidAsync(int id)
        {
            await _orderService.PaidAsync(id);
            return NoContent();
        }
    }
}
