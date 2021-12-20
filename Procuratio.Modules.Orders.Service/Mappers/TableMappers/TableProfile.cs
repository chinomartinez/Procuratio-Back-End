using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;

namespace Procuratio.Modules.Orders.Service.Mappers.TableMappers
{
    internal class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableDTO>();
        }
    }
}
