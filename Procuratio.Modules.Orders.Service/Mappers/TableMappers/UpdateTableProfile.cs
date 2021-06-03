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
    internal class UpdateTableProfile : Profile
    {
        public UpdateTableProfile()
        {
            CreateMap<Table, UpdateTableDTO>();
        }
    }
}
