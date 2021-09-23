using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveListProfile : Profile
    {
        public WithoutReserveListProfile()
        {
            CreateMap<WithoutReserve, WithoutReserveForListDTO>()
                .ForMember(x => x.WithoutReserve, x => x.MapFrom(x => x))
                .ForMember(x => x.StateName, x => x.MapFrom(x => x.WithoutReserveState.StateName))
                .ForMember(x => x.OrderStateID, x => x.MapFrom(x => x.Order.OrderStateID))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.TableNumbers, options => options.MapFrom(MapTableNumbers));
        }

        private List<string> MapTableNumbers(WithoutReserve withoutReserve, WithoutReserveForListDTO withoutReserveForListDTO)
        {
            List<string> result = new();

            withoutReserve.TableXWithoutReserve.ForEach(x => result.Add(x.Table.Number.ToString()));

            return result;
        }
    }
}
