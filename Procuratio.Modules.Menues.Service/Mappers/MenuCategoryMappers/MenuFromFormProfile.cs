using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //for (int categoryCount = 0; categoryCount < menuDTOs.Count; categoryCount++)
            //{

            //    menuCategories[categoryCount].Order = categoryCount;

            //    for (int subcategoryCount = 0; subcategoryCount < menuDTOs[categoryCount].SubcategoryForMenuList.Count; subcategoryCount++)
            //    {
            //        menuCategories[subcategoryCount].MenuSubCategories[subcategoryCount].Order = subcategoryCount;

            //        for (int itemCount = 0; itemCount < menuDTOs[categoryCount].SubcategoryForMenuList[subcategoryCount].ItemForMenuList.Count; itemCount++)
            //        {
            //            menuCategories[itemCount].MenuSubCategories[itemCount].Items[itemCount].Order = itemCount;
            //        }
            //    }
            //}
        }
    }
}
