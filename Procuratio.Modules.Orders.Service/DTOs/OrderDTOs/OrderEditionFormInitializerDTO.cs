using Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<OrderDTO>
    {
        public OrderDTO BaseProperties { get; set; } = new OrderDTO();

        public List<OrderDetailForListItemsDTO> Items { get; set; } = new();

        public string OrderStateName { get; set; }

        public string Note { get; set; }
    }
}
