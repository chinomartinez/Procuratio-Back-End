using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuSubcategoryMappers
{
    public class MenuSucategoryListProfile : Profile
    {
        public MenuSucategoryListProfile()
        {
            CreateMap<MenuSubcategory, MenuSubcategoryForListDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
