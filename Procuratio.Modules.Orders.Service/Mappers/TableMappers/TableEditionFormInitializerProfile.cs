using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Domain.Entities;

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
