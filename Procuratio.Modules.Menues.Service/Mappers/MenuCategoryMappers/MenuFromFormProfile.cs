using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuCategoryMappers
{
    public class MenuFromFormProfile : Profile
    {
        public MenuFromFormProfile()
        {
            CreateMap<List<MenuDTO>, List<MenuCategory>>()
                .AfterMap((src, dest) => MapMenu(src, dest));
        }

        private static List<MenuCategory> MapMenu(List<MenuDTO> menuDTOs, List<MenuCategory> menuCategories)
        {
            foreach (MenuDTO categoryDTO in menuDTOs)
            {
                MenuCategory menuCategory = menuCategories.FirstOrDefault(x => x.Id == categoryDTO.MenuCategoryId);
                menuCategory.Order = categoryDTO.MenuCategoryOrder;

                foreach (ItemForMenuDTO itemDTO in categoryDTO.ItemForMenuList)
                {
                    Item item = menuCategory.Items.FirstOrDefault(x => x.Id == itemDTO.ItemId);
                    item.Order = itemDTO.ItemOrder;
                }
            }

            return menuCategories;
        }
    }
}
