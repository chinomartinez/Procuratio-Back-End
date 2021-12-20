using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuCategoryMappers
{
    public class MenuCategoryFromFormProfile : Profile
    {
        public MenuCategoryFromFormProfile()
        {
            CreateMap<MenuCategoryFromFormDTO, MenuCategory>();
        }
    }
}
