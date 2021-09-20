using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
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

        private MultipleSelectListItemForEditionDTO MapMultipleSelectOfTables(DineIn dineIn, DineInEditionFormInitializerDTO dineInFromFormDTO)
        {
            MultipleSelectListItemForEditionDTO result = new();

            dineIn.TableXDinerIn.ForEach(x =>
            {
                result.SelectedOptionsIds.Add(x.TableID.ToString());
                result.Items.Add(new SelectListItemDTO() { ID = x.TableID.ToString(), Description = x.Table.Number.ToString() });
            });

            return result;
        }
    }
}
