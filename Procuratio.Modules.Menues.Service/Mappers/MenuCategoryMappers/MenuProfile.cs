using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
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
                .ForMember(x => x.ItemForMenuList, options => options.MapFrom(MapMenuItem));
        }

        private static List<ItemForMenuDTO> MapMenuItem(MenuModel menuModel, MenuDTO menuDTO)
        {
            List<ItemForMenuDTO> result = new();

            foreach (ItemMenuModel item in menuModel.ItemsModel)
            {
                ItemForMenuDTO itemForMenuDTO = new()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ItemOrder = item.ItemOrder
                };

                result.Add(itemForMenuDTO);
            }

            return result;
        }
    }
}
