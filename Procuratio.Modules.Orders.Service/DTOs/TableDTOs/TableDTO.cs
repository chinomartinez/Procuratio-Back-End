using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class TableDTO : IDTO
    {
        public int Id { get; set; }

        public short Number { get; set; }

        public int Capacity { get; set; }
    }
}
