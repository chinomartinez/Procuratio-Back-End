using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.TableMappers
{
    public class TableEditionFormInitializerProfile : Profile
    {
        public TableEditionFormInitializerProfile()
        {
            CreateMap<Table, TableEditionFormInitializerDTO>()
                .ForMember(x => x.Table, x => x.MapFrom(x => x))
                .ForMember(x => x.StateName, x => x.MapFrom(x => x.TableState.StateName));
        }
    }
}
