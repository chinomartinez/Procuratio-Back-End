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

        private static List<OrderDetail> MapOrderDetail(OrderFromFormDTO orderFromFormDTO, Orders.Domain.Entities.Order order)
        {
            List<OrderDetail> result = new();

            result.AddRange(order.OrderDetails);

            result = result.Where(x => orderFromFormDTO.Items.Select(x => x.ItemId).ToList().Contains(x.ItemId)).ToList();

            List<int> itemsAlreadyInDatabase = result.Select(x => x.ItemId).ToList();

            foreach (ItemForOrderFormDTO element in orderFromFormDTO.Items)
            {
                if (itemsAlreadyInDatabase.Contains(element.ItemId))
                {
                    OrderDetail currentOrderDetail = result.First(x => x.ItemId == element.ItemId);
                    currentOrderDetail.Note = element.Note;

                    SetQuantity(element, currentOrderDetail);
                }
                else
                {
                    OrderDetail orderDetail = new();

                    orderDetail.OrderId = order.Id;
                    orderDetail.BranchId = TGRID.BranchId;
                    orderDetail.ItemId = element.ItemId;
                    orderDetail.Note = element.Note;

                    SetQuantity(element, orderDetail);

                    result.Add(orderDetail);
                }
            }

            return result;
        }

        private static void SetQuantity(ItemForOrderFormDTO itemForOrderFormDTO, OrderDetail orderDetail)
        {
            if (itemForOrderFormDTO.ForKitchen)
            {
                orderDetail.QuantityInKitchen = itemForOrderFormDTO.Quantity;
                orderDetail.Quantity = 0;
            }
            else
            {
                orderDetail.Quantity = itemForOrderFormDTO.Quantity;
                orderDetail.QuantityInKitchen = 0;
            }
        }
    }
}
