using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class ItemFromFormProfile : Profile
    {
        public ItemFromFormProfile()
        {
            CreateMap<ItemFromFormDTO, Item>()
                .ForMember(dest => dest.Description, opt => opt.NullSubstitute(string.Empty))
                .ForMember(dest => dest.Code, opt => opt.NullSubstitute(string.Empty));
        }
    }
}
