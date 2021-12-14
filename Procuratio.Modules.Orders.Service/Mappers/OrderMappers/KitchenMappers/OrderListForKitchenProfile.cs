using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers.KitchenMappers
{
    public class OrderListForKitchenProfile : Profile
    {
        public OrderListForKitchenProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderListForKitchenDTO>()
                .ForMember(x => x.OrderId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.WaitingTimeForKitchen, x => x.MapFrom(x =>
                new TimeSpan(DateTime.Now.Hour - x.WaitingTimeForKitchen.Value.Hour, DateTime.Now.Minute - x.WaitingTimeForKitchen.Value.Minute, 0).ToString(@"hh\:mm")));
        }
    }
}
