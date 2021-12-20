using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuCategoryMappers
{
    public class MenuCategoryListProfile : Profile
    {
        public MenuCategoryListProfile()
        {
            CreateMap<MenuCategory, MenuCategoryForListDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
