using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderEditionFormInitializerProfile : Profile
    {
        public OrderEditionFormInitializerProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderEditionFormInitializerDTO>()
                .ForPath(x => x.BaseProperties.Id, x => x.MapFrom(x => x.Id))
                .ForPath(x => x.BaseProperties.Date, x => x.MapFrom(x => x.Date))
                .ForPath(x => x.BaseProperties.KitchenNote, x => x.MapFrom(x => x.KitchenNote))
                .ForPath(x => x.BaseProperties.OrderStateId, x => x.MapFrom(x => x.OrderStateId))
                .ForPath(x => x.OrderStateName, x => x.MapFrom(x => x.OrderState.StateName))
                .ForPath(x => x.BaseProperties.WaiterId, x => x.MapFrom(x => x.WaiterId))
                .ForPath(x => x.BaseProperties.CustomerId, x => x.MapFrom(x => x.CustomerId))
                .ForMember(x => x.Items, options => options.MapFrom(MapOrderDetailForListItems));
        }

        private List<OrderDetailForListItemsDTO> MapOrderDetailForListItems(Orders.Domain.Entities.Order order, OrderEditionFormInitializerDTO orderEditionFormInitializerDTO)
        {
            List<OrderDetailForListItemsDTO> orderDetailForListItemsDTOs = new();

            order.OrderDetails.ForEach(x =>
            {
                orderDetailForListItemsDTOs.Add(new OrderDetailForListItemsDTO()
                {
                    ItemId = x.ItemId,
                    Name = $"Articulo {orderDetailForListItemsDTOs.Count + 1}", // ver
                    ForKitchen = false, // ver
                    Image = null, // ver
                    PriceInsideRestaurant = 200, // ver
                    PriceOutsideRestaurant = 300, // ver
                    Quantity = x.Quantity,
                    QuantityInKitchen = x.QuantityInKitchen
                });
            });

            return orderDetailForListItemsDTOs;
        }
    }
}