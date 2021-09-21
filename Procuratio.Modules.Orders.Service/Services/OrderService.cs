using AutoMapper;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderEditionFormInitializerDTO> GetWithoutReserveOrderDetailAsync(int orderId)
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithoutReserveOrderDetailAsync(orderId);

            if (order is null) { throw new OrderNotFoundException(); }

            return _mapper.Map<OrderEditionFormInitializerDTO>(order);
        }
    }
}
