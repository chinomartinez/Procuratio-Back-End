using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Mappers.TableMappers
{
    internal class AddTableProfile : Profile
    {
        public AddTableProfile()
        {
            CreateMap<AddTableDTO, Table>();
        }
    }
}
