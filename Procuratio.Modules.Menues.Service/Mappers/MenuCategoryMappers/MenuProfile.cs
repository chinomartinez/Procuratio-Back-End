using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuCategoryMappers
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuModel, MenuDTO>()
                .ForMember(x => x.MenuCategoryId, x => x.MapFrom(x => x.MenuCategoryId))
                .ForMember(x => x.MenuCategoryName, x => x.MapFrom(x => x.MenuCategoryName))
                .ForMember(x => x.MenuCategoryOrder, x => x.MapFrom(x => x.MenuCategoryOrder))
                .ForMember(x => x.SubcategoryForMenuList, options => options.MapFrom(MapMenuSubcategory));
        }

        private static List<SubcategoryForMenuDTO> MapMenuSubcategory(MenuModel menuModel, MenuDTO menuDTO)
        {
            List<SubcategoryForMenuDTO> result = new();

            foreach (SubcategoryModel subcategoryItem in menuModel.SubcategoriesModel)
            {
                SubcategoryForMenuDTO subcategoryForMenuDTO = new()
                {
                    MenuSubcategoryId = subcategoryItem.MenuSubcategoryId,
                    MenuSubcategoryName = subcategoryItem.MenuSubcategoryName,
                    MenuSubcategoryOrder = subcategoryItem.MenuSubcategoryOrder,
                    ItemForMenuList = new List<ItemForMenuDTO>()
                };

                foreach (ItemModel item in subcategoryItem.ItemsModel)
                {
                    subcategoryForMenuDTO.ItemForMenuList.Add(new ItemForMenuDTO
                    {
                        ItemId = item.ItemId,
                        ItemName = item.ItemName,
                        ItemOrder = item.ItemOrder
                    });
                }

                result.Add(subcategoryForMenuDTO);
            }

            return result;
        }
    }
}
