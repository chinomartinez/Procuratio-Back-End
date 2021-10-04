using AutoMapper;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Services
{
    internal sealed class OrderService : IOrderService
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

            //List<OrderDetailForListItemsDTO> items = new()
            //{
            //    new OrderDetailForListItemsDTO()
            //    {
            //        ItemId = 1,
            //        Name = "Espagueti",
            //        Description = null,
            //        ForKitchen = false,
            //        Image = null,
            //        PriceInsideRestaurant = 350,
            //        PriceOutsideRestaurant = 275,
            //        Quantity = 2,
            //        QuantityInKitchen = 2
            //    },
            //    new OrderDetailForListItemsDTO()
            //    {
            //        ItemId = 2,
            //        Name = "Coca cola 500 ml",
            //        Description = null,
            //        ForKitchen = false,
            //        Image = null,
            //        PriceInsideRestaurant = 200,
            //        PriceOutsideRestaurant = 150,
            //        Quantity = 4,
            //        QuantityInKitchen = 4
            //    },
            //    new OrderDetailForListItemsDTO()
            //    {
            //        ItemId = 3,
            //        Name = "Papas fritas",
            //        Description = null,
            //        ForKitchen = false,
            //        Image = null,
            //        PriceInsideRestaurant = 235,
            //        PriceOutsideRestaurant = 150,
            //        Quantity = 3,
            //        QuantityInKitchen = 0
            //    },
            //    new OrderDetailForListItemsDTO()
            //    {
            //        ItemId = 4,
            //        Name = "Milanesa",
            //        Description = null,
            //        ForKitchen = false,
            //        Image = null,
            //        PriceInsideRestaurant = 50,
            //        PriceOutsideRestaurant = 170,
            //        Quantity = 1,
            //        QuantityInKitchen = 0
            //    }
            //};

            OrderEditionFormInitializerDTO temp = _mapper.Map<OrderEditionFormInitializerDTO>(order);
            //temp.Items.AddRange(items);

            return temp;
        }

        public async Task UpdateWithoutReserveAsync(OrderFromFormDTO updateDTO, int id) 
        {
            Orders.Domain.Entities.Order order = await _orderRepository.GetWithoutReserveOrderDetailAsync(id);

            if (order is null) { throw new OrderNotFoundException(); }

            order = _mapper.Map(updateDTO, order);

            await _orderRepository.UpdateAsync(order);
        }
    }
}
