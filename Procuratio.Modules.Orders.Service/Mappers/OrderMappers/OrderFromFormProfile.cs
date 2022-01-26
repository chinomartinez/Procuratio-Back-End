using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderFromFormProfile : Profile
    {
        public OrderFromFormProfile()
        {
            CreateMap<OrderFromFormDTO, Orders.Domain.Entities.Order>()
                .ForMember(x => x.OrderDetails, options => options.MapFrom(MapOrderDetailAndSetState))
                .ForMember(x => x.OrderStateId, options => options.MapFrom(MapOrderState))
                .ForMember(x => x.WaitingTimeForKitchen, options => options.MapFrom(WaitingTimeForKitchen));
        }

        private static List<OrderDetail> MapOrderDetailAndSetState(OrderFromFormDTO orderFromFormDTO, Orders.Domain.Entities.Order order)
        {
            List<OrderDetail> result = new();

            result.AddRange(order.OrderDetails);

            result = result.Where(x => orderFromFormDTO.Items.Select(x => x.ItemId).Contains(x.ItemId)).ToList();

            List<int> itemsAlreadyInDatabase = result.Select(x => x.ItemId).ToList();

            foreach (ItemForOrderFormDTO itemDTO in orderFromFormDTO.Items)
            {
                if (itemsAlreadyInDatabase.Contains(itemDTO.ItemId))
                {
                    OrderDetail currentOrderDetail = result.First(x => x.ItemId == itemDTO.ItemId);
                    currentOrderDetail.Comment = itemDTO.Comment;

                    if (itemDTO.ForKitchen)
                    {
                        int currentTotalOfItems = currentOrderDetail.Quantity + currentOrderDetail.QuantityInKitchen;
                        bool quantityInKitchenReduced = currentTotalOfItems - itemDTO.Quantity > 0 && itemDTO.Quantity > currentOrderDetail.Quantity;
                        bool quantityInKitchenIncreased = itemDTO.Quantity > currentTotalOfItems;
                        bool quantityReduced = currentTotalOfItems > itemDTO.Quantity;

                        if (quantityInKitchenIncreased || quantityInKitchenReduced)
                        {
                            currentOrderDetail.QuantityInKitchen = itemDTO.Quantity - currentOrderDetail.Quantity;
                        }
                        else if (quantityReduced)
                        {
                            currentOrderDetail.Quantity = itemDTO.Quantity;
                            currentOrderDetail.QuantityInKitchen = 0;
                        }
                    }
                    else
                    {
                        currentOrderDetail.Quantity = itemDTO.Quantity;
                        currentOrderDetail.QuantityInKitchen = 0;
                    }
                }
                else
                {
                    OrderDetail orderDetail = new();

                    orderDetail.OrderId = order.Id;
                    orderDetail.ItemId = itemDTO.ItemId;
                    orderDetail.Comment = itemDTO.Comment;

                    if (itemDTO.ForKitchen)
                    {
                        orderDetail.QuantityInKitchen = itemDTO.Quantity;
                        orderDetail.Quantity = 0;
                    }
                    else
                    {
                        orderDetail.Quantity = itemDTO.Quantity;
                        orderDetail.QuantityInKitchen = 0;
                    }

                    result.Add(orderDetail);
                }
            }

            return result;
        }

        private static short MapOrderState(OrderFromFormDTO orderFromFormDTO, Orders.Domain.Entities.Order order)
        {
            if (order.OrderDetails.Exists(x => x.QuantityInKitchen > 0))
            {
                return (short)OrderState.State.InProgress;
            }
            else
            {
                if (order.OrderDetails.Count == 0)
                {
                    return (short)OrderState.State.Pending;
                }
                else
                {
                    return (short)OrderState.State.Delivered;
                }
            }
        }

        private static DateTime? WaitingTimeForKitchen(OrderFromFormDTO orderFromFormDTO, Orders.Domain.Entities.Order order)
        {
            return order.OrderStateId == (short)OrderState.State.InProgress ? DateTime.Now : null;
        }
    }
}
