using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Service.DTOs.DinerInDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Mappers.DinerInMappers
{
    internal class AddDineInProfile : Profile
    {
        public AddDineInProfile()
        {
            CreateMap<AddDineInDTO, DineIn>()
                .ForMember(x => x.TableXDinerIn, options => options.MapFrom(MapTableXDinerIn));
        }

        private List<TableXDinerIn> MapTableXDinerIn(AddDineInDTO dineInCreationDTO, DineIn dineIn)
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
