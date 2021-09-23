using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveFromFormProfile : Profile
    {
        public WithoutReserveFromFormProfile()
        {
            CreateMap<WithoutReserveFromFormDTO, WithoutReserve>()
                .ForMember(x => x.TableXWithoutReserve, options => options.MapFrom(MapTableXWithoutReserve));
        }

        private List<TableXWithoutReserve> MapTableXWithoutReserve(WithoutReserveFromFormDTO withoutReserveFromFormDTO, WithoutReserve withoutReserve)
        {
            List<TableXWithoutReserve> result = new();

            if (withoutReserveFromFormDTO.TablesIds is null) { return result; }

            withoutReserveFromFormDTO.TablesIds.ForEach(x => result.Add(new() { TableID = x, BranchId = TGRID.BranchId }));

            return result;
        }
    }
}
