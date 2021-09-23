using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderDTO : IDTO
    {
        public DateTime Date { get; set; }

        public string KitchenNote { get; set; }

        public short OrderStateID { get; set; }

        public int WaiterID { get; set; }

        public int CustomerID { get; set; }
    }
}
