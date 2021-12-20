using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers.KitchenMappers
{
    public class OrderDetailForKitchenProfile : Profile
    {
        public OrderDetailForKitchenProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderWithOrderDetailVM>()
                .ForPath(x => x.Id, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.Note, options => options.MapFrom(MapOrderDetailForListItems));
        }

        private string MapOrderDetailForListItems(Orders.Domain.Entities.Order order, OrderWithOrderDetailVM orderDetailForKitchenDTO)
        {
            return order.OrderDetails.Find(x => x.ItemId == orderDetailForKitchenDTO.Id).Note;
        }
    }
}
