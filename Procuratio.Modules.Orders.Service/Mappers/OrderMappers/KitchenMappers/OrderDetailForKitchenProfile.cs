using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers.KitchenMappers
{
    public class OrderDetailForKitchenProfile : Profile
    {
        public OrderDetailForKitchenProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderWithOrderDetailVM>()
                .ForPath(x => x.Id, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.Comment, options => options.MapFrom(MapOrderDetailForListItems));
        }

        private string MapOrderDetailForListItems(Orders.Domain.Entities.Order order, OrderWithOrderDetailVM orderDetailForKitchenDTO)
        {
            return order.OrderDetails.Find(x => x.ItemId == orderDetailForKitchenDTO.Id).Comment;
        }
    }
}
