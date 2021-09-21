using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Procuratio.ProcuratioFramework.ProcuratioFramework;

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

            withoutReserveFromFormDTO.TablesIds.ForEach(x => result.Add(new() { TableID = x, BranchID = TGRID.BranchID }));

            return result;
        }
    }
}
