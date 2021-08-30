using Procuratio.Modules.Orders.DTO.OrderDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.DTO.DinerInDTOs
{
    public class DineInDTO : IDTO
    {
        public int OrderID { get; set; }

        public short DinerInStateID { get; set; }
    }
}
