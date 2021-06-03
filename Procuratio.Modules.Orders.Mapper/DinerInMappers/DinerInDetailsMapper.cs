using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Mapper.DinerInMappers
{
    public class DinerInDetailsMapper : Profile
    {
        public DinerInDetailsMapper()
        {
            CreateMap<DineIn, DineInDetailsDTO>();
        }
    }
}
