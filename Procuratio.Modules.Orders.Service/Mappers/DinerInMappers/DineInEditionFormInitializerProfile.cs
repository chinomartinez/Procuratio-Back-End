using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.DinerInMappers
{
    public class DineInEditionFormInitializerProfile : Profile
    {
        public DineInEditionFormInitializerProfile()
        {
            CreateMap<DineIn, DineInEditionFormInitializerDTO>()
                .ForMember(x => x.DineIn, x => x.MapFrom(x => x));
        }
    }
}
