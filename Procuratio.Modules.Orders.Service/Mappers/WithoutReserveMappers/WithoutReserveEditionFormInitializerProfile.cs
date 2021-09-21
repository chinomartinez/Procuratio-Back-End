using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveEditionFormInitializerProfile : Profile
    {
        public WithoutReserveEditionFormInitializerProfile()
        {
            CreateMap<WithoutReserve, WithoutReserveEditionFormInitializerDTO>()
                .ForMember(x => x.WithoutReserve, x => x.MapFrom(x => x))
                .ForMember(x => x.Tables, options => options.MapFrom(MapMultipleSelectOfTables));
        }

        private MultipleSelectListItemForEditionDTO MapMultipleSelectOfTables(WithoutReserve withoutReserve, WithoutReserveEditionFormInitializerDTO withoutReserveFromFormDTO)
        {
            MultipleSelectListItemForEditionDTO result = new();

            withoutReserve.TableXWithoutReserve.ForEach(x =>
            {
                result.SelectedOptionsIds.Add(x.TableID.ToString());
                result.Items.Add(new SelectListItemDTO() { ID = x.TableID.ToString(), Description = x.Table.Number.ToString() });
            });

            return result;
        }
    }
}
