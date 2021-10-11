using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderDTO : IDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public short OrderStateId { get; set; }

        public int WaiterId { get; set; }

        public int CustomerId { get; set; }
    }
}
