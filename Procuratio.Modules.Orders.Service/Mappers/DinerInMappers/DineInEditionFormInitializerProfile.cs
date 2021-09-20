using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Shared.ProcuratioFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.DinerInMappers
{
    public class DineInEditionFormInitializerProfile : Profile
    {
        public DineInEditionFormInitializerProfile()
        {
            CreateMap<DineIn, DineInEditionFormInitializerDTO>()
                .ForMember(x => x.DineIn, x => x.MapFrom(x => x))
                .ForMember(x => x.Tables, options => options.MapFrom(MapMultipleSelectOfTables));
        }

        private MultipleSelectListItemForEditionDTO<int> MapMultipleSelectOfTables(DineIn dineIn, DineInEditionFormInitializerDTO dineInFromFormDTO)
        {
            MultipleSelectListItemForEditionDTO<int> result = new();

            dineIn.TableXDinerIn.ForEach(x =>
            {
                result.SelectedOptionsIds.Add(x.TableID);
                result.Items.Add(new SelectListItemDTO<int>() { ID = x.TableID, Description = x.Table.Number.ToString() });
            });

            return result;
        }
    }
}
