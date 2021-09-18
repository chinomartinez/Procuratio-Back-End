using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.DinerInMappers
{
    public class DineInInProgressProfile : Profile
    {
        public DineInInProgressProfile()
        {
            CreateMap<DineIn, DineInInProgressDTO>()
                .ForMember(x => x.DineIn, x => x.MapFrom(x => x))
                .ForMember(x => x.OrderID, x => x.MapFrom(x => x.Order.ID))
                .ForMember(x => x.OrderStateID, x => x.MapFrom(x => x.Order.OrderStateID))
                .ForMember(x => x.OrderStateName, x => x.MapFrom(x => x.Order.OrderState.StateName))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.DineInTableNumbers, options => options.MapFrom(MapDineInTableNumbers));
        }

        private List<string> MapDineInTableNumbers(DineIn dineIn, DineInInProgressDTO dineInInProgressDTO)
        {
            List<string> result = new();

            const int maxCharacterTableNumberLenght = 3;

            dineIn.TableXDinerIn.ForEach(x => result.Add(x.Table.Number.ToString().PadLeft(maxCharacterTableNumberLenght, '0')));

            return result;
        }
    }
}
