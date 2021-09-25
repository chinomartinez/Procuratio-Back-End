using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<OrderDTO>
    {
        public OrderDTO BaseProperties { get; set; } = new OrderDTO();

        public string OrderStateName { get; set; }
    }
}
