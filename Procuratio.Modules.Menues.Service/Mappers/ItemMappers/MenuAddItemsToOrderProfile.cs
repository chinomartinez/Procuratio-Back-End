using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class MenuAddItemsToOrderProfile : Profile
    {
        public MenuAddItemsToOrderProfile()
        {
            CreateMap<Item, MenuAddItemsToOrderVM>()
                .ForMember(x => x.MenuCategoryId, x => x.MapFrom(x => x.MenuSubcategory.MenuCategory.Id))
                .ForMember(x => x.MenuCategoryName, x => x.MapFrom(x => x.MenuSubcategory.MenuCategory.Name))
                .ForMember(x => x.MenuSubCategoryId, x => x.MapFrom(x => x.MenuSubcategory.Id))
                .ForMember(x => x.MenuSubcategoryName, x => x.MapFrom(x => x.MenuSubcategory.Name))
                .ForMember(x => x.ItemId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.ItemName, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.PriceInsideRestaurant, x => x.MapFrom(x => x.PriceInsideRestaurant))
                .ForMember(x => x.PriceOutsideRestaurant, x => x.MapFrom(x => x.PriceOutsideRestaurant));
        }
    }
}
