using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Order.Service.Mappers.TableMappers
{
    public class TableListProfile : Profile
    {
        public TableListProfile()
        {
            CreateMap<Table, TableForListDTO>().ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
