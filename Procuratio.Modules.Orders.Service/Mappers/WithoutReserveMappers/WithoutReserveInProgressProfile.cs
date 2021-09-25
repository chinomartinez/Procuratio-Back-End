using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveInProgressProfile : Profile
    {
        public WithoutReserveInProgressProfile()
        {
            CreateMap<WithoutReserve, WithoutReserveInProgressDTO>()
                .ForMember(x => x.WithoutReserve, x => x.MapFrom(x => x))
                .ForMember(x => x.OrderId, x => x.MapFrom(x => x.Order.Id))
                .ForMember(x => x.OrderStateId, x => x.MapFrom(x => x.Order.OrderStateId))
                .ForMember(x => x.OrderStateName, x => x.MapFrom(x => x.Order.OrderState.StateName))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.WithoutReserveTableNumbers, options => options.MapFrom(MapWithoutReserveTableNumbers));
        }

        private List<string> MapWithoutReserveTableNumbers(WithoutReserve withoutReserve, WithoutReserveInProgressDTO withoutReserveInProgressDTO)
        {
            List<string> result = new();

            const int maxCharacterTableNumberLenght = 3;

            withoutReserve.TableXWithoutReserve.ForEach(x => result.Add(x.Table.Number.ToString().PadLeft(maxCharacterTableNumberLenght, '0')));

            return result;
        }
    }
}
