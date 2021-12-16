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
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IItemModuleAPI _itemModuleAPI;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository, 
            IItemModuleAPI itemModuleAPI)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _itemModuleAPI = itemModuleAPI;
        }

        public async Task<OrderEditionFormInitializerDTO> GetOrderDetailAsync(int id, bool dineIn)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderDetailAsync(id);

            List<int> itemsIds = new ();

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

            return orderEditionFormInitializerDTO;
        }

        public async Task UpdateWithoutReserveAsync(OrderFromFormDTO updateDTO, int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            order = _mapper.Map(updateDTO, order);

            if (updateDTO.Items.Exists(x => x.ForKitchen))
            {
                order.OrderStateId = (short)OrderState.State.InProgress;
                order.WaitingTimeForKitchen = DateTime.Now;
            }

            await _orderRepository.UpdateAsync(order);
        }

        public async Task<IReadOnlyList<OrderListForKitchenDTO>> GetOrdersInProgressAsync()
        {
            IReadOnlyList<Orders.Domain.Entities.Order> orders = await _orderRepository.GetOrdersInProgressAsync();

            return _mapper.Map<IReadOnlyList<OrderListForKitchenDTO>>(orders);
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
    }
}
