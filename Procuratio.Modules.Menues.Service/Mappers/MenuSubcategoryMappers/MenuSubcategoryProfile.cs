using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuSubcategoryMappers
{
    public class MenuSubcategoryProfile : Profile
    {
        public MenuSubcategoryProfile()
        {
            CreateMap<MenuSubcategory, MenuSubcategoryDTO>();
        }
    }
}
