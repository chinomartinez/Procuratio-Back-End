using AutoMapper;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;

namespace Procuratio.Modules.Orders.Service.Mappers.DinerInMappers
{
    internal class DineInProfile : Profile
    {
        public DineInProfile()
        {
            CreateMap<DineIn, DineInDTO>().ReverseMap();
        }
    }
}
