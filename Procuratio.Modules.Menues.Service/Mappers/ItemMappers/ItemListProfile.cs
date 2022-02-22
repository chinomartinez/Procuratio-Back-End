using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class ItemListProfile : Profile
    {
        public ItemListProfile()
        {
            CreateMap<Item, ItemForListDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x))
                .ForMember(x => x.CategoryName, x => x.MapFrom(x => x.MenuCategory.Name));
        }
    }
}
