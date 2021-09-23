using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableForListDTO : IListDTO
    {
        public TableDTO Table { get; set; } = new TableDTO();
    }
}
