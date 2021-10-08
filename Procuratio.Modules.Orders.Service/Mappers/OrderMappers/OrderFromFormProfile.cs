using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderFromFormProfile : Profile
    {
        public OrderFromFormProfile()
        {
            CreateMap<OrderFromFormDTO, Orders.Domain.Entities.Order>()
                .ForMember(x => x.OrderDetails, options => options.MapFrom(MapOrderDetail));
        }

        // The order is created with the type of order so, it is always an update
        private List<OrderDetail> MapOrderDetail(OrderFromFormDTO orderFromFormDTO, Orders.Domain.Entities.Order order)
        {
            List<int> itemIdsFromDTO = orderFromFormDTO.Items.Select(x => x.ItemId).ToList();

            order.OrderDetails = order.OrderDetails.Where(x => itemIdsFromDTO.Contains(x.ItemId)).ToList();

            List<int> itemsAlreadyInDatabase = order.OrderDetails.Select(x => x.ItemId).ToList();

            orderFromFormDTO.Items.ForEach(x =>
            {
                if (itemsAlreadyInDatabase.Contains(x.ItemId))
                {
                    // editar...
                }
                else
                {
                    OrderDetail orderDetail = new();

                    orderDetail.OrderId = order.Id;
                    orderDetail.BranchId = TGRID.BranchId;
                    orderDetail.ItemId = x.ItemId;

                    if (x.ForKitchen)
                    {
                        orderDetail.QuantityInKitchen = x.Quantity;
                        orderDetail.Quantity = 0;
                    }
                    else
                    {
                        orderDetail.Quantity = x.Quantity;
                        orderDetail.QuantityInKitchen = 0;
                    }


                    order.OrderDetails.Add(orderDetail);
                }
            });

            return order.OrderDetails;
        }
    }
}
