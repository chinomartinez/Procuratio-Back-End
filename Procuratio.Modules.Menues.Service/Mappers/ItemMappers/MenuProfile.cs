using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Item, MenuDTO>()
                .ForMember(x => x.MenuCategoryId, x => x.MapFrom(x => x.MenuCategory.MenuCategory.Id))
                .ForMember(x => x.MenuCategoryName, x => x.MapFrom(x => x.MenuCategory.MenuCategory.Name))
                .ForMember(x => x.MenuSubCategoryId, x => x.MapFrom(x => x.MenuCategory.Id))
                .ForMember(x => x.MenuSubCategoryName, x => x.MapFrom(x => x.MenuCategory.Name))
                .ForMember(x => x.ItemId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.ItemName, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.PriceInsideRestaurant, x => x.MapFrom(x => x.PriceInsideRestaurant))
                .ForMember(x => x.PriceOutsideRestaurant, x => x.MapFrom(x => x.PriceOutsideRestaurant));
        }
    }
}
