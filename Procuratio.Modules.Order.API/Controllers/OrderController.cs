using Microsoft.AspNetCore.Authorization;
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

        [HttpDelete("delete-order-detail/" + "{orderId:int}" + "/{itemId:int}")]
        public async Task<ActionResult<int>> DeleteOrderDetailAsync(int orderId, int itemId)
        {
            return Ok(await _orderService.DeleteOrderDetailAsync(orderId, itemId));
        }

        [HttpGet("edit-order-detail/" + BasicStringsForControllers.IntParameter + "/{dineIn:bool}")]
        public async Task<ActionResult<OrderEditionFormInitializerDTO>> GetOrderDetailAsync(int id, bool dineIn) => Ok(await _orderService.GetOrderDetailAsync(id, dineIn));

        [HttpPut("order-detail/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateOrderDetailAsync([FromBody] OrderFromFormDTO updateDTO, int id)
        {
            await _orderService.UpdateOrderDetailAsync(updateDTO, id);
            return NoContent();
        }

        [HttpPut("order-detail-from-customer")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateOrderDetailFromCustomerAsync([FromBody] ShoppingCartFromFormDTO shoppingCartFromFormDTO)
        {
            await _orderService.UpdateOrderDetailFromCustomerAsync(shoppingCartFromFormDTO);
            return NoContent();
        }

        [HttpGet("order-in-progress-for-kitchen")]
        public async Task<ActionResult<IReadOnlyList<OrderListForKitchenDTO>>> GetOrdersInProgressForKitchenAsync() => Ok(await _orderService.GetOrdersInProgressForKitchenAsync());


        [HttpGet("order-detail-for-kitchen/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<List<OrderWithOrderDetailVM>>> GetOrderDetailForKitchenAsync(int id)
        {
            return Ok(await _orderService.GetOrderDetailForKitchenAsync(id));
        }

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

        [HttpPut("waiting-for-payment-anonymous/" + "{orderKey}")]
        [AllowAnonymous]
        public async Task<ActionResult> WaitingForPaymentAnonymousAsync(string orderKey)
        {
            await _orderService.WaitingForPaymentAnonymousAsync(orderKey);
            return NoContent();
        }

        [HttpPut("paid/" + BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> PaidAsync(int id)
        {
            await _orderService.PaidAsync(id);
            return NoContent();
        }

        [HttpGet("dine-in-in-progress")]
        public async Task<ActionResult<IReadOnlyList<OrderInProgressDTO>>> GetInProgressAsync([FromQuery] OrderInProgressFilterDTO orderInProgressFilterDTO)
        {
            return Ok(await _orderService.GetInProgressAsync(orderInProgressFilterDTO));
        }


        [HttpGet("bill/" + BasicStringsForControllers.IntParameter + "/{dineIn:bool}")]
        public async Task<ActionResult<List<OrderBillDTO>>> GetBillAsync(int id, bool dineIn) => Ok(await _orderService.GetBillAsync(id, dineIn));

        [HttpGet("bill/" + "{orderKey}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<OrderBillDTO>>> GetMenuBillAsync(string orderKey) => Ok(await _orderService.GetMenuBillAsync(orderKey));

        [HttpGet("order-state/" + "{orderKey}")]
        [AllowAnonymous]
        public async Task<ActionResult<short>> GetOrderStateAsync(string orderKey) => Ok(await _orderService.GetOrderStateAsync(orderKey));
    }
}
