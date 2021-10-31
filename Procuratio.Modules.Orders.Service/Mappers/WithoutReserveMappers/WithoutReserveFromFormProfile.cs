using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
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

            if (withoutReserve.Id != 0) withoutReserve.TableXWithoutReserve.Clear();

            withoutReserveFromFormDTO.TablesIds.ForEach(x => result.Add(new() { TableId = x }));

            return result;
        }
    }
}
