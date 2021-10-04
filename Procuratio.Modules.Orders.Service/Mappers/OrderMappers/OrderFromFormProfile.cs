using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderFromFormProfile : Profile
    {
        public OrderFromFormProfile()
        {
            CreateMap<OrderFromFormDTO, Orders.Domain.Entities.Order>();
        }
    }
}
