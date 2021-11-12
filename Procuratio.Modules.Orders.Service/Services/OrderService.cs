using AutoMapper;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.DataAccess.EF.AnonymousTypes;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Shared.ProcuratioFramework.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderEditionFormInitializerDTO> GetWithoutReserveOrderDetailAsync(int id)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithoutReserveOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            return _mapper.Map<OrderEditionFormInitializerDTO>(order);
        }

        public async Task UpdateWithoutReserveAsync(OrderFromFormDTO updateDTO, int id) 
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithoutReserveOrderDetailAsync(id);

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

        public async Task<List<MultiDTO>> GetOrderForReport(int from, int to)
        {
            List<MultiDTO> multiDTOs = new();

            List<OrderForReport> ordersForReport = await _orderRepository.GetOrderForReport(from, to);

            List<int> years = new();

            ordersForReport.ForEach(x => { if (!years.Contains(x.Year)) years.Add(x.Year); });

            foreach (object currentMonth in Enum.GetValues(typeof(Month)))
            {
                MultiDTO currentMultiDTO = new()
                {
                    Name = currentMonth.ToString(),
                    Series = new List<SeriesDTO>()
                };

                foreach (int currentYear in years)
                {
                    int totalOrdersPaid = 0;

                    if (ordersForReport.Exists(x => x.Month == (int)currentMonth && x.Year == currentYear))
                    {
                        totalOrdersPaid = ordersForReport.Find(x => x.Month == (int)currentMonth && x.Year == currentYear).Quantity;

                        ordersForReport.RemoveAll(x => x.Month == (int)currentMonth && x.Year == currentYear);
                    }

                    currentMultiDTO.Series.Add(new SeriesDTO()
                    {
                        Name = currentYear.ToString(),
                        Value = totalOrdersPaid
                    });
                }

                multiDTOs.Add(currentMultiDTO);
            }

            return multiDTOs;
        }
    }
}
