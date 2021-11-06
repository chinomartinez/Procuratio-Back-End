using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
