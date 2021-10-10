using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers.KitchenMappers
{
    public class OrderListForKitchenProfile : Profile
    {
        public OrderListForKitchenProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderListForKitchenDTO>()
                .ForMember(x => x.OrderId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.WaitingTime, x => x.MapFrom(x => 
                new TimeSpan(DateTime.Now.Hour - x.Date.Hour, DateTime.Now.Minute - x.Date.Minute, 0).ToString(@"hh\:mm")));
        }
    }
}
