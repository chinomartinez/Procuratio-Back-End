using AutoMapper;
using Procuratio.Modules.Menu.Shared;
using Procuratio.Modules.Menu.Shared.DTO;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using System;
using System.Collections.Generic;
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
                    Note = currentOrderDetail.Note,
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

            List<ItemsForBillDTO> itemsForOrderDetailBillList = await _itemModuleAPI.GetItemsFoBillAsync(itemsIds, dineIn);

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

            return await _orderDetailRepository.DeleteOrderDetail(orderDetail);
        }
    }
}
