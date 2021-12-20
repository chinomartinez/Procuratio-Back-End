using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuCategoryMappers
{
    public class MenuCategoryProfile : Profile
    {
        public MenuCategoryProfile()
        {
            CreateMap<MenuCategory, MenuCategoryDTO>();
        }
    }
}
