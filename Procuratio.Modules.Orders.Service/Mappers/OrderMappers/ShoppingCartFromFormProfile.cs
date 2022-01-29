using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class ShoppingCartFromFormProfile : Profile
    {
        public ShoppingCartFromFormProfile()
        {
            CreateMap<ShoppingCartFromFormDTO, Orders.Domain.Entities.Order>()
                .ForMember(x => x.OrderDetails, options => options.MapFrom(MapOrderDetailAndSetState))
                .ForMember(x => x.OrderStateId, options => options.MapFrom(MapOrderState))
                .ForMember(x => x.WaitingTimeForKitchen, options => options.MapFrom(WaitingTimeForKitchen));
        }

        private static List<OrderDetail> MapOrderDetailAndSetState(ShoppingCartFromFormDTO shoppingCartFromFormDTO, Orders.Domain.Entities.Order order)
        {
            List<OrderDetail> result = new();

            result.AddRange(order.OrderDetails);

            List<int> itemsAlreadyInDatabase = result.Select(x => x.ItemId).ToList();

            foreach (ItemFromShoppingCartDTO itemFromShoppingCartDTO in shoppingCartFromFormDTO.Items)
            {
                if (itemsAlreadyInDatabase.Contains(itemFromShoppingCartDTO.Id))
                {
                    OrderDetail currentOrderDetail = result.First(x => x.ItemId == itemFromShoppingCartDTO.Id);

                    if (itemFromShoppingCartDTO.ForKitchen)
                    {
                        currentOrderDetail.QuantityInKitchen += itemFromShoppingCartDTO.Quantity;
                    }
                    else
                    {
                        currentOrderDetail.Quantity += itemFromShoppingCartDTO.Quantity;
                    }
                }
                else
                {
                    OrderDetail orderDetail = new();

                    orderDetail.OrderId = order.Id;
                    orderDetail.ItemId = itemFromShoppingCartDTO.Id;
                    orderDetail.Comment = itemFromShoppingCartDTO.Comment;

                    if (itemFromShoppingCartDTO.ForKitchen)
                    {
                        orderDetail.QuantityInKitchen = itemFromShoppingCartDTO.Quantity;
                        orderDetail.Quantity = 0;
                    }
                    else
                    {
                        orderDetail.Quantity = itemFromShoppingCartDTO.Quantity;
                        orderDetail.QuantityInKitchen = 0;
                    }

                    result.Add(orderDetail);
                }
            }

            return result;
        }

        private static short MapOrderState(ShoppingCartFromFormDTO shoppingCartFromFormDTO, Orders.Domain.Entities.Order order)
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

        private static DateTime? WaitingTimeForKitchen(ShoppingCartFromFormDTO shoppingCartFromFormDTO, Orders.Domain.Entities.Order order)
        {
            return order.OrderStateId == (short)OrderState.State.InProgress ? DateTime.Now : null;
        }
    }
}
