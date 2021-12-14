using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuSubcategoryMappers
{
    public class MenuSubcategoryEditionFormInitializerProfile : Profile
    {
        public MenuSubcategoryEditionFormInitializerProfile()
        {
            CreateMap<MenuSubcategory, MenuSubcategoryEditionFormInitializerDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
