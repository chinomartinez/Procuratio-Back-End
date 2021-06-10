using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;

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
