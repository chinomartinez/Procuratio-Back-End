using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Mappers.MenuSubcategoryMappers
{
    public class MenuCategoryEditionFormInitializerProfile : Profile
    {
        public MenuCategoryEditionFormInitializerProfile()
        {
            CreateMap<MenuSubcategoryFromFormDTO, MenuSubcategory>();
        }
    }
}
