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
                .ForMember(x => x.ItemCategoryId, x => x.MapFrom(x => x.ItemSubCategory.ItemCategory.Id))
                .ForMember(x => x.ItemCategoryName, x => x.MapFrom(x => x.ItemSubCategory.ItemCategory.Name))
                .ForMember(x => x.ItemSubCategoryId, x => x.MapFrom(x => x.ItemSubCategory.Id))
                .ForMember(x => x.ItemSubCategoryName, x => x.MapFrom(x => x.ItemSubCategory.Name))
                .ForMember(x => x.ItemId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.ItemName, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.PriceInsideRestaurant, x => x.MapFrom(x => x.PriceInsideRestaurant))
                .ForMember(x => x.PriceOutsideRestaurant, x => x.MapFrom(x => x.PriceOutsideRestaurant));
        }
    }
}
