﻿using AutoMapper;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.Modules.Order.Service.Services.Interfaces;
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

        public async Task<List<MultiDTO>> GetOrderForReport()
        {
            List<MultiDTO> multiDTOs = new();
            //{
            //    new MultiDTO
            //    {
            //        Name = "Enero",
            //        Series = new List<SeriesDTO>
            //        {
            //            new SeriesDTO
            //            {
            //                Name = "2021",
            //                Value = 2
            //            }
            //        }
            //    }
            //};

            List<DateTime> ordersDateTime = await _orderRepository.GetOrderForReport();

            List<int> years = new();

            ordersDateTime.ForEach(x => { if (!years.Contains(x.Date.Year)) years.Add(x.Year); });

            foreach (object month in Enum.GetValues(typeof(Month)))
            {
                MultiDTO currentMultiDTO = new MultiDTO()
                {
                    Name = month.ToString(),
                    Series = new List<SeriesDTO>()
                };

                foreach (int year in years)
                {
                    int totalOrdersPaid = 0;

                    foreach (DateTime item in ordersDateTime)
                    {
                        if (item.Date.Month == (int)month && item.Date.Year == year)
                        {
                            totalOrdersPaid += 1;
                            //ordersDateTime.Remove(item);
                        }
                    }

                    currentMultiDTO.Series.Add(new SeriesDTO()
                    {
                        Name = year.ToString(),
                        Value = totalOrdersPaid
                    });
                }

                multiDTOs.Add(currentMultiDTO);
            }

            return multiDTOs;
        }
    }
}
