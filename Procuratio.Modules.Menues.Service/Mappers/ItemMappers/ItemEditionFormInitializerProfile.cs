using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class ItemEditionFormInitializerProfile : Profile
    {
        public ItemEditionFormInitializerProfile()
        {
            CreateMap<Item, ItemEditionFormInitializerDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
