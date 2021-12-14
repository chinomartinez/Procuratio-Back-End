using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderInProgressProfile : Profile
    {
        public OrderInProgressProfile()
        {
            CreateMap<Orders.Domain.Entities.Order, OrderInProgressDTO>()
                .ForMember(x => x.OrderId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.OrderStateId, x => x.MapFrom(x => x.OrderStateId))
                .ForMember(x => x.OrderStateName, x => x.MapFrom(x => x.OrderState.StateName))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.OrderTableNumbers, options => options.MapFrom(OrderTableNumbers));
        }

        private List<string> OrderTableNumbers(Orders.Domain.Entities.Order order, OrderInProgressDTO orderInProgressDTO)
        {
            List<string> result = new();

            //const int maxCharacterTableNumberLenght = 3;

            //order.TableXWithoutReserve.ForEach(x => result.Add(x.Table.Number.ToString().PadLeft(maxCharacterTableNumberLenght, '0')));

            return result;
        }
    }
}
