using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class ItemEditionFormInitializerProfile : Profile
    {
        public ItemEditionFormInitializerProfile()
        {
            CreateMap<Item, ItemEditionFormInitializerDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
