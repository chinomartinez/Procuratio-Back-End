using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemCategoryMappers
{
    public class MenuCategoryEditionFormInitializerProfile : Profile
    {
        public MenuCategoryEditionFormInitializerProfile()
        {
            CreateMap<MenuCategory, MenuCategoryEditionFormInitializerDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
