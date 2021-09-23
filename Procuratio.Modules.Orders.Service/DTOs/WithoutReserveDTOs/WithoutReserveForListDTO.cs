using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveForListDTO : IListDTO
    {
        public WithoutReserveDTO WithoutReserve { get; set; } = new WithoutReserveDTO();

        public short OrderStateID { get; set; }

        public string WaitersName { get; set; }

        public string StateName { get; set; }

        public List<string> TableNumbers { get; set; } = new List<string>();
    }
}
