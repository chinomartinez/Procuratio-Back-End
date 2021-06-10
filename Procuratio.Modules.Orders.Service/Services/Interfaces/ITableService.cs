using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface ITableService : IBaseServiceOperations<TableDTO, UpdateTableDTO, AddTableDTO, int>
    {
    }
}
