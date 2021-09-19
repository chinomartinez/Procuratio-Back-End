using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderEditionFormInitializerProfile : Profile
    {
        public OrderEditionFormInitializerProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderEditionFormInitializerDTO>()
                .ForPath(x => x.Order.Date, x => x.MapFrom(x => x.Date))
                .ForPath(x => x.Order.KitchenNote, x => x.MapFrom(x => x.KitchenNote))
                .ForPath(x => x.Order.OrderStateID, x => x.MapFrom(x => x.OrderStateID))
                .ForMember(x => x.OrderStateName, x => x.MapFrom(x => x.OrderState.StateName))
                .ForPath(x => x.Order.WaiterID, x => x.MapFrom(x => x.WaiterID))
                .ForPath(x => x.Order.CustomerID, x => x.MapFrom(x => x.CustomerID));
        }
    }
}
