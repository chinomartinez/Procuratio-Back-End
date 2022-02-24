using AutoMapper;
using Procuratio.Modules.Menu.Shared;
using Procuratio.Modules.Menu.Shared.DTO;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Order.Shared.DTO;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IItemModuleAPI _itemModuleAPI;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IItemModuleAPI itemModuleAPI,
            IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _itemModuleAPI = itemModuleAPI;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderEditionFormInitializerDTO> GetOrderDetailAsync(int id, bool dineIn)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderForUpdateOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            List<int> itemsIds = new();

            foreach (OrderDetail item in order.OrderDetails)
            {
                itemsIds.Add(item.ItemId);
            }

            List<MenuForOrderDetailDTO> menuForOrderDetailDTOList = await _itemModuleAPI.GetMenuForOrderDetailAsync(itemsIds, dineIn);

            OrderEditionFormInitializerDTO orderEditionFormInitializerDTO = _mapper.Map<OrderEditionFormInitializerDTO>(order);

            foreach (OrderDetailForListItemsDTO item in orderEditionFormInitializerDTO.Items)
            {
                MenuForOrderDetailDTO menuForOrderDetailDTO = menuForOrderDetailDTOList.Find(x => x.ItemId == item.ItemId);

                item.Price = menuForOrderDetailDTO.Price;
                item.Name = menuForOrderDetailDTO.ItemName;
                item.ForKitchen = menuForOrderDetailDTO.ForKitchen;
            }

            if (order.OrderStateId == (short)OrderState.State.ForDelivery)
            {
                List<int> auxItemsIds = new();

                foreach (OrderDetailForListItemsDTO item in orderEditionFormInitializerDTO.Items)
                {
                    if (!item.ForKitchen)
                    {
                        auxItemsIds.Add(item.ItemId);
                    }
                    else
                    {
                        item.Quantity = 0;
                    }
                }

                orderEditionFormInitializerDTO.Items.RemoveAll(x => auxItemsIds.Contains(x.ItemId) || x.QuantityInKitchen == 0);
            }

            return orderEditionFormInitializerDTO;
        }

        public async Task UpdateOrderDetailAsync(OrderFromFormDTO updateDTO, int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderForUpdateOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            order = _mapper.Map(updateDTO, order);

            await _orderRepository.UpdateAsync(order);
        }

        public async Task UpdateOrderDetailFromCustomerAsync(ShoppingCartFromFormDTO shoppingCartFromFormDTO)
        {
            ValidateOrderKey(shoppingCartFromFormDTO.OrderKey);

            string[] values = shoppingCartFromFormDTO.OrderKey.Split('-');

            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderForUpdateOrderDetailFromCustomerAsync(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));

            if (order is null) { throw new OrderNotFoundException(); }

            order = _mapper.Map(shoppingCartFromFormDTO, order);

            order.OrderDetails.ForEach(x => x.BranchId = Convert.ToInt32(values[1]));

            await _orderRepository.UpdateAsync(order);
        }
        public async Task<List<string>> GetTablesForWaiterNotification(string customerPassword)
        {
            ValidateOrderKey(customerPassword);

            string[] values = customerPassword.Split('-');

            return await _orderRepository.GetTablesForWaiterNotification(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
        }

        public async Task<int?> GetWaiterIdOfTheOrder(string orderKey)
        {
            ValidateOrderKey(orderKey);

            string[] values = orderKey.Split('-');

            return await _orderRepository.GetWaiterIdOfTheOrder(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
        }

        public async Task<IReadOnlyList<OrderListForKitchenDTO>> GetOrdersInProgressForKitchenAsync()
        {
            IReadOnlyList<Orders.Domain.Entities.Order> orders = await _orderRepository.GetOrdersInProgressForKitchenAsync();

            return _mapper.Map<IReadOnlyList<OrderListForKitchenDTO>>(orders);
        }

        public async Task<List<OrderWithOrderDetailVM>> GetOrderDetailForKitchenAsync(int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderDetailForKitchenAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            List<int> itemsIds = new();

            foreach (OrderDetail item in order.OrderDetails)
            {
                if (item.QuantityInKitchen > 0) { itemsIds.Add(item.ItemId); }
            }

            List<ItemsForOrderDetailInKitchenDTO> itemsForOrderDetailInKitchenList = await _itemModuleAPI.GetItemsForKitchenAsync(itemsIds);

            List<OrderWithOrderDetailVM> orderDetailForKitchenDTO = new();

            foreach (ItemsForOrderDetailInKitchenDTO item in itemsForOrderDetailInKitchenList)
            {
                OrderDetail currentOrderDetail = order.OrderDetails.Find(x => x.ItemId == item.Id);

                orderDetailForKitchenDTO.Add(new OrderWithOrderDetailVM
                {
                    Id = currentOrderDetail.OrderId,
                    ItemName = item.Name,
                    Comment = currentOrderDetail.Comment,
                    Quantity = currentOrderDetail.QuantityInKitchen
                });
            }

            return orderDetailForKitchenDTO;
        }

        public async Task<List<OrderBillDTO>> GetBillAsync(int id, bool dineIn)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderDetailForBillAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            List<int> itemsIds = new();

            foreach (OrderDetail item in order.OrderDetails)
            {
                itemsIds.Add(item.ItemId);
            }

            List<ItemsForBillDTO> itemsForOrderDetailBillList = await _itemModuleAPI.GetItemsForBillAsync(itemsIds, dineIn);

            List<OrderBillDTO> orderBillDTO = new();

            foreach (ItemsForBillDTO item in itemsForOrderDetailBillList)
            {
                OrderDetail currentOrderDetail = order.OrderDetails.Find(x => x.ItemId == item.Id);

                orderBillDTO.Add(new OrderBillDTO
                {
                    Id = currentOrderDetail.OrderId,
                    Name = item.Name,
                    Quantity = currentOrderDetail.Quantity,
                    Price = item.Price
                });
            }

            return orderBillDTO;
        }

        public async Task<List<OrderBillDTO>> GetMenuBillAsync(string orderKey)
        {
            ValidateOrderKey(orderKey);

            string[] values = orderKey.Split('-');

            Orders.Domain.Entities.Order order = await _orderRepository.GetAnonymousOrderDetailForBillAsync(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));

            if (order is null) { throw new OrderNotFoundException(); }

            List<int> itemsIds = new();

            foreach (OrderDetail item in order.OrderDetails)
            {
                itemsIds.Add(item.ItemId);
            }

            List<ItemsForBillDTO> itemsForOrderDetailBillList = await _itemModuleAPI.GetAnonymousItemsForBillAsync(itemsIds, Convert.ToInt32(values[1]));

            List<OrderBillDTO> orderBillDTO = new();

            foreach (ItemsForBillDTO item in itemsForOrderDetailBillList)
            {
                OrderDetail currentOrderDetail = order.OrderDetails.Find(x => x.ItemId == item.Id);

                orderBillDTO.Add(new OrderBillDTO
                {
                    Id = currentOrderDetail.OrderId,
                    Name = item.Name,
                    Quantity = currentOrderDetail.Quantity + currentOrderDetail.QuantityInKitchen,
                    Price = item.Price
                });
            }

            return orderBillDTO;
        }

        public async Task<IReadOnlyList<OrderInProgressDTO>> GetInProgressAsync()
        {
            IReadOnlyList<Orders.Domain.Entities.Order> ordersInProgress = await _orderRepository.GetOrderInProgressAsync();

            return _mapper.Map<IReadOnlyList<OrderInProgressDTO>>(ordersInProgress);
        }

        public async Task OrderForDeliverAsync(int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            order.OrderStateId = (short)OrderState.State.ForDelivery;
            order.WaitingTimeForKitchen = null;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeliverOrderAsync(int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            foreach (OrderDetail element in order.OrderDetails)
            {
                element.Quantity += element.QuantityInKitchen;
                element.QuantityInKitchen = 0;
            }

            order.OrderStateId = (short)OrderState.State.Delivered;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task WaitingForPaymentAsync(int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            order.OrderStateId = (short)OrderState.State.WaitingForPayment;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task WaitingForPaymentAnonymousAsync(string orderKey)
        {
            ValidateOrderKey(orderKey);

            string[] values = orderKey.Split('-');

            Orders.Domain.Entities.Order order = await _orderRepository.GetAnonymousOrderAsync(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));

            if (order is null) { throw new OrderNotFoundException(); }

            order.OrderStateId = (short)OrderState.State.WaitingForPayment;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task PaidAsync(int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            order.OrderStateId = (short)OrderState.State.Paid;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task<int> DeleteOrderDetailAsync(int orderId, int itemId)
        {
            OrderDetail orderDetail = await _orderDetailRepository.GetOrderDetailByOrderIdAndItemId(orderId, itemId);

            int orderDetailDeleted = await _orderDetailRepository.DeleteOrderDetail(orderDetail);

            Orders.Domain.Entities.Order orderToUpdateState = await _orderRepository.GetWithOrderDetailAsync(orderId);

            if (orderToUpdateState.OrderDetails.Exists(x => x.QuantityInKitchen > 0))
            {
                orderToUpdateState.OrderStateId = (short)OrderState.State.InProgress;
            }
            else
            {
                if (orderToUpdateState.OrderDetails.Count == 0)
                {
                    orderToUpdateState.OrderStateId = (short)OrderState.State.Pending;
                }
                else
                {
                    orderToUpdateState.OrderStateId = (short)OrderState.State.Delivered;
                }
            }

            await _orderRepository.UpdateAsync(orderToUpdateState);

            return orderDetailDeleted;
        }

        public async Task<short> GetOrderStateAsync(string orderKey)
        {
            ValidateOrderKey(orderKey);

            string[] values = orderKey.Split('-');

            return await _orderRepository.GetOrderStateIdAsync(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
        }

        public async Task<List<OrderForReportDTO>> GetOrderForReport(int from, int to)
        {
            List<OrderForReport> ordersForReport = await _orderRepository.GetOrderForReport(from, to);

            return _mapper.Map<List<OrderForReportDTO>>(ordersForReport);
        }

        private static void ValidateOrderKey(string orderKey)
        {
            Regex regex = new("([1-9][0-9]*|0)-([1-9][0-9]*|0)");

            if (!regex.IsMatch(orderKey)) { throw new InvalidOrderKeyException(); }
        }
    }
}
