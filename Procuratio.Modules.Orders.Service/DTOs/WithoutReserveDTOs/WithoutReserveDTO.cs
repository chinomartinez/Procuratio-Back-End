using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveDTO : IDTO
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public short WithoutReserveStateID { get; set; }
    }
}
