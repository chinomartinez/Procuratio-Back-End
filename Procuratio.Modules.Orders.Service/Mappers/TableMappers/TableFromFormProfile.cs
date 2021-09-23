using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Order.Service.Mappers.TableMappers
{
    public class TableFromFormProfile : Profile
    {
        public TableFromFormProfile()
        {
            CreateMap<TableFromFormDTO, Table>();
        }
    }
}
