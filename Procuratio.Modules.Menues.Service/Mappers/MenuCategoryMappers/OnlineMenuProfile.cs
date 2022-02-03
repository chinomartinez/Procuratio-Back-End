using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using System.Collections.Generic;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuCategoryMappers
{
    public class OnlineMenuProfile : Profile
    {
        public OnlineMenuProfile()
        {
            CreateMap<OnlineMenuModel, OnlineMenuDTO>()
                .ForMember(x => x.MenuCategoryName, x => x.MapFrom(x => x.MenuCategoryName))
                .ForMember(x => x.itemForOnlineMenuList, options => options.MapFrom(MapMenuItem));
        }

        private static List<ItemForOnlineMenuDTO> MapMenuItem(OnlineMenuModel menuModel, OnlineMenuDTO menuDTO)
        {
            List<ItemForOnlineMenuDTO> result = new();

            foreach (ItemOnlineMenuModel item in menuModel.ItemsModel)
            {
                ItemForOnlineMenuDTO itemForOnlineMenuDTO = new()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Description = item.Description,
                    ForKitchen = item.ForKitchen,
                    Image = item.Image,
                    Price = item.Price
                };

                result.Add(itemForOnlineMenuDTO);
            }

            return result;
        }
    }
}
