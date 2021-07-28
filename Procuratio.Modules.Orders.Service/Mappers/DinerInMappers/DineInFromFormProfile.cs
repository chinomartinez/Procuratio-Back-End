using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Procuratio.Modules.Order.Service.Mappers.DinerInMappers
{
    public class DineInFromFormProfile : Profile
    {
        public DineInFromFormProfile()
        {
            CreateMap<DineInFromFormDTO, DineIn>()
                .ForMember(x => x.TableXDinerIn, options => options.MapFrom(MapTableXDinerIn));
        }

        private List<TableXDinerIn> MapTableXDinerIn(DineInFromFormDTO dineInCreationDTO, DineIn dineIn)
        {
            var result = new List<TableXDinerIn>();

            if (dineInCreationDTO.TablesIds == null || dineInCreationDTO.TablesIds.Count() <= 0) { return result; }

            foreach (int tableID in dineInCreationDTO.TablesIds)
            {
                result.Add(new TableXDinerIn() { TableID = tableID });
            }

            return result;
        }
    }
}
