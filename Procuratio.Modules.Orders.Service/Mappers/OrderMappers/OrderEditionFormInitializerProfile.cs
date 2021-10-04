using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;

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
                .ForMember(x => x.OrderStateName, x => x.MapFrom(x => x.OrderState.StateName))
                .ForPath(x => x.BaseProperties.WaiterId, x => x.MapFrom(x => x.WaiterId))
                .ForPath(x => x.BaseProperties.CustomerId, x => x.MapFrom(x => x.CustomerId))
                .ForPath(x => x.Items, x => x.MapFrom(x => x.OrderDetails));
        }
    }
}
