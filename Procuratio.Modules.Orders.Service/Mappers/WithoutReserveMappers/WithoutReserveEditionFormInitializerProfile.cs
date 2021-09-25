using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveEditionFormInitializerProfile : Profile
    {
        public WithoutReserveEditionFormInitializerProfile()
        {
            CreateMap<WithoutReserve, WithoutReserveEditionFormInitializerDTO>()
                .ForMember(x => x.BaseProperties, x => x.MapFrom(x => x))
                .ForMember(x => x.Tables, options => options.MapFrom(MapMultipleSelectOfTables));
        }

        private MultipleSelectListItemForEditionDTO MapMultipleSelectOfTables(WithoutReserve withoutReserve, WithoutReserveEditionFormInitializerDTO withoutReserveFromFormDTO)
        {
            MultipleSelectListItemForEditionDTO result = new();

            withoutReserve.TableXWithoutReserve.ForEach(x =>
            {
                result.SelectedOptionsIds.Add(x.TableId.ToString());
                result.Items.Add(new SelectListItemDTO() { Id = x.TableId.ToString(), Description = x.Table.Number.ToString() });
            });

            return result;
        }
    }
}
