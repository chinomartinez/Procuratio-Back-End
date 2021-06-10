using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;

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
