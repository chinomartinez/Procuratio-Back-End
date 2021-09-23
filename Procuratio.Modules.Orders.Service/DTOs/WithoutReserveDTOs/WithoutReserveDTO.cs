using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveDTO : IDTO
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public short WithoutReserveStateId { get; set; }
    }
}
