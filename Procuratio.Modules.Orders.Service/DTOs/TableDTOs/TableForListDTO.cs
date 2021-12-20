using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableForListDTO : IListDTO<TableDTO>
    {
        public TableDTO BaseProperties { get; set; } = new TableDTO();
    }
}
