using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;

namespace Procuratio.Modules.Orders.Service.Mappers.WithoutReserveMappers
{
    internal class WithoutReserveProfile : Profile
    {
        public WithoutReserveProfile()
        {
            CreateMap<WithoutReserve, WithoutReserveDTO>().ReverseMap();
        }
    }
}
